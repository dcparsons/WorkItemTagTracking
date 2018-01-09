using System;

namespace ReleaseWITAlert.Lib
{
    internal interface IConfigurationView
    {
        EventHandler SaveSettings { get; set; }
        EventHandler CancelChanges { get; set; }
        string TFSUrl { get; set; }
        string TFSPAT { get; set; }
        string EmailAddress { get; set; }

        void ShowView();
        void CloseView();
    }
}
