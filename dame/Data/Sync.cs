using System;
using System.Threading;
using System.Globalization;

using Evernote;
using UserStoreConstants = Evernote.EDAM.UserStore.Constants;
using Evernote.EDAM.Type;
using Evernote.EDAM.UserStore;
using Evernote.EDAM.NoteStore;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;

namespace dame.Data.Sync
{
    public delegate void InitialSyncComplete(User user, PremiumInfo premiumInfo);

    public class Sync
    {
        private const string EVERNOTE_HOST = "www.evernote.com";
        private const string EVERNOTE_SANDBOX_HOST = "sandbox.evernote.com";
        private const string EVERNOTE_CLIENT_KEY = "willvill1995";
        private const string EVERNOTE_CLIENT_SECRET = "d6a66c2726aa3a42";

        public event InitialSyncComplete InitialSyncCompleteHandler;

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

            // TODO: This will fail without internet access
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

                PremiumInfo premiumInfo = getPremiumInfo(user);

                throwIfCanceled();
                updateProgress(99, SyncState.Downloading);

                // TODO: We will call out an event when this is done
                Console.WriteLine("User:" + user);
                Console.WriteLine("User Premium:" + premiumInfo);

                throwIfCanceled();
                updateProgress(100, SyncState.Downloading);

                // TODO: Do I want to change to return?
                InitialSyncCompleteHandler(user, premiumInfo);
            }
            else
            {
                Console.WriteLine("The client's evernote sdk version is out of date!");

                // TODO: event with failed reason
                InitialSyncCompleteHandler(null, null);
            }
        }

        public PremiumInfo getPremiumInfo(User user)
        {
            PremiumInfo premiumInfo = null;
            if (user.Privilege != PrivilegeLevel.NORMAL)
                premiumInfo = userStore.getPremiumInfo(authToken);
            return premiumInfo;
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

