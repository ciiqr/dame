using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

using dame.Data;
using dame.Data.Sync;
using dame.Data.Utilities;
using dame.Utilities;
using dame.Utilities.Extensions;
using dame.Plugins;

namespace dame
{
    public class Controller
    {
        private UserInterface ui;

        private string _username;
        private string _authToken;
        private bool _isSandbox;

        private Sync _sync;
        private Sync sync
        {
            get
            {
                if (_sync == null)
                {
                    // TODO: Store isSandbox in keyring attributes
                    _sync = new Sync(_authToken, _isSandbox);
                }
                return _sync;
            }
            set
            {
                _sync = value;
            }
        }

        private Database db = new Database();

        public Controller(Dictionary<string, string> options)
        {
            // TODO: Configure based on options
            // TODO: Allow specification of a user
            // TODO: Initialize ui with the first one we can find in the ui plugins directory if we still cant get one
            string userInterfaceName = options.GetElse(Constants.OPTIONS_UI_KEY, Constants.DEFAULT_OPTION_UI);

            ui = Plugins.Plugins.LoadUserInterface(userInterfaceName);
            setupUIEvents();

            // TODO: Testing
//            Console.WriteLine(Conversion.Convert(DocumentType.HTML, DocumentType.XHTML, "<html><body><p>This is some test test<ul><li>item 1<li>item2<</ul></body>"));
//            Console.WriteLine(Conversion.Convert(DocumentType.HTML, DocumentType.XHTML, "<html><body><p>This is some test test<p><ul><li>item 1</li><li>item2<</ul></body>"));
        }

        private void setupUIEvents()
        {
            ui.mainLoopInitializedEvent += (sender) =>
            {
                setupUser();
            };
        }

        private void setupUser()
        {
            #if DEBUG
            if (DameUser.currentUser == null)
                DameUser.currentUser = "willvill1995sand";
            #endif

            _username = DameUser.currentUser;

            if (_username == null)
            {
                // No User
                // TODO: Display login window
//                ui.windows.login.dislay();
//                ui.windows.login.dislay.onCompletionHandler += OAuthTokenRecieved;
            }
            else
            {
                // TODO: How Do I reauth without reprompting
                // TODO: Check if we have an auth token for the user
                //  - If getAuthToken returns null, display error & prompt for re-authorization
                string authToken = Keyring.getAuthToken(_username, out _isSandbox);

                if (authToken == null)
                {
                    // TODO: ui.authPrompt.display(string initialUsername = null)
                    // TODO: Implement OAuth

                }
                else
                {
                    if (!DameUser.databaseExists())
                    {
                        // TODO: When database doesn't exist but we had a user in LAST_USER_PATH
                        Console.WriteLine("Have a username from LAST_USER_PATH, an auth token from the keyring, but no database file...");

                        // TODO: Testing ONLY
                        bool isSandbox = true;
                        OAuthTokenRecieved(authToken, _username, isSandbox);
                    }
                    else
                    {
                        // We have everything
                        setupUI();
                    }
                }
            }
        }

        private void setupUI()
        {
            // TODO: Start loading data, display main ui, etc.

            // TODO: Testing
            Async.aSyncLong(delegate
            {
                var user = db.getUser(_username);

            });
        }

        public void Run()
        {
            ui.runMainLoop();
        }

        private void OAuthTokenRecieved(string authToken, string username, bool isSandbox)
        {
            _authToken = authToken;
            _username = username;
            _isSandbox = isSandbox;

            DameUser.currentUser = username;

            if (!DameUser.databaseExists())
            {
                // TODO: Add property for initial sync canceller, or store in syncCanceller
                //            this.initialSyncCanceler = 
                Async.aSyncLong((initialSyncCanceler) =>
                {
                    InitialSyncComplete doneHandler = null;
                    doneHandler = (user, premiumInfo) =>
                    {
                        sync.InitialSyncCompleteHandler -= doneHandler;

                        if (!Keyring.saveAuthToken(_username, authToken, isSandbox))
                        {
                            // TODO: Display an error to the user & allow them to try to login again
                            //                        ui.displayPopupMessage(title:"Error Logging In", message:"Could not save authorization token in the keyring");
                            Console.Write("");
                        }

                        DameUser.createUserDirectory(DameUser.currentUser);
                        db.initializeDatabaseWithUser(user);

                        // TODO: Send premiumInfo to database

                    };
                    sync.InitialSyncCompleteHandler += doneHandler;

                    var progressHandler = new Progress<SyncProgress>();
                    progressHandler.ProgressChanged += (object sender, SyncProgress e) =>
                    {
                        Async.main(() =>
                        {
                            // TODO: Update UI with progress
                        });
                    };

                    // TODO: Should return user from this method?
                    // TODO: Currently throws an exception when offline
                    sync.initialSync(initialSyncCanceler.Token, progressHandler);
                });
            }
            else
            {
                // TODO: Multi-User: User is already attached, resave auth token & switch to user
            }
        }
    }
}

