using System.Collections.Generic;

using Newtonsoft.Json.Linq;

namespace ReleaseWITAlert.Lib
{
    interface ITFSWorkItems
    {
        JObject GetListOfWorkItemsByTag(string teamProjectName, List<string> tags);
    }
}
