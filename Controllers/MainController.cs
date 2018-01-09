using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using ReleaseWITAlert.Lib;

namespace ReleaseWITAlert.Controllers
{
    internal class MainController : IMainController
    {
        public IMainView View { get; set; }

        private IMaintainController _maintainController;
        private IMaintainController MaintainController
        {
            get
            {
                if (_maintainController != null) return _maintainController;
                _maintainController = MaintainFactory.Create();
                return _maintainController;
            }
        }
        private IMaintainFactory MaintainFactory { get; }

        private IConfigurationController _configurationController;
        private IConfigurationController ConfigurationController
        {
            get
            {
                if (_configurationController != null) return _configurationController;
                _configurationController = ConfigurationFactory.Create();
                return _configurationController;
            }
        }
        private IConfigurationFactory ConfigurationFactory { get; }
        private List<ITfsProject> _currentProjects;
        private readonly IProjectOperations _projectOperations;
        private readonly IEmailServer _smtpServer;

        public MainController(IMainView view, IMaintainFactory matinainFactory, IConfigurationFactory configurationFactory, 
            IProjectOperations projectOperations, IEmailServer emailServer)
        {
            View = view;
            MaintainFactory = matinainFactory;
            ConfigurationFactory = configurationFactory;

            View.LoadProject += LoadProject;
            View.AddProject += AddProject;
            View.DeleteProject += DeleteProject;
            View.SetWorkItemsForCurrentProject += SetWorkItemsForCurrentProject;
            View.ModifyConfiguration += ModifyConfiguration;
            View.TickerElapsed += RefreshProjects;
            View.EditProject += EditProject;
            _projectOperations = projectOperations;
            _smtpServer = emailServer;
        }

        private void AddProject(object sender, EventArgs e)
        {
            MaintainController.ShowView(LoadProject);
        }

        private void EditProject(object sender, EventArgs e)
        {
            if (View.ProjectGrid.CurrentRow == null)
            {
                MessageBox.Show($"Please select a project from the grid to edit.");
                return;
            }

            var currentProject = (ITfsProject)View.ProjectGrid.Rows[View.ProjectGrid.CurrentRow.Index].DataBoundItem;

            MaintainController.ShowEditView(currentProject, LoadProject);
        }

        private void DeleteProject(object sender, EventArgs e)
        {
            if (View.ProjectGrid.CurrentRow == null)
            {
                MessageBox.Show($"Please select a project from the grid to delete.");
                return;
            }

            var currentProject = (ITfsProject)View.ProjectGrid.Rows[View.ProjectGrid.CurrentRow.Index].DataBoundItem;

            if (MessageBox.Show($"Do you really want to delete the project: {currentProject.ProjectName}?",
                    "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            _projectOperations.DeleteProject(currentProject);

            View.InWits.DataSource = null;
            View.WitHistory.DataSource = null;

            LoadProject(this, null);
        }

        private void ModifyConfiguration(object sender, EventArgs e)
        {
            ConfigurationController.Show();
        }

        private void LoadProject(object sender, EventArgs e)
        {
            View.ProjectGrid.DataSource = LoadProjectFiles();
            if (View.ProjectGrid.Rows.Count == 0) return;

            View.ProjectGrid.Rows[0].Selected = true;
            SetWorkItemsForCurrentProject(null, null);

        }

        private void RefreshProjects(object sender, EventArgs e)
        {
            foreach (var project in _currentProjects)
            {
                _projectOperations.UpdateProject(project);
            }
            LoadProject(null, null);
            SendStatusEmail();
        }

        private void SendStatusEmail()
        {
            var changedProjects = _currentProjects.Where(x => x.HasNewHistory).ToList();
            var sb = new StringBuilder();
            foreach (var project in changedProjects)
            {
                sb.AppendLine(project.GetHistoryForEmail());
            }
            _smtpServer.SendEmail(sb.ToString());
        }

        private List<ITfsProject> LoadProjectFiles()
        {
            var files = Directory.GetFiles(Constants.ProjectFolderPath);
            _currentProjects = new List<ITfsProject>();

            foreach (var file in files)
            {
                using (var f = File.OpenText(file))
                {
                    var serializer = new JsonSerializer();
                    var project = (ITfsProject)serializer.Deserialize(f, typeof(ITfsProject));
                    _currentProjects.Add(project);
                }
            }
            return _currentProjects;
        }

        private void SetWorkItemsForCurrentProject(object sender, DataGridViewCellEventArgs e)
        {
            if (View.ProjectGrid.CurrentRow == null) return;

            var currentRow = (ITfsProject)View.ProjectGrid.Rows[View.ProjectGrid.CurrentRow.Index].DataBoundItem;

            View.InWits.DisplayMember = "FriendlyName";
            View.WitHistory.DisplayMember = "HistoryState";

            View.InWits.DataSource = currentRow.InWits;
            View.WitHistory.DataSource = currentRow.WitHistory;
        }
    }
}
