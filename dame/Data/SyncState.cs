using System;

namespace dame.Data.Sync
{
    public enum SyncState
    {
        Finished,
        Downloading,
        Uploading,
        Merging,
        Canceled,
    }

//    public static class SyncStateExtensions
//    {
//        public static String toString(this SyncState state)
//        {
//            return Enum.GetName(typeof(SyncState), state);
//        }
//    }
}

