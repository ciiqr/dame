using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

// Console Requirements
// A console app will not have an async context, therefore we would create one
// https://nitoasyncex.codeplex.com/wikipage?title=AsyncContext

namespace Utilities
{
    public class Async
    {
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
            SynchronizationContext.Current.Post(delegate
            {
                mainCall();
            }, null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CancellationTokenSource aSyncLong(Action asynchronous)
        {
            var tokenSource = new CancellationTokenSource();

            Task longTask = Task.Factory.StartNew(asynchronous,
                                tokenSource.Token,
                                TaskCreationOptions.DenyChildAttach | TaskCreationOptions.LongRunning,
                                TaskScheduler.Default);

            longTask.ContinueWith(delegate
            {
                tokenSource.Dispose();
            });


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

