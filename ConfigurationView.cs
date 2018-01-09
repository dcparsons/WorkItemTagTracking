using System;
using System.Windows.Forms;
using ReleaseWITAlert.Lib;

namespace ReleaseWITAlert
{
    public partial class ConfigurationView : Form, IConfigurationView
    {
        public EventHandler SaveSettings { get; set; }
        public EventHandler CancelChanges { get; set; }

        public string TFSUrl
        {
            get => txtTfsBaseUrl.Text;
            set => txtTfsBaseUrl.Text = value; 
        }

        public string TFSPAT
        {
            get => txtTfsPAT.Text;
            set => txtTfsPAT.Text = value;
        }

        public string EmailAddress
        {
            get => txtEmailAddress.Text;
            set => txtEmailAddress.Text = value;
        }

        public ConfigurationView()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveSettings == null) throw new NotImplementedException();
            SaveSettings(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelChanges == null) throw new NotImplementedException();
            CancelChanges(sender, e);
        }
        public void ShowView()
        {
            ShowDialog();
        }

        public void CloseView()
        {
            Close();
        }
    }
}
