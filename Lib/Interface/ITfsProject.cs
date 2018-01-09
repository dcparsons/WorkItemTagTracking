using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ReleaseWITAlert.Models;

namespace ReleaseWITAlert.Lib
{
    [JsonConverter(typeof(ConfigConverter<ITfsProject, TfsProject>))]
    internal interface ITfsProject
    {
        string ProjectName { get; set; }
        string TeamProjectName { get; set; }
        List<string> TrackedTags { get; set; }
        List<ITfsWit> InWits { get; set; }
        List<ITfsWit> WitHistory { get; set; }
        DateTime LastPolled { get; set; }
        string FormattedTrackedTags { get; }
        string FileName { get; set; }
        bool HasNewHistory { get; set; }

        string GetHistoryForEmail();

    }
}
