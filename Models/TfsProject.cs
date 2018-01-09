using System;
using System.Collections.Generic;
using System.Text;
using ReleaseWITAlert.Lib;

namespace ReleaseWITAlert.Models
{
    internal class TfsProject : ITfsProject
    {
        public string ProjectName { get; set; }
        public string TeamProjectName { get; set; }
        public List<string> TrackedTags { get; set; }
        public List<ITfsWit> InWits { get; set; }
        public List<ITfsWit> WitHistory { get; set; }
        public DateTime LastPolled { get; set; }
        public string FileName { get; set; }
        public bool HasNewHistory { get; set; }
        public string FormattedTrackedTags => string.Join(", ", TrackedTags.ToArray());

        public string GetHistoryForEmail()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Project Name: {ProjectName}");
            sb.AppendLine($"Last Polled: {LastPolled}");

            foreach (var item in WitHistory)
            {
                sb.AppendLine(item.HistoryState);
            }
            sb.AppendLine("----------------END PROJECT------------------");

            HasNewHistory = false;
            return sb.ToString();
        }
    }
}
