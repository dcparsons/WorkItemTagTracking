using System;
using System.Windows.Forms;
using ReleaseWITAlert.Lib;

namespace ReleaseWITAlert
{
    public partial class MaintainView : Form, IMaintainView
    {
        public EventHandler GetTags { get; set; }
        public EventHandler SaveProject { get; set; }
        public EventHandler CancelChanges { get; set; }
        public EventHandler ViewClosing { get; set; }

        public TableLayoutPanel AvailableTags
        {
            get => avaialbleTags;
            set => avaialbleTags = value;
        }

        public TableLayoutPanel TrackedTags
        {
            get => trackedTags;
            set => trackedTags = value;
        }
        
        public bool IsDirty { get; set; }

        public string ReleaseProjectName
        {
            get => txtReleaseName.Text;
            set => txtReleaseName.Text = value;
        }

        public string TeamProjectName
        {
            get => txtTeamProjectName.Text;
            set => txtTeamProjectName.Text = value;
        }
        
        public MaintainView()
        {
            InitializeComponent();
        }

        public void ShowView()
        {
            ShowDialog();
        }

        public void CloseView()
        {
            Close();
        }

        private void btnGetTags_Click(object sender, EventArgs e)
        {
            if (GetTags == null) throw new NotImplementedException();
            GetTags(sender,e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveProject == null) throw new NotImplementedException();
            SaveProject(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelChanges == null) throw new NotImplementedException();
            CancelChanges(sender, e);
        }

        private void MaintainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ViewClosing == null) throw new NotImplementedException();
            ViewClosing(sender, e);
        }
    }
}
