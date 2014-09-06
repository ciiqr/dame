using System;
using System.Threading;
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

        public Controller(Dictionary<string, string> options)
        {
            // TODO: Configure based on options
            // TODO: Initialize ui with either user specified ui OR gtk OR the first one we can find in the ui plugins directory
            string userInterfaceName = options.GetElse(Constants.OPTIONS_UI_KEY, Constants.DEFAULT_OPTION_UI);

            ui = Plugins.Plugins.LoadUserInterface(userInterfaceName);

            // TODO: Initialize user with user specified user OR the user we grab some other way
            // TODO: Get from initial sync when applicable
            _username = "willvill1995";


            Console.WriteLine(Conversion.Convert(DocumentType.HTML, DocumentType.XHTML, "<html><body><p>This is some test test<ul><li>item 1<li>item2<</ul></body>"));
            Console.WriteLine(Conversion.Convert(DocumentType.HTML, DocumentType.XHTML, "<html><body><p>This is some test test<p><ul><li>item 1</li><li>item2<</ul></body>"));


//            // TODO: Assume the user is the file name of the database in ~/.config/Dame/willvill1995/willvill1995.db
//            // TODO: Check if we have a user database already
//            // TODO: Check if we have an auth token for the user
//            //  - If getAuthToken returns null, display error & prompt for re-authorization
//            string authToken = Keyring.getAuthToken(_username);
//
//            // TODO: Implement OAuth
//            //            bool isSandbox = true;
//            //            OAuthTokenRecieved(authToken, isSandbox);
        }

        public void Run()
        {
            ui.runMainLoop();
        }

        private void OAuthTokenRecieved(string authToken, bool isSandbox)
        {
            _authToken = authToken;
            _isSandbox = isSandbox;

            // TODO: Add property for initial sync canceller, or store in syncCanceller
//            this.initialSyncCanceler = 
            Async.aSyncLong((initialSyncCanceler) =>
            {
                InitialSyncComplete doneHandler = null;
                doneHandler = (user, premiumInfo) =>
                {
                    sync.InitialSyncCompleteHandler -= doneHandler;

                    if (!Keyring.saveAuthToken(_username, _authToken))
                    {
                        // TODO: Display an error to the user & allow them to try to login again
                        Console.WriteLine("");
                    }

                    // TODO: Send user & premiumInfo to database

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

                sync.initialSync(initialSyncCanceler.Token, progressHandler);
            });
        }
    }
}

