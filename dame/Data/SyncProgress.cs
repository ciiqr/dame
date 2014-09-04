using System;

namespace dame.Data.Sync
{
    public struct SyncProgress
    {
        public int percent;
        public SyncState state;

        public SyncProgress(int percent, SyncState state) 
        {
            this.percent = percent;
            this.state = state;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}%", state, percent);
        }
    }
}

