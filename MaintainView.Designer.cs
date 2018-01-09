namespace ReleaseWITAlert
{
    partial class MaintainView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackedTags = new System.Windows.Forms.TableLayoutPanel();
            this.avaialbleTags = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetTags = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTeamProjectName = new System.Windows.Forms.TextBox();
            this.txtReleaseName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackedTags);
            this.groupBox1.Controls.Add(this.avaialbleTags);
            this.groupBox1.Controls.Add(this.btnGetTags);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTeamProjectName);
            this.groupBox1.Controls.Add(this.txtReleaseName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 396);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Settings";
            // 
            // trackedTags
            // 
            this.trackedTags.AutoSize = true;
            this.trackedTags.ColumnCount = 4;
            this.trackedTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.trackedTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.trackedTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.trackedTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.trackedTags.Location = new System.Drawing.Point(10, 242);
            this.trackedTags.Name = "trackedTags";
            this.trackedTags.RowCount = 2;
            this.trackedTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.trackedTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.trackedTags.Size = new System.Drawing.Size(526, 148);
            this.trackedTags.TabIndex = 9;
            // 
            // avaialbleTags
            // 
            this.avaialbleTags.AutoSize = true;
            this.avaialbleTags.ColumnCount = 4;
            this.avaialbleTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.avaialbleTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.avaialbleTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.avaialbleTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.avaialbleTags.Location = new System.Drawing.Point(10, 101);
            this.avaialbleTags.Name = "avaialbleTags";
            this.avaialbleTags.RowCount = 2;
            this.avaialbleTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.avaialbleTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.avaialbleTags.Size = new System.Drawing.Size(526, 100);
            this.avaialbleTags.TabIndex = 8;
            // 
            // btnGetTags
            // 
            this.btnGetTags.Location = new System.Drawing.Point(323, 51);
            this.btnGetTags.Name = "btnGetTags";
            this.btnGetTags.Size = new System.Drawing.Size(66, 23);
            this.btnGetTags.TabIndex = 7;
            this.btnGetTags.Text = "Get Tags";
            this.btnGetTags.UseVisualStyleBackColor = true;
            this.btnGetTags.Click += new System.EventHandler(this.btnGetTags_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tracked Tags:";
            // 
            // txtTeamProjectName
            // 
            this.txtTeamProjectName.Location = new System.Drawing.Point(140, 54);
            this.txtTeamProjectName.Name = "txtTeamProjectName";
            this.txtTeamProjectName.Size = new System.Drawing.Size(177, 20);
            this.txtTeamProjectName.TabIndex = 4;
            // 
            // txtReleaseName
            // 
            this.txtReleaseName.Location = new System.Drawing.Point(140, 28);
            this.txtReleaseName.Name = "txtReleaseName";
            this.txtReleaseName.Size = new System.Drawing.Size(177, 20);
            this.txtReleaseName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Available Tags:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TFS Team Project Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Release Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(480, 421);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(371, 421);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MaintainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 456);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "MaintainView";
            this.Text = "Maintain Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaintainView_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTeamProjectName;
        private System.Windows.Forms.TextBox txtReleaseName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGetTags;
        private System.Windows.Forms.TableLayoutPanel trackedTags;
        private System.Windows.Forms.TableLayoutPanel avaialbleTags;
    }
}