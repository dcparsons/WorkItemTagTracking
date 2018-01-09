using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReleaseWITAlert.Models;

namespace ReleaseWITAlert.Lib
{
    internal class ProjectOperations : IProjectOperations
    {
        private readonly ITfsWitFactory _witFactory;
        private readonly ITfsTagFactory _tagFactory;
        private readonly ITfsProjectFactory _projectFactory;
        private readonly ITfsTags _tagApis;
        private readonly ITfsTeamProjects _projectApis;
        private readonly ITFSWorkItems _workItemApis;
        private readonly IEmailServer _smtpServer;


        public ProjectOperations(ITfsWitFactory witFactory, ITfsProjectFactory projectFactory, ITfsTagFactory tagFactory, 
            ITfsTags tagApis, ITfsTeamProjects projectApis, ITFSWorkItems workItemApis)
        {
            _witFactory = witFactory;
            _projectFactory = projectFactory;
            _tagFactory = tagFactory;

            _tagApis = tagApis;
            _projectApis = projectApis;
            _workItemApis = workItemApis;
        }

        public void SaveProject(string projectName, string teamProjectName, List<string> trackedTags, out string outputMessage)
        {
            outputMessage = string.Empty;

            var workItems = _workItemApis.GetListOfWorkItemsByTag(teamProjectName, trackedTags);

            var project = _projectFactory.Create();
            project.ProjectName = projectName;
            project.TeamProjectName = teamProjectName;
            project.TrackedTags = trackedTags;
            project.InWits = BuildWorkItems(workItems);
            project.WitHistory = project.InWits;
            project.LastPolled = DateTime.Now;

            WriteFile(project);
            outputMessage =
                $"Project saved successfully. Based on the selected tags, there are currently {project.InWits.Count} work items being tracked.";

        }

        public void UpdateProject(ITfsProject project)
        {
            var workItems = _workItemApis.GetListOfWorkItemsByTag(project.TeamProjectName, project.TrackedTags);
            SetProjectHistory(project, BuildWorkItems(workItems));

            project.LastPolled = DateTime.Now;
            project.InWits.Sort();
            project.WitHistory.Sort();

            using (var file = File.CreateText(project.FileName))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, project);
            }
        }

        public void DeleteProject(ITfsProject project)
        {
            File.Delete(project.FileName);
        }

        public List<ITfsTag> GetTags(string teamProjectName, out string outputMessage)
        {
            outputMessage = string.Empty;
            try
            {
                var teamProjectId = _projectApis.GetTeamProjectId(teamProjectName);
                if (string.IsNullOrEmpty(teamProjectId))
                {
                    outputMessage = $"A team project with the name {teamProjectName} could not be found.";
                    return null;
                }

                var tags = _tagApis.GetListOfActiveTagsForProject(teamProjectId);
                if (tags == null)
                {
                    outputMessage = $"A problem occured while getting tags for the Team Project with the name {teamProjectName}";
                    return null;
                }

                return BuildTags(tags);
            }
            catch (Exception ex)
            {
                outputMessage = ex.Message;
                return null;
            }
        }

        public ITfsTag CreateTag(string tagName)
        {
            var tag = _tagFactory.Create();
            tag.Name = tagName;
            tag.Id = Guid.NewGuid().ToString("N");
            return tag;
        }

        private void SetProjectHistory(ITfsProject project, List<ITfsWit> workItems)
        {
            var currentProjectIds = new HashSet<int>(project.InWits.Select(p => p.ID));
            var currentTfsProjectIds = new HashSet<int>(workItems.Select(p => p.ID));

            var addedItems = workItems.Where(p => !currentProjectIds.Contains(p.ID)).ToList();
            var removedItems = project.InWits.Where(p => !currentTfsProjectIds.Contains(p.ID)).ToList();

            if ((addedItems.Count + removedItems.Count) == 0) return;

            var newHistory = new List<ITfsWit>();

            foreach (var item in addedItems)
            {
                project.InWits.Add(item);
                item.State = TfsWitState.Added;
                newHistory.Add(item);
            }

            foreach (var item in removedItems)
            {
                item.State = TfsWitState.Removed;
                project.InWits.Remove(item);
                newHistory.Add(item);
            }

            project.WitHistory = newHistory;
            project.HasNewHistory = true;
        }

        private List<ITfsWit> BuildWorkItems(JObject workItems)
        {
            var lst = new List<ITfsWit>(); 
            if (workItems == null) return lst;

            var items = from x in workItems["value"]
                select new { fields = x["fields"] };

            foreach (var item in items)
            {
                var wit = _witFactory.Create();
                wit.ID = (int)item.fields["System.Id"];
                wit.Description = (string)item.fields["System.Title"];
                wit.ModifiedDateTime = (DateTime)item.fields["System.ChangedDate"];
                wit.State = TfsWitState.Added;
                lst.Add(wit);
            }

            return lst;
        }

        private List<ITfsTag> BuildTags(JObject tags)
        {
            var query = from x in tags["value"]
                select new { id = (string)x["id"], Name = (string)x["name"] };

            var lst = new List<ITfsTag>();
            foreach (var tag in query.ToList())
            {
                var tfsTag = _tagFactory.Create();
                tfsTag.Id = tag.id;
                tfsTag.Name = tag.Name;
                lst.Add(tfsTag);
            }

            return lst;
        }

        private void WriteFile(ITfsProject project)
        {
            var path = Constants.ProjectFolderPath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fileName = $"{path}{project.ProjectName}.json";

            if (File.Exists(fileName))
            {
                throw new Exception(
                    $"A file with the name {project.ProjectName} already exists.  Please select another project name.");
            }

            using (var file = File.CreateText(fileName))
            {
                project.FileName = fileName;
                var serializer = new JsonSerializer();
                serializer.Serialize(file, project);
            }
        }
    }
}
