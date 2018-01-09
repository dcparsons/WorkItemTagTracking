using System;
using System.Windows.Forms;

namespace ReleaseWITAlert.Lib
{
    internal interface IMaintainView
    {
        EventHandler GetTags { get; set; }
        EventHandler SaveProject { get; set; }
        EventHandler CancelChanges { get; set; }
        EventHandler ViewClosing { get; set; }
        bool IsDirty { get; set; }

        TableLayoutPanel AvailableTags { get; set; }
        TableLayoutPanel TrackedTags { get; set; }

        string ReleaseProjectName { get; set; }
        string TeamProjectName { get; set; }
        void ShowView();
        void CloseView();
    }
}
