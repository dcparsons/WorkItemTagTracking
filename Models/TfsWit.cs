using System;
using ReleaseWITAlert.Lib;

namespace ReleaseWITAlert.Models
{
    internal class TfsWit : ITfsWit
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public TfsWitState State { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public string FriendlyName => $"{ID} - {Description.Substring(0, Description.Length < 30 ? Description.Length : 30)} ...";

        public string HistoryState => $"{ID} - changed to {State.ToString("G")}";

        public int CompareTo(ITfsWit compareWit)
        {
            if (compareWit == null) return 1;
            return this.ID.CompareTo(compareWit.ID);
        }
    }

internal enum TfsWitState
    {

        Added = 0,
        Removed = 1
    }
}
