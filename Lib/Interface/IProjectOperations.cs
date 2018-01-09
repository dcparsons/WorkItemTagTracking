using System.Collections.Generic;

namespace ReleaseWITAlert.Lib
{
    internal interface IProjectOperations
    {
        void SaveProject(string projectName, string teamProjectName, List<string> trackedTags, out string outputMessage);
        void UpdateProject(ITfsProject project);
        void DeleteProject(ITfsProject project);
        List<ITfsTag> GetTags(string teamProjectName, out string outputMessage);
        ITfsTag CreateTag(string tagName);
    }
}