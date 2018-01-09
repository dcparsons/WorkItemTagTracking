using System;
using System.Windows.Forms;

namespace ReleaseWITAlert.Lib
{
    internal interface IMainView
    {
        EventHandler LoadProject { get; set; }
        EventHandler AddProject { get; set; }
        EventHandler EditProject { get; set; }
        EventHandler DeleteProject { get; set; }
        EventHandler ModifyConfiguration { get; set; }
        EventHandler TickerElapsed { get; set; }
        EventHandler<DataGridViewCellEventArgs> SetWorkItemsForCurrentProject { get; set; }
        DataGridView ProjectGrid { get; set; }
        ListBox InWits { get; set; }
        ListBox WitHistory { get; set; }

    }
}
