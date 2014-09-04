using System;
using System.Threading;
using System.Globalization;
using Evernote;
using UserStoreConstants = Evernote.EDAM.UserStore.Constants;
using Evernote.EDAM.UserStore;
using Evernote.EDAM.NoteStore;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;

namespace dame.Data.Sync
{
    public class Sync
    {
        const string EVERNOTE_HOST = "www.evernote.com";
        const string EVERNOTE_SANDBOX_HOST = "sandbox.evernote.com";
        const string EVERNOTE_CLIENT_KEY = "willvill1995";
        const string EVERNOTE_CLIENT_SECRET = "d6a66c2726aa3a42";

        private string authToken;
        private bool isSandbox;

        private CancellationToken cancelationToken;
        private IProgress<SyncProgress> progressReporter;

        private UserStore.Client _userStore;
        private UserStore.Client userStore
        {
            get
            {
                if (_userStore == null)
                {
                    String evernoteHost = isSandbox ? EVERNOTE_SANDBOX_HOST : EVERNOTE_HOST;

                    Uri userStoreUrl = new Uri("https://" + evernoteHost + "/edam/user");
                    TTransport userStoreTransport = new THttpClient(userStoreUrl);
                    TProtocol userStoreProtocol = new TBinaryProtocol(userStoreTransport);
                    _userStore = new UserStore.Client(userStoreProtocol);
                }
                return _userStore;
            }
        }

        private NoteStore.Client _noteStore;
        private NoteStore.Client noteStore
        {
            get
            {
                if (_noteStore == null)
                {
                    String noteStoreUrl = userStore.getNoteStoreUrl(authToken);
                    TTransport noteStoreTransport = new THttpClient(new Uri(noteStoreUrl));
                    TProtocol noteStoreProtocol = new TBinaryProtocol(noteStoreTransport);
                    _noteStore = new NoteStore.Client(noteStoreProtocol);
                }
                return _noteStore;
            }
        }

        public Sync(string authToken, bool isSandbox)
        {
            this.authToken = authToken;
            this.isSandbox = isSandbox;

            var username = "willvill1995";
            // TODO: Move to the most appropriate place
            // If it returns false, display an error to the user & allow them to login again
            Keyring.saveAuthToken(username, "OMG, this is that random ass string that I need to authorize access to evernote");
            // TODO: If getAuthToken returns null, display error & prompt for re-authorization
            Console.WriteLine(Keyring.getAuthToken(username));

            Console.Write("");
        }

        private bool isEdamVersionValid()
        {
            return userStore.checkVersion(Constants.APPLICATION_NAME,
                UserStoreConstants.EDAM_VERSION_MAJOR,
                UserStoreConstants.EDAM_VERSION_MINOR);
        }

        public void initialSync(CancellationToken cancelationToken, IProgress<SyncProgress> progressReporter)
        {
            setupForAsync(cancelationToken, progressReporter);

            throwIfCanceled();
            updateProgress(0, SyncState.Downloading);

            if (isEdamVersionValid())
            {
                throwIfCanceled();
                updateProgress(10, SyncState.Downloading);

                var bootstrapProfile = userStore.getBootstrapInfo(CultureInfo.CurrentCulture.Name).Profiles[0];

                throwIfCanceled();
                updateProgress(33, SyncState.Downloading);

                var user = userStore.getUser(authToken);

                throwIfCanceled();
                updateProgress(66, SyncState.Downloading);

                PremiumInfo premiumInfo = null;

                if (user.Accounting.PremiumServiceStatus != Evernote.EDAM.Type.PremiumOrderStatus.NONE)
                    premiumInfo = userStore.getPremiumInfo(authToken);

                throwIfCanceled();
                updateProgress(99, SyncState.Downloading);

                // TODO: We will call out an event when this is done
                Console.WriteLine(user);
                Console.WriteLine(premiumInfo);

                throwIfCanceled();
                updateProgress(100, SyncState.Downloading);
            }
            else
            {
                Console.WriteLine("The client's evernote sdk version is out of date!");
                // TODO: event with failed reason
            }
        }
            
        void sync(CancellationToken cancelationToken, IProgress<SyncProgress> progressReporter)
        {
            setupForAsync(cancelationToken, progressReporter);

            // TODO: Actually implement based on partial existing python code & edam sync document

            throwIfCanceled();

            syncDown();

            throwIfCanceled();

            syncUp();
        }

        void syncDown()
        {
            SyncState state =  SyncState.Downloading;
            throwIfCanceled();
            updateProgress(0,  state);
            // ...
                throwIfCanceled();
                updateProgress(10,  state);
            // ...
            throwIfCanceled();
            updateProgress(100,  state);
        }

        void syncUp()
        {
            SyncState state =  SyncState.Uploading;
            throwIfCanceled();
            updateProgress(0,  state);
            // ...
                throwIfCanceled();
                updateProgress(35,  state);
            // ...
            throwIfCanceled();
            updateProgress(100,  state);
        }

        private void setupForAsync(CancellationToken newCancelationToken, IProgress<SyncProgress> newProgressReporter)
        {
            cancelationToken = newCancelationToken;
            progressReporter = newProgressReporter;

            // If cancelled, update the progress one last time with 100% Cancelled
            cancelationToken.Register(() =>
            {
                updateProgress(100, SyncState.Canceled);
            });
        }

        void throwIfCanceled()
        {
            cancelationToken.ThrowIfCancellationRequested();
        }

        void updateProgress(int percent, SyncState state)
        {
            progressReporter.Report(new SyncProgress(percent, state));
        }
    }
}

