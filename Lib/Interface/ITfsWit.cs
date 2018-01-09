using System;
using Newtonsoft.Json;
using ReleaseWITAlert.Models;

namespace ReleaseWITAlert.Lib
{
    [JsonConverter(typeof(ConfigConverter<ITfsWit, TfsWit>))]
    internal interface ITfsWit : IComparable<ITfsWit>
    {
        int ID { get; set; }
        string Description { get; set; }
        TfsWitState State { get; set; }
        DateTime ModifiedDateTime { get; set; }

        string FriendlyName { get; }

        string HistoryState { get; }
    }
}