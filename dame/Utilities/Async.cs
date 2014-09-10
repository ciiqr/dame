using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

// Console Requirements
// A console app will not have an async context, therefore we would create one
// https://nitoasyncex.codeplex.com/wikipage?title=AsyncContext

namespace dame.Utilities
{
    public delegate void ASyncLongDelegate(CancellationTokenSource cancellationTokenSource);

    public class Async
    {
        // TODO: Maybe create method to initialize it so we know for sure we will always have a SyncContext, would be called just before runloop
        private static SynchronizationContext mainThreadContext = SynchronizationContext.Current;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void aSync(Action asynchronous)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                asynchronous();
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void main(Action mainCall)
        {
            mainThreadContext.Post(delegate
            {
                mainCall();
            }, null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CancellationTokenSource aSyncLong(ASyncLongDelegate asynchronous)
        {
            var tokenSource = new CancellationTokenSource();

            Task longTask = Task.Factory.StartNew(() => { asynchronous(tokenSource); },
                                tokenSource.Token,
                                TaskCreationOptions.DenyChildAttach | TaskCreationOptions.LongRunning,
                                TaskScheduler.Default);

            longTask.ContinueWith(delegate
            {
                tokenSource.Dispose();
            });

            #if DEBUG
            longTask.ContinueWith((t) =>
            {
                Console.WriteLine("Async Exception: {0}", t.Exception.InnerExceptions);

            });
            #endif

            return tokenSource;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cancel(CancellationTokenSource cancelationTokenSource)
        {
            bool shouldThrowExceptions = false;
            cancelationTokenSource.Cancel(shouldThrowExceptions);
        }

    }
}

