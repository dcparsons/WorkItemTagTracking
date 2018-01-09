namespace ReleaseWITAlert
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.projectGrid = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbInWit = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbWitHistory = new System.Windows.Forms.ListBox();
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.projectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamProjectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formattedTrackedTagsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPolledDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfsProjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tfsProjectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.projectGrid);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(612, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tracked Projects";
            // 
            // projectGrid
            // 
            this.projectGrid.AllowUserToAddRows = false;
            this.projectGrid.AllowUserToDeleteRows = false;
            this.projectGrid.AllowUserToResizeColumns = false;
            this.projectGrid.AutoGenerateColumns = false;
            this.projectGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.projectGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.projectNameDataGridViewTextBoxColumn,
            this.teamProjectNameDataGridViewTextBoxColumn,
            this.formattedTrackedTagsDataGridViewTextBoxColumn,
            this.lastPolledDataGridViewTextBoxColumn});
            this.projectGrid.DataSource = this.tfsProjectBindingSource;
            this.projectGrid.Location = new System.Drawing.Point(6, 19);
            this.projectGrid.Name = "projectGrid";
            this.projectGrid.ReadOnly = true;
            this.projectGrid.Size = new System.Drawing.Size(600, 140);
            this.projectGrid.TabIndex = 4;
            this.projectGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectGrid_CellEnter);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(432, 164);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(69, 19);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "&Edit Project";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(506, 164);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 19);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "&Delete Project";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(333, 164);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 19);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Add Project";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbInWit);
            this.groupBox2.Location = new System.Drawing.Point(10, 204);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(314, 218);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "\"In\" WIT\'s";
            // 
            // lbInWit
            // 
            this.lbInWit.DisplayMember = "FriendlyName";
            this.lbInWit.FormattingEnabled = true;
            this.lbInWit.Location = new System.Drawing.Point(6, 19);
            this.lbInWit.Name = "lbInWit";
            this.lbInWit.Size = new System.Drawing.Size(303, 186);
            this.lbInWit.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbWitHistory);
            this.groupBox3.Location = new System.Drawing.Point(328, 204);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(294, 218);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Most Recent Changes";
            // 
            // lbWitHistory
            // 
            this.lbWitHistory.DisplayMember = "HistoryState";
            this.lbWitHistory.FormattingEnabled = true;
            this.lbWitHistory.Location = new System.Drawing.Point(5, 19);
            this.lbWitHistory.Name = "lbWitHistory";
            this.lbWitHistory.Size = new System.Drawing.Size(283, 186);
            this.lbWitHistory.TabIndex = 1;
            // 
            // tmr1
            // 
            this.tmr1.Enabled = true;
            this.tmr1.Interval = 3600000;
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.Location = new System.Drawing.Point(444, 426);
            this.btnConfiguration.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(178, 21);
            this.btnConfiguration.TabIndex = 3;
            this.btnConfiguration.Text = "Modify Configuration";
            this.btnConfiguration.UseVisualStyleBackColor = true;
            this.btnConfiguration.Click += new System.EventHandler(this.btnConfiguration_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Test Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // projectNameDataGridViewTextBoxColumn
            // 
            this.projectNameDataGridViewTextBoxColumn.DataPropertyName = "ProjectName";
            this.projectNameDataGridViewTextBoxColumn.HeaderText = "Project Name";
            this.projectNameDataGridViewTextBoxColumn.Name = "projectNameDataGridViewTextBoxColumn";
            this.projectNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // teamProjectNameDataGridViewTextBoxColumn
            // 
            this.teamProjectNameDataGridViewTextBoxColumn.DataPropertyName = "TeamProjectName";
            this.teamProjectNameDataGridViewTextBoxColumn.HeaderText = "Project Name";
            this.teamProjectNameDataGridViewTextBoxColumn.Name = "teamProjectNameDataGridViewTextBoxColumn";
            this.teamProjectNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formattedTrackedTagsDataGridViewTextBoxColumn
            // 
            this.formattedTrackedTagsDataGridViewTextBoxColumn.DataPropertyName = "FormattedTrackedTags";
            this.formattedTrackedTagsDataGridViewTextBoxColumn.HeaderText = "Tracked Tags";
            this.formattedTrackedTagsDataGridViewTextBoxColumn.Name = "formattedTrackedTagsDataGridViewTextBoxColumn";
            this.formattedTrackedTagsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastPolledDataGridViewTextBoxColumn
            // 
            this.lastPolledDataGridViewTextBoxColumn.DataPropertyName = "LastPolled";
            this.lastPolledDataGridViewTextBoxColumn.HeaderText = "Last Polled";
            this.lastPolledDataGridViewTextBoxColumn.Name = "lastPolledDataGridViewTextBoxColumn";
            this.lastPolledDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tfsProjectBindingSource
            // 
            this.tfsProjectBindingSource.DataSource = typeof(ReleaseWITAlert.Models.TfsProject);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 455);
            this.Controls.Add(this.btnConfiguration);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "WIT Tracking by Tag";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projectGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tfsProjectBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.Button btnConfiguration;
        private System.Windows.Forms.DataGridView projectGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamProjectNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formattedTrackedTagsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPolledDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource tfsProjectBindingSource;
        private System.Windows.Forms.ListBox lbInWit;
        private System.Windows.Forms.ListBox lbWitHistory;
        private System.Windows.Forms.Button button1;
    }
}

