namespace DVLD
{
    partial class frmTestTypeDetailes
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
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblApplicationTypeFees = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblApplicationTypeTitle = new System.Windows.Forms.Label();
            this.lblTestTypeID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lable1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(16)))), ((int)(((byte)(38)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(70)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnClose.Location = new System.Drawing.Point(719, 576);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(212, 74);
            this.btnClose.TabIndex = 102;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFees
            // 
            this.txtFees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.txtFees.Enabled = false;
            this.txtFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.txtFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.txtFees.Location = new System.Drawing.Point(344, 497);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(587, 40);
            this.txtFees.TabIndex = 101;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DVLD.Properties.Resources.money_32;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(253, 500);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 35);
            this.pictureBox1.TabIndex = 100;
            this.pictureBox1.TabStop = false;
            // 
            // lblApplicationTypeFees
            // 
            this.lblApplicationTypeFees.AutoSize = true;
            this.lblApplicationTypeFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.125F, System.Drawing.FontStyle.Bold);
            this.lblApplicationTypeFees.Location = new System.Drawing.Point(85, 498);
            this.lblApplicationTypeFees.Name = "lblApplicationTypeFees";
            this.lblApplicationTypeFees.Size = new System.Drawing.Size(114, 38);
            this.lblApplicationTypeFees.TabIndex = 99;
            this.lblApplicationTypeFees.Text = "Fees: ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::DVLD.Properties.Resources.ApplicationTitle;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(244, 240);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 35);
            this.pictureBox2.TabIndex = 97;
            this.pictureBox2.TabStop = false;
            // 
            // lblApplicationTypeTitle
            // 
            this.lblApplicationTypeTitle.AutoSize = true;
            this.lblApplicationTypeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.125F, System.Drawing.FontStyle.Bold);
            this.lblApplicationTypeTitle.Location = new System.Drawing.Point(96, 238);
            this.lblApplicationTypeTitle.Name = "lblApplicationTypeTitle";
            this.lblApplicationTypeTitle.Size = new System.Drawing.Size(103, 38);
            this.lblApplicationTypeTitle.TabIndex = 96;
            this.lblApplicationTypeTitle.Text = "Title: ";
            // 
            // lblTestTypeID
            // 
            this.lblTestTypeID.AutoSize = true;
            this.lblTestTypeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.125F);
            this.lblTestTypeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.lblTestTypeID.Location = new System.Drawing.Point(237, 130);
            this.lblTestTypeID.Name = "lblTestTypeID";
            this.lblTestTypeID.Size = new System.Drawing.Size(89, 38);
            this.lblTestTypeID.TabIndex = 95;
            this.lblTestTypeID.Text = "????";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.125F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(128, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 38);
            this.label2.TabIndex = 94;
            this.label2.Text = "ID: ";
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable1.Location = new System.Drawing.Point(265, 39);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(399, 51);
            this.lable1.TabIndex = 93;
            this.lable1.Text = "Test Type Detailes";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.txtDescription.Enabled = false;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.txtDescription.Location = new System.Drawing.Point(344, 318);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(587, 138);
            this.txtDescription.TabIndex = 106;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::DVLD.Properties.Resources.ApplicationTitle;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(244, 333);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 35);
            this.pictureBox3.TabIndex = 105;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.125F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(7, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 38);
            this.label1.TabIndex = 104;
            this.label1.Text = "Description";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.txtTitle.Enabled = false;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.txtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.txtTitle.Location = new System.Drawing.Point(344, 237);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(587, 40);
            this.txtTitle.TabIndex = 98;
            // 
            // frmTestTypeDetailes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(993, 684);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblApplicationTypeFees);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblApplicationTypeTitle);
            this.Controls.Add(this.lblTestTypeID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.LightPink;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(993, 684);
            this.MinimumSize = new System.Drawing.Size(993, 684);
            this.Name = "frmTestTypeDetailes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTestTypeDetailes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTestTypeDetailes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblApplicationTypeFees;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblApplicationTypeTitle;
        private System.Windows.Forms.Label lblTestTypeID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
    }
}