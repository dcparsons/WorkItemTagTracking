using System;
using System.Collections.Generic;
using System.Configuration;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ReleaseWITAlert.Lib
{
    class WorkItemApis : ITFSWorkItems
    {
        private const string WorkItemQueryUrl = "/tfs/hdds/{0}/_apis/wit/wiql?api-version=1.0";
        private const string WorkItemDetailsUrl = "/tfs/hdds/_apis/wit/workitems?ids={0}&fields=System.Id,System.Title,System.State,System.ChangedDate&asOf={1}&api-version=2.2";

        /// <summary>
        /// The use of dynamic inline WIQL is necessary because:
        /// -We can't create (shouldn't) create one off sprocs in the TFS Warehouse
        /// -We can't pass a dynamic where clause to stored queries (as far as my search concluded)
        /// -Microsoft literally provides an API for this type of approach
        /// </summary>
        private const string WorkItemQuery =
       @"SELECT 
            [System.Id], 
            [System.WorkItemType], 
            [System.Title], 
            [System.AssignedTo], 
            [System.State], 
            [System.Tags], 
            [System.ChangedDate] 
        FROM WorkItems
        WHERE[System.TeamProject] = '{0}'
        AND[System.WorkItemType] = 'Product Backlog Item'  
        AND[System.State] <> ''  
        AND( {1} )
        ORDER BY[System.Id]";

        private const string TagWhereStatementFormat = "[System.Tags] CONTAINS '{0}'";
        public JObject GetListOfWorkItemsByTag(string teamProjectName, List<string> tags)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", appSettings["TFSPersonalAccessToken"])));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(appSettings["TFSBaseURL"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var wiql = new
                {
                    query = string.Format(WorkItemQuery, teamProjectName, BuildTagWhereClause(tags))
                };

                var postValue = new StringContent(JsonConvert.SerializeObject(wiql), Encoding.UTF8, "application/json");
                var response = client.PostAsync(string.Format(WorkItemQueryUrl, teamProjectName), postValue).Result;

                if (!response.IsSuccessStatusCode) return null;

                var workItems = response.Content.ReadAsAsync<WorkItemQueryResult>().Result;
                var sb = new StringBuilder();
                foreach (var item in workItems.WorkItems)
                {
                    sb.Append(item.Id.ToString()).Append(",");
                }
                
                var ids = sb.ToString().TrimEnd(new char[] { ',' });

                var getWorkItemsHttpResponse = client.GetAsync(string.Format(WorkItemDetailsUrl, ids, workItems.AsOf)).Result;

                if (!getWorkItemsHttpResponse.IsSuccessStatusCode) return null;

                return JObject.Parse(getWorkItemsHttpResponse.Content.ReadAsStringAsync().Result);
            }
        }

        private string BuildTagWhereClause(List<string> tags)
        {
            var sb = new StringBuilder();

            for (var x = 0; x < tags.Count; x++)
            {
                sb.Append(string.Format(TagWhereStatementFormat, tags[x]));
                if (x + 1 == tags.Count) break;

                sb.Append(" OR ");
            }

            return sb.ToString();
        }
    }
}
