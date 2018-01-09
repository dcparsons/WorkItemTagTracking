using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ReleaseWITAlert.Lib
{
    internal class ProjectApis : ITfsTeamProjects
    {
        private const string TeamProjectByNameUrl = "/tfs/hdds/_apis/projects/{0}?api-version=1.0";
        public string GetTeamProjectId(string teamProjectName)
        {            
            var appSettings = ConfigurationManager.AppSettings;
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", appSettings["TFSPersonalAccessToken"])));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(appSettings["TFSBaseURL"]);  
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var response = client.GetAsync(string.Format(TeamProjectByNameUrl, teamProjectName)).Result;

                if (!response.IsSuccessStatusCode) return string.Empty;

                var value = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                return (string)value["id"];
            }
        }
    }
}
