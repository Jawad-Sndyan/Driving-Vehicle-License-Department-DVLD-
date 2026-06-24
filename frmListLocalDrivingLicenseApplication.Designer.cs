namespace DVLD
{
    partial class frmListLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListLocalDrivingLicenseApplication));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLDLApp = new System.Windows.Forms.DataGridView();
            this.lblRecords = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAddLDLApp = new System.Windows.Forms.Button();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.colLDLAppID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrivingClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassedTests = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApp)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(368, 40);
            this.editToolStripMenuItem.Text = "Edit Appliaction";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // addNewApplicationToolStripMenuItem
            // 
            this.addNewApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.New_Application_64;
            this.addNewApplicationToolStripMenuItem.Name = "addNewApplicationToolStripMenuItem";
            this.addNewApplicationToolStripMenuItem.Size = new System.Drawing.Size(368, 40);
            this.addNewApplicationToolStripMenuItem.Text = "Add New Application";
            this.addNewApplicationToolStripMenuItem.Click += new System.EventHandler(this.addNewApplicationToolStripMenuItem_Click);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showApplicationDetailsToolStripMenuItem.Image")));
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(368, 40);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // cms
            // 
            this.cms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.cms.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.addNewApplicationToolStripMenuItem,
            this.editToolStripMenuItem,
            this.CancelApplicationToolStripMenuItem});
            this.cms.Name = "contextMenuStrip1";
            this.cms.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cms.Size = new System.Drawing.Size(369, 164);
            // 
            // CancelApplicationToolStripMenuItem
            // 
            this.CancelApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CancelApplicationToolStripMenuItem.Image")));
            this.CancelApplicationToolStripMenuItem.Name = "CancelApplicationToolStripMenuItem";
            this.CancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(368, 40);
            this.CancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.CancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.CancelApplicationToolStripMenuItem_Click);
            // 
            // dgvLDLApp
            // 
            this.dgvLDLApp.AllowUserToAddRows = false;
            this.dgvLDLApp.AllowUserToDeleteRows = false;
            this.dgvLDLApp.AllowUserToOrderColumns = true;
            this.dgvLDLApp.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.dgvLDLApp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLDLApp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLDLApp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLDLApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLDLApp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLDLAppID,
            this.colDrivingClass,
            this.colNationalNo,
            this.colFullName,
            this.colPassedTests,
            this.colStatus});
            this.dgvLDLApp.ContextMenuStrip = this.cms;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLDLApp.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLDLApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLDLApp.EnableHeadersVisualStyles = false;
            this.dgvLDLApp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.dgvLDLApp.Location = new System.Drawing.Point(0, 446);
            this.dgvLDLApp.Name = "dgvLDLApp";
            this.dgvLDLApp.ReadOnly = true;
            this.dgvLDLApp.RowHeadersVisible = false;
            this.dgvLDLApp.RowHeadersWidth = 82;
            this.dgvLDLApp.RowTemplate.Height = 45;
            this.dgvLDLApp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLDLApp.Size = new System.Drawing.Size(2324, 713);
            this.dgvLDLApp.TabIndex = 11;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.lblRecords.Location = new System.Drawing.Point(291, 27);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(74, 31);
            this.lblRecords.TabIndex = 10;
            this.lblRecords.Text = "????";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnClose.ForeColor = System.Drawing.Color.LightPink;
            this.btnClose.Location = new System.Drawing.Point(2049, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(272, 70);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.LightPink;
            this.label8.Location = new System.Drawing.Point(23, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 31);
            this.label8.TabIndex = 8;
            this.label8.Text = "# Records: ";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblRecords);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.Location = new System.Drawing.Point(3, 27);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(395, 70);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 1159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(2324, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // cbSearch
            // 
            this.cbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "New",
            "Cancelled",
            "Completed"});
            this.cbSearch.Location = new System.Drawing.Point(603, 50);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(695, 50);
            this.cbSearch.TabIndex = 8;
            this.cbSearch.Visible = false;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.txtSearch.Location = new System.Drawing.Point(603, 51);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(376, 49);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnAddLDLApp
            // 
            this.btnAddLDLApp.BackgroundImage = global::DVLD.Properties.Resources.New_Application_64;
            this.btnAddLDLApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddLDLApp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddLDLApp.Location = new System.Drawing.Point(2194, 27);
            this.btnAddLDLApp.Name = "btnAddLDLApp";
            this.btnAddLDLApp.Size = new System.Drawing.Size(127, 96);
            this.btnAddLDLApp.TabIndex = 0;
            this.btnAddLDLApp.UseVisualStyleBackColor = true;
            this.btnAddLDLApp.Click += new System.EventHandler(this.btnAddLDLApp_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cbFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(217, 50);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(313, 50);
            this.cbFilter.TabIndex = 6;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 42);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter by";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbSearch);
            this.groupBox4.Controls.Add(this.txtSearch);
            this.groupBox4.Controls.Add(this.btnAddLDLApp);
            this.groupBox4.Controls.Add(this.cbFilter);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(2324, 126);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DVLD.Properties.Resources.Applications;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(1085, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 155);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.LightPink;
            this.label1.Location = new System.Drawing.Point(817, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(690, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Driving License Application";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2324, 320);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::DVLD.Properties.Resources.Local_32;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(1221, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // colLDLAppID
            // 
            this.colLDLAppID.HeaderText = "L.D.L.AppID";
            this.colLDLAppID.MinimumWidth = 10;
            this.colLDLAppID.Name = "colLDLAppID";
            this.colLDLAppID.ReadOnly = true;
            // 
            // colDrivingClass
            // 
            this.colDrivingClass.HeaderText = "Driving Class";
            this.colDrivingClass.MinimumWidth = 10;
            this.colDrivingClass.Name = "colDrivingClass";
            this.colDrivingClass.ReadOnly = true;
            this.colDrivingClass.Width = 300;
            // 
            // colNationalNo
            // 
            this.colNationalNo.HeaderText = "National No.";
            this.colNationalNo.MinimumWidth = 10;
            this.colNationalNo.Name = "colNationalNo";
            this.colNationalNo.ReadOnly = true;
            this.colNationalNo.Width = 200;
            // 
            // colFullName
            // 
            this.colFullName.HeaderText = "Full Name";
            this.colFullName.MinimumWidth = 10;
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 300;
            // 
            // colPassedTests
            // 
            this.colPassedTests.HeaderText = "Passed Tests";
            this.colPassedTests.MinimumWidth = 10;
            this.colPassedTests.Name = "colPassedTests";
            this.colPassedTests.ReadOnly = true;
            this.colPassedTests.Width = 110;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 10;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 150;
            // 
            // frmListLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(2324, 1259);
            this.Controls.Add(this.dgvLDLApp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.LightPink;
            this.MaximumSize = new System.Drawing.Size(2350, 1330);
            this.MinimumSize = new System.Drawing.Size(2350, 1330);
            this.Name = "frmListLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListLocalDrivingLicenseApplication";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListLocalDrivingLicenseApplication_Load);
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApp)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem CancelApplicationToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvLDLApp;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddLDLApp;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLDLAppID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrivingClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassedTests;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}