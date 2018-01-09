using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using Newtonsoft.Json.Linq;

namespace ReleaseWITAlert.Lib
{
    class TagApis : ITfsTags
    {
        private const string ActiveTagsForTeamProjectUrl = "/tfs/hdds/_apis/tagging/scopes/{0}/tags?api-version=1.0";
        public JObject GetListOfActiveTagsForProject(string teamProjectId)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", appSettings["TFSPersonalAccessToken"])));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(appSettings["TFSBaseURL"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var response = client.GetAsync(string.Format(ActiveTagsForTeamProjectUrl, teamProjectId)).Result;

                if (!response.IsSuccessStatusCode) return null;

                return JObject.Parse(response.Content.ReadAsStringAsync().Result);

            }
        }

    }
}
