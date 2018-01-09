using Newtonsoft.Json.Linq;

namespace ReleaseWITAlert.Lib
{
    interface ITfsTags
    {
        JObject GetListOfActiveTagsForProject(string teamProjectId);
    }
}
