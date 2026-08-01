namespace DVLD
{
    partial class ucDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcDriverLicensesInfo = new System.Windows.Forms.TabControl();
            this.tpLocalLicense = new System.Windows.Forms.TabPage();
            this.dgvLocalDriverLicenses = new System.Windows.Forms.DataGridView();
            this.colLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cms1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLocalLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpInternationalLicense = new System.Windows.Forms.TabPage();
            this.dgvInternationalDriverLicenses = new System.Windows.Forms.DataGridView();
            this.colInternationalLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cms2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInternationalLisenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tcDriverLicensesInfo.SuspendLayout();
            this.tpLocalLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDriverLicenses)).BeginInit();
            this.cms1.SuspendLayout();
            this.tpInternationalLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDriverLicenses)).BeginInit();
            this.cms2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcDriverLicensesInfo
            // 
            this.tcDriverLicensesInfo.AccessibleName = " ";
            this.tcDriverLicensesInfo.Controls.Add(this.tpLocalLicense);
            this.tcDriverLicensesInfo.Controls.Add(this.tpInternationalLicense);
            this.tcDriverLicensesInfo.Location = new System.Drawing.Point(7, 57);
            this.tcDriverLicensesInfo.Name = "tcDriverLicensesInfo";
            this.tcDriverLicensesInfo.SelectedIndex = 0;
            this.tcDriverLicensesInfo.Size = new System.Drawing.Size(2632, 571);
            this.tcDriverLicensesInfo.TabIndex = 74;
            this.tcDriverLicensesInfo.UseWaitCursor = true;
            // 
            // tpLocalLicense
            // 
            this.tpLocalLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.tpLocalLicense.Controls.Add(this.dgvLocalDriverLicenses);
            this.tpLocalLicense.Location = new System.Drawing.Point(8, 45);
            this.tpLocalLicense.Name = "tpLocalLicense";
            this.tpLocalLicense.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicense.Size = new System.Drawing.Size(2616, 518);
            this.tpLocalLicense.TabIndex = 0;
            this.tpLocalLicense.Text = "Local";
            this.tpLocalLicense.UseWaitCursor = true;
            // 
            // dgvLocalDriverLicenses
            // 
            this.dgvLocalDriverLicenses.AllowUserToAddRows = false;
            this.dgvLocalDriverLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalDriverLicenses.AllowUserToOrderColumns = true;
            this.dgvLocalDriverLicenses.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.dgvLocalDriverLicenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLocalDriverLicenses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalDriverLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalDriverLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDriverLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLicenseID,
            this.colApplicationID,
            this.colClassName,
            this.colIssueDate,
            this.colExpirationDate,
            this.colIsActive});
            this.dgvLocalDriverLicenses.ContextMenuStrip = this.cms1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalDriverLicenses.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalDriverLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocalDriverLicenses.EnableHeadersVisualStyles = false;
            this.dgvLocalDriverLicenses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.dgvLocalDriverLicenses.Location = new System.Drawing.Point(3, 3);
            this.dgvLocalDriverLicenses.Name = "dgvLocalDriverLicenses";
            this.dgvLocalDriverLicenses.ReadOnly = true;
            this.dgvLocalDriverLicenses.RowHeadersVisible = false;
            this.dgvLocalDriverLicenses.RowHeadersWidth = 82;
            this.dgvLocalDriverLicenses.RowTemplate.Height = 45;
            this.dgvLocalDriverLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalDriverLicenses.Size = new System.Drawing.Size(2610, 512);
            this.dgvLocalDriverLicenses.TabIndex = 1;
            this.dgvLocalDriverLicenses.UseWaitCursor = true;
            // 
            // colLicenseID
            // 
            this.colLicenseID.HeaderText = "Lic ID";
            this.colLicenseID.MinimumWidth = 10;
            this.colLicenseID.Name = "colLicenseID";
            this.colLicenseID.ReadOnly = true;
            this.colLicenseID.Width = 200;
            // 
            // colApplicationID
            // 
            this.colApplicationID.HeaderText = "App ID";
            this.colApplicationID.MinimumWidth = 10;
            this.colApplicationID.Name = "colApplicationID";
            this.colApplicationID.ReadOnly = true;
            this.colApplicationID.Width = 200;
            // 
            // colClassName
            // 
            this.colClassName.HeaderText = "Class Name";
            this.colClassName.MinimumWidth = 10;
            this.colClassName.Name = "colClassName";
            this.colClassName.ReadOnly = true;
            this.colClassName.Width = 500;
            // 
            // colIssueDate
            // 
            this.colIssueDate.HeaderText = "Issue Date";
            this.colIssueDate.MinimumWidth = 10;
            this.colIssueDate.Name = "colIssueDate";
            this.colIssueDate.ReadOnly = true;
            this.colIssueDate.Width = 150;
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.HeaderText = "Expiration Date";
            this.colExpirationDate.MinimumWidth = 10;
            this.colExpirationDate.Name = "colExpirationDate";
            this.colExpirationDate.ReadOnly = true;
            this.colExpirationDate.Width = 150;
            // 
            // colIsActive
            // 
            this.colIsActive.HeaderText = "Is Active";
            this.colIsActive.MinimumWidth = 10;
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.ReadOnly = true;
            this.colIsActive.Width = 200;
            // 
            // cms1
            // 
            this.cms1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.cms1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLocalLicenseInfoToolStripMenuItem});
            this.cms1.Name = "contextMenuStrip1";
            this.cms1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cms1.Size = new System.Drawing.Size(358, 44);
            // 
            // showLocalLicenseInfoToolStripMenuItem
            // 
            this.showLocalLicenseInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLocalLicenseInfoToolStripMenuItem.Name = "showLocalLicenseInfoToolStripMenuItem";
            this.showLocalLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(357, 40);
            this.showLocalLicenseInfoToolStripMenuItem.Text = "Show Local License Info";
            this.showLocalLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLocalLicenseInfoToolStripMenuItem_Click);
            // 
            // tpInternationalLicense
            // 
            this.tpInternationalLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.tpInternationalLicense.Controls.Add(this.dgvInternationalDriverLicenses);
            this.tpInternationalLicense.Location = new System.Drawing.Point(8, 45);
            this.tpInternationalLicense.Name = "tpInternationalLicense";
            this.tpInternationalLicense.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternationalLicense.Size = new System.Drawing.Size(1347, 518);
            this.tpInternationalLicense.TabIndex = 1;
            this.tpInternationalLicense.Text = "Internatioal";
            this.tpInternationalLicense.UseWaitCursor = true;
            // 
            // dgvInternationalDriverLicenses
            // 
            this.dgvInternationalDriverLicenses.AllowUserToAddRows = false;
            this.dgvInternationalDriverLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalDriverLicenses.AllowUserToOrderColumns = true;
            this.dgvInternationalDriverLicenses.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.dgvInternationalDriverLicenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInternationalDriverLicenses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalDriverLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInternationalDriverLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalDriverLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInternationalLicenseID,
            this.colAppID,
            this.colLocalLicenseID,
            this.colIssDate,
            this.colExpDate,
            this.colActive});
            this.dgvInternationalDriverLicenses.ContextMenuStrip = this.cms2;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalDriverLicenses.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInternationalDriverLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInternationalDriverLicenses.EnableHeadersVisualStyles = false;
            this.dgvInternationalDriverLicenses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.dgvInternationalDriverLicenses.Location = new System.Drawing.Point(3, 3);
            this.dgvInternationalDriverLicenses.Name = "dgvInternationalDriverLicenses";
            this.dgvInternationalDriverLicenses.ReadOnly = true;
            this.dgvInternationalDriverLicenses.RowHeadersVisible = false;
            this.dgvInternationalDriverLicenses.RowHeadersWidth = 82;
            this.dgvInternationalDriverLicenses.RowTemplate.Height = 45;
            this.dgvInternationalDriverLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalDriverLicenses.Size = new System.Drawing.Size(1341, 512);
            this.dgvInternationalDriverLicenses.TabIndex = 1;
            this.dgvInternationalDriverLicenses.UseWaitCursor = true;
            // 
            // colInternationalLicenseID
            // 
            this.colInternationalLicenseID.HeaderText = "Int.License ID";
            this.colInternationalLicenseID.MinimumWidth = 10;
            this.colInternationalLicenseID.Name = "colInternationalLicenseID";
            this.colInternationalLicenseID.ReadOnly = true;
            this.colInternationalLicenseID.Width = 200;
            // 
            // colAppID
            // 
            this.colAppID.HeaderText = "Application ID";
            this.colAppID.MinimumWidth = 10;
            this.colAppID.Name = "colAppID";
            this.colAppID.ReadOnly = true;
            this.colAppID.Width = 200;
            // 
            // colLocalLicenseID
            // 
            this.colLocalLicenseID.HeaderText = "L.License ID";
            this.colLocalLicenseID.MinimumWidth = 10;
            this.colLocalLicenseID.Name = "colLocalLicenseID";
            this.colLocalLicenseID.ReadOnly = true;
            this.colLocalLicenseID.Width = 200;
            // 
            // colIssDate
            // 
            this.colIssDate.HeaderText = "Issue Date";
            this.colIssDate.MinimumWidth = 10;
            this.colIssDate.Name = "colIssDate";
            this.colIssDate.ReadOnly = true;
            this.colIssDate.Width = 150;
            // 
            // colExpDate
            // 
            this.colExpDate.HeaderText = "Expiration Date";
            this.colExpDate.MinimumWidth = 10;
            this.colExpDate.Name = "colExpDate";
            this.colExpDate.ReadOnly = true;
            this.colExpDate.Width = 150;
            // 
            // colActive
            // 
            this.colActive.HeaderText = "Is Active";
            this.colActive.MinimumWidth = 10;
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            this.colActive.Width = 200;
            // 
            // cms2
            // 
            this.cms2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.cms2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cms2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInternationalLisenseInfoToolStripMenuItem});
            this.cms2.Name = "contextMenuStrip1";
            this.cms2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cms2.Size = new System.Drawing.Size(438, 44);
            // 
            // showInternationalLisenseInfoToolStripMenuItem
            // 
            this.showInternationalLisenseInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showInternationalLisenseInfoToolStripMenuItem.Name = "showInternationalLisenseInfoToolStripMenuItem";
            this.showInternationalLisenseInfoToolStripMenuItem.Size = new System.Drawing.Size(437, 40);
            this.showInternationalLisenseInfoToolStripMenuItem.Text = "Show International Lisense Info";
            this.showInternationalLisenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showInternationalLisenseInfoToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRecords);
            this.groupBox1.Controls.Add(this.tcDriverLicensesInfo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.LightPink;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2676, 712);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            this.groupBox1.UseCompatibleTextRendering = true;
            this.groupBox1.UseWaitCursor = true;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.lblRecords.Location = new System.Drawing.Point(279, 655);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(74, 31);
            this.lblRecords.TabIndex = 12;
            this.lblRecords.Text = "????";
            this.lblRecords.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.LightPink;
            this.label8.Location = new System.Drawing.Point(11, 655);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 31);
            this.label8.TabIndex = 11;
            this.label8.Text = "# Records: ";
            this.label8.UseWaitCursor = true;
            // 
            // ucDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.Controls.Add(this.groupBox1);
            this.Name = "ucDriverLicenses";
            this.Size = new System.Drawing.Size(2676, 712);
            this.tcDriverLicensesInfo.ResumeLayout(false);
            this.tpLocalLicense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDriverLicenses)).EndInit();
            this.cms1.ResumeLayout(false);
            this.tpInternationalLicense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDriverLicenses)).EndInit();
            this.cms2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tcDriverLicensesInfo;
        private System.Windows.Forms.TabPage tpLocalLicense;
        private System.Windows.Forms.TabPage tpInternationalLicense;
        private System.Windows.Forms.DataGridView dgvLocalDriverLicenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApplicationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpirationDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsActive;
        private System.Windows.Forms.DataGridView dgvInternationalDriverLicenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInternationalLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip cms1;
        private System.Windows.Forms.ContextMenuStrip cms2;
        private System.Windows.Forms.ToolStripMenuItem showLocalLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInternationalLisenseInfoToolStripMenuItem;
    }
}
