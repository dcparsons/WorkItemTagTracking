using System;
using System.Configuration;

using ReleaseWITAlert.Lib;

namespace ReleaseWITAlert.Controllers
{
    internal class ConfigurationController : IConfigurationController
    {
        public IConfigurationView View { get; set; }

        public ConfigurationController(IConfigurationView view)
        {
            View = view;
            View.SaveSettings += SaveSettings;
            View.CancelChanges += CloseView;
        }

        public void Show()
        {
            GetConfigurationData();
            View.ShowView();
        }

        private void SaveSettings(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["TFSBaseURL"].Value = View.TFSUrl;
            config.AppSettings.Settings["TFSPersonalAccessToken"].Value = View.TFSPAT;
            config.AppSettings.Settings["SMTPServerToAddress"].Value = View.EmailAddress;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
            View.CloseView();
        }

        private void CloseView(object sender, EventArgs e)
        {
            View.CloseView();
        }

        private void GetConfigurationData()
        {
            var appSettings = ConfigurationManager.AppSettings;
            View.TFSUrl = appSettings["TFSBaseURL"]; 
            View.TFSPAT = appSettings["TFSPersonalAccessToken"];
            View.EmailAddress = appSettings["SMTPServerToAddress"];
        }
    }
}
