using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ReleaseWITAlert.Lib;

namespace ReleaseWITAlert.Controllers
{
    internal class MaintainController : IMaintainController
    {
        private IMaintainView _view;
        private readonly IProjectOperations _projectOperations;
        private EventHandler mainViewCallback;

        public IMaintainView View
        {
            get
            {
                if (_view != null) return _view;
                _view = ViewFactory.Create();
                SetDefaultViewSettings();
                return _view;
            }
            set => _view = value;
        }

        private IMaintainViewFactory ViewFactory { get; set; }

        private List<string> _trackedTags;

        public MaintainController(IMaintainViewFactory viewFactory, IProjectOperations projectOperations)
        {
            ViewFactory = viewFactory;
            _projectOperations = projectOperations;
        }

        public void ShowView(EventHandler callback)
        {
            mainViewCallback = callback;
            View.ShowView();   
        }

        public void ShowEditView(ITfsProject currentProject, EventHandler callback)
        {
            mainViewCallback = callback;
            SetEditMode(currentProject);
            View.ShowView();
        }

        private void ViewClosing(object sender, EventArgs e)
        {
            View = null;
        }

        private void GetTags(object sender, EventArgs e)
        {
            var outputMessage = string.Empty;
            var tags = _projectOperations.GetTags(View.TeamProjectName, out outputMessage);

            BuildTagButtons(tags, TrackTag, View.AvailableTags);
            if(!string.IsNullOrEmpty(outputMessage)) MessageBox.Show(outputMessage);
        }

        private void SaveProject(object sender, EventArgs e)
        {
            if (_trackedTags.Count == 0)
            {
                MessageBox.Show("You have not selected any tags to track for this project.  You need to track at least one.  Try again.");
                return;
            }

            var outputMessage = string.Empty;
            try
            {
                _projectOperations.SaveProject(View.ReleaseProjectName, View.TeamProjectName, _trackedTags, out outputMessage);
                MessageBox.Show(outputMessage);

                mainViewCallback?.Invoke(this, null);

                View.CloseView();
                View = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelChanges(object sender, EventArgs e)
        {
            View.CloseView();
            View = null;
        }

        private void TrackTag(object sender, EventArgs e)
        {
            MoveButton((Button)sender, TrackTag, UntrackTag, View.AvailableTags, View.TrackedTags);
            _trackedTags.Add(((Button)sender).Text);
        }

        private void UntrackTag(object sender, EventArgs e)
        {
            MoveButton((Button)sender, UntrackTag, TrackTag, View.TrackedTags, View.AvailableTags);
            _trackedTags.Remove(((Button)sender).Text);
        }

        private void BuildTagButtons(List<ITfsTag> tags, EventHandler buttonHandler, TableLayoutPanel tagContainer)
        {
            if (tags == null || tags.Count == 0) return;

            foreach (var tag in tags)
            {
                var btn = new Button
                {
                    AutoSize = true,
                    Name = $"btn_{tag.Id}",
                    Text = tag.Name,
                };
                btn.Click += buttonHandler;
                tagContainer.Controls.Add(btn);
            }
        }

        private void SetDefaultViewSettings()
        {
            View.GetTags += GetTags;
            View.SaveProject += SaveProject;
            View.CancelChanges += CancelChanges;
            View.ViewClosing += ViewClosing;
            _trackedTags = new List<string>();
        }

        private void MoveButton(Button btnToMove, EventHandler handlerToRemove, EventHandler handlerToAdd,
            TableLayoutPanel panelToRemoveFrom, TableLayoutPanel panelToAddTo)
        {
            btnToMove.Click -= handlerToRemove;
            panelToRemoveFrom.Controls.Remove(btnToMove);
            btnToMove.Click += handlerToAdd;
            panelToAddTo.Controls.Add(btnToMove);
        }

        private void SetEditMode(ITfsProject project)
        {
            View.TeamProjectName = project.TeamProjectName;
            View.ReleaseProjectName = project.ProjectName;

            var outputMessage = string.Empty;
            var tags = _projectOperations.GetTags(project.TeamProjectName, out outputMessage);

            if (!string.IsNullOrEmpty(outputMessage))
            {
                MessageBox.Show(outputMessage);

                MessageBox.Show("This window will now close.");

                View.CloseView();
                View = null;
                return;
            }

            var untrackedProjectTags = tags.Where(p => !project.TrackedTags.Contains(p.Name)).ToList();

            var lst = new List<ITfsTag>();
            foreach (var tag in project.TrackedTags)
            {
                lst.Add(_projectOperations.CreateTag(tag));

            }

            BuildTagButtons(untrackedProjectTags, TrackTag, View.AvailableTags);
            BuildTagButtons(lst, UntrackTag, View.AvailableTags);
        }
    }
}
