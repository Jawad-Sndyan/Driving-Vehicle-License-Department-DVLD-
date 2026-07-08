namespace DVLD
{
    partial class frmReplaceLostOrDamagedLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplaceLostOrDamagedLicense));
            this.btnReplacement = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucDriverLicenseInfoWithFilter = new DVLD.ucDriverLicenseInfoWithFilter();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.linkLabelShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.gbNewLicense = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblRLicenseID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lbRLLAppID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTiltle = new System.Windows.Forms.Label();
            this.linkLabelShowNewLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.gbNewLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReplacement
            // 
            this.btnReplacement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.btnReplacement.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReplacement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnReplacement.ForeColor = System.Drawing.Color.LightPink;
            this.btnReplacement.Location = new System.Drawing.Point(1311, 1328);
            this.btnReplacement.Name = "btnReplacement";
            this.btnReplacement.Size = new System.Drawing.Size(326, 70);
            this.btnReplacement.TabIndex = 120;
            this.btnReplacement.Text = "Issue Rplacement";
            this.btnReplacement.UseVisualStyleBackColor = false;
            this.btnReplacement.Click += new System.EventHandler(this.btnReplacement_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnClose.ForeColor = System.Drawing.Color.LightPink;
            this.btnClose.Location = new System.Drawing.Point(982, 1328);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(272, 70);
            this.btnClose.TabIndex = 119;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucDriverLicenseInfoWithFilter
            // 
            this.ucDriverLicenseInfoWithFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.ucDriverLicenseInfoWithFilter.FilterEnabled = true;
            this.ucDriverLicenseInfoWithFilter.ForeColor = System.Drawing.Color.LightPink;
            this.ucDriverLicenseInfoWithFilter.Location = new System.Drawing.Point(26, 127);
            this.ucDriverLicenseInfoWithFilter.Name = "ucDriverLicenseInfoWithFilter";
            this.ucDriverLicenseInfoWithFilter.Size = new System.Drawing.Size(1611, 894);
            this.ucDriverLicenseInfoWithFilter.TabIndex = 114;
            this.ucDriverLicenseInfoWithFilter.OnLicenseSelected += new System.Action<int>(this.ucDriverLicenseInfoWithFilter_OnLicenseSelected);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = global::DVLD.Properties.Resources.User_32__2;
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox10.Location = new System.Drawing.Point(1133, 210);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(34, 35);
            this.pictureBox10.TabIndex = 125;
            this.pictureBox10.TabStop = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.lblUser.Location = new System.Drawing.Point(1224, 212);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 31);
            this.lblUser.TabIndex = 123;
            this.lblUser.Text = "???";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(792, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(177, 31);
            this.label12.TabIndex = 124;
            this.label12.Text = "Created By: ";
            // 
            // linkLabelShowLicenseHistory
            // 
            this.linkLabelShowLicenseHistory.AutoSize = true;
            this.linkLabelShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold);
            this.linkLabelShowLicenseHistory.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(211)))), ((int)(((byte)(252)))));
            this.linkLabelShowLicenseHistory.Location = new System.Drawing.Point(58, 1328);
            this.linkLabelShowLicenseHistory.Name = "linkLabelShowLicenseHistory";
            this.linkLabelShowLicenseHistory.Size = new System.Drawing.Size(304, 31);
            this.linkLabelShowLicenseHistory.TabIndex = 117;
            this.linkLabelShowLicenseHistory.TabStop = true;
            this.linkLabelShowLicenseHistory.Text = "Show License History ";
            this.linkLabelShowLicenseHistory.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(161)))), ((int)(((byte)(255)))));
            // 
            // gbNewLicense
            // 
            this.gbNewLicense.Controls.Add(this.pictureBox10);
            this.gbNewLicense.Controls.Add(this.lblUser);
            this.gbNewLicense.Controls.Add(this.label12);
            this.gbNewLicense.Controls.Add(this.pictureBox8);
            this.gbNewLicense.Controls.Add(this.lblOldLicenseID);
            this.gbNewLicense.Controls.Add(this.label9);
            this.gbNewLicense.Controls.Add(this.pictureBox7);
            this.gbNewLicense.Controls.Add(this.lblRLicenseID);
            this.gbNewLicense.Controls.Add(this.label8);
            this.gbNewLicense.Controls.Add(this.pictureBox2);
            this.gbNewLicense.Controls.Add(this.lblAppFees);
            this.gbNewLicense.Controls.Add(this.label4);
            this.gbNewLicense.Controls.Add(this.pictureBox6);
            this.gbNewLicense.Controls.Add(this.lblAppDate);
            this.gbNewLicense.Controls.Add(this.label6);
            this.gbNewLicense.Controls.Add(this.pictureBox4);
            this.gbNewLicense.Controls.Add(this.lbRLLAppID);
            this.gbNewLicense.Controls.Add(this.label11);
            this.gbNewLicense.ForeColor = System.Drawing.Color.LightPink;
            this.gbNewLicense.Location = new System.Drawing.Point(26, 1025);
            this.gbNewLicense.Name = "gbNewLicense";
            this.gbNewLicense.Size = new System.Drawing.Size(1611, 274);
            this.gbNewLicense.TabIndex = 116;
            this.gbNewLicense.TabStop = false;
            this.gbNewLicense.Text = "Application New License Info";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImage = global::DVLD.Properties.Resources.License_View_32;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox8.Location = new System.Drawing.Point(1133, 135);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(34, 35);
            this.pictureBox8.TabIndex = 119;
            this.pictureBox8.TabStop = false;
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.lblOldLicenseID.Location = new System.Drawing.Point(1224, 137);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(59, 31);
            this.lblOldLicenseID.TabIndex = 117;
            this.lblOldLicenseID.Text = "???";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(792, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(223, 31);
            this.label9.TabIndex = 118;
            this.label9.Text = "Old License ID: ";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::DVLD.Properties.Resources.License_Type_32;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(1133, 58);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(34, 35);
            this.pictureBox7.TabIndex = 116;
            this.pictureBox7.TabStop = false;
            // 
            // lblRLicenseID
            // 
            this.lblRLicenseID.AutoSize = true;
            this.lblRLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRLicenseID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.lblRLicenseID.Location = new System.Drawing.Point(1224, 60);
            this.lblRLicenseID.Name = "lblRLicenseID";
            this.lblRLicenseID.Size = new System.Drawing.Size(59, 31);
            this.lblRLicenseID.TabIndex = 114;
            this.lblRLicenseID.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(792, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(301, 31);
            this.label8.TabIndex = 115;
            this.label8.Text = "Replaced License ID: ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::DVLD.Properties.Resources.money_32;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(316, 215);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 35);
            this.pictureBox2.TabIndex = 108;
            this.pictureBox2.TabStop = false;
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.lblAppFees.Location = new System.Drawing.Point(436, 217);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(59, 31);
            this.lblAppFees.TabIndex = 106;
            this.lblAppFees.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 31);
            this.label4.TabIndex = 107;
            this.label4.Text = "Application Fees: ";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(316, 126);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(34, 35);
            this.pictureBox6.TabIndex = 102;
            this.pictureBox6.TabStop = false;
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.lblAppDate.Location = new System.Drawing.Point(436, 128);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(59, 31);
            this.lblAppDate.TabIndex = 100;
            this.lblAppDate.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 31);
            this.label6.TabIndex = 101;
            this.label6.Text = "Application Date: ";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(316, 58);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 35);
            this.pictureBox4.TabIndex = 87;
            this.pictureBox4.TabStop = false;
            // 
            // lbRLLAppID
            // 
            this.lbRLLAppID.AutoSize = true;
            this.lbRLLAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRLLAppID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.lbRLLAppID.Location = new System.Drawing.Point(436, 60);
            this.lbRLLAppID.Name = "lbRLLAppID";
            this.lbRLLAppID.Size = new System.Drawing.Size(59, 31);
            this.lbRLLAppID.TabIndex = 85;
            this.lbRLLAppID.Text = "???";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(260, 31);
            this.label11.TabIndex = 86;
            this.label11.Text = "R.L.Application ID:";
            // 
            // lblTiltle
            // 
            this.lblTiltle.AutoSize = true;
            this.lblTiltle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblTiltle.ForeColor = System.Drawing.Color.LightPink;
            this.lblTiltle.Location = new System.Drawing.Point(460, 54);
            this.lblTiltle.Name = "lblTiltle";
            this.lblTiltle.Size = new System.Drawing.Size(742, 51);
            this.lblTiltle.TabIndex = 115;
            this.lblTiltle.Text = "Replacement For Damaged License";
            // 
            // linkLabelShowNewLicensesInfo
            // 
            this.linkLabelShowNewLicensesInfo.AutoSize = true;
            this.linkLabelShowNewLicensesInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold);
            this.linkLabelShowNewLicensesInfo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(211)))), ((int)(((byte)(252)))));
            this.linkLabelShowNewLicensesInfo.Location = new System.Drawing.Point(437, 1328);
            this.linkLabelShowNewLicensesInfo.Name = "linkLabelShowNewLicensesInfo";
            this.linkLabelShowNewLicensesInfo.Size = new System.Drawing.Size(342, 31);
            this.linkLabelShowNewLicensesInfo.TabIndex = 118;
            this.linkLabelShowNewLicensesInfo.TabStop = true;
            this.linkLabelShowNewLicensesInfo.Text = "Show New Licenses Info ";
            this.linkLabelShowNewLicensesInfo.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(161)))), ((int)(((byte)(255)))));
            this.linkLabelShowNewLicensesInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowNewLicensesInfo_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLost);
            this.groupBox1.Controls.Add(this.rbDamaged);
            this.groupBox1.ForeColor = System.Drawing.Color.LightPink;
            this.groupBox1.Location = new System.Drawing.Point(1150, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 127);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement For: ";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLost.Location = new System.Drawing.Point(21, 79);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(179, 33);
            this.rbLost.TabIndex = 1;
            this.rbLost.TabStop = true;
            this.rbLost.Text = "Lost License";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbLost_CheckedChanged);
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDamaged.Location = new System.Drawing.Point(21, 32);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(239, 33);
            this.rbDamaged.TabIndex = 0;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Text = "Damaged License";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.rbDamaged_CheckedChanged);
            // 
            // frmReplaceLostOrDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1662, 1425);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReplacement);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucDriverLicenseInfoWithFilter);
            this.Controls.Add(this.linkLabelShowLicenseHistory);
            this.Controls.Add(this.gbNewLicense);
            this.Controls.Add(this.lblTiltle);
            this.Controls.Add(this.linkLabelShowNewLicensesInfo);
            this.MaximumSize = new System.Drawing.Size(1688, 1496);
            this.MinimumSize = new System.Drawing.Size(1688, 1496);
            this.Name = "frmReplaceLostOrDamagedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReplaceLostOrDamagedLicense";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReplaceLostOrDamagedLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.gbNewLicense.ResumeLayout(false);
            this.gbNewLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReplacement;
        private System.Windows.Forms.Button btnClose;
        private ucDriverLicenseInfoWithFilter ucDriverLicenseInfoWithFilter;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseHistory;
        private System.Windows.Forms.GroupBox gbNewLicense;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblRLicenseID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lbRLLAppID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTiltle;
        private System.Windows.Forms.LinkLabel linkLabelShowNewLicensesInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamaged;
    }
}