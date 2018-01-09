using System;
using System.Windows.Forms;
using ReleaseWITAlert.Lib;

namespace ReleaseWITAlert
{
    public partial class Main : Form, IMainView
    {
        public EventHandler LoadProject { get; set; }
        public EventHandler AddProject { get; set; }
        public EventHandler EditProject { get; set; }
        public EventHandler DeleteProject { get; set; }
        public EventHandler ModifyConfiguration { get; set; }
        public EventHandler TickerElapsed { get; set; }
        public EventHandler<DataGridViewCellEventArgs> SetWorkItemsForCurrentProject { get; set; }

        public DataGridView ProjectGrid
        {
            get => projectGrid;
            set => projectGrid = value;
        }

        public ListBox InWits
        {
            get => lbInWit;
            set => lbInWit = value;
        }

        public ListBox WitHistory
        {
            get => lbWitHistory;
            set => lbWitHistory = value;
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if(LoadProject == null) throw new NotImplementedException();
            LoadProject(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddProject == null) throw new NotImplementedException();
            AddProject(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (EditProject == null) throw new NotImplementedException();
            EditProject(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteProject == null) throw new NotImplementedException();
            DeleteProject(sender, e);
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            if (TickerElapsed == null) throw new NotImplementedException();
            TickerElapsed(sender, e);
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            if (ModifyConfiguration == null) throw new NotImplementedException();
            ModifyConfiguration(sender, e);
        }

        private void projectGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (SetWorkItemsForCurrentProject == null) throw new NotImplementedException();
            SetWorkItemsForCurrentProject(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TickerElapsed(sender, e);
        }
    }
}
