using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmRenewDriverLicense : Form
    {

        private int _NewLicenseID = -1;
        public frmRenewDriverLicense()
        {
            InitializeComponent();
        }

        private void frmRenewDriverLicense_Load(object sender, EventArgs e)
        {
            linkLabelShowNewLicensesInfo.Enabled = false;
            btnRenew.Enabled = false;
            ucDriverLicenseInfoWithFilter.txtFilterFocus();

            lblAppDate.Text=DateTime.Now.ToShortDateString();
            lblIssueDate.Text=DateTime.Now.ToShortDateString();

            lblExpirationDate.Text = "????";
            lblAppFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Renew_Driving_License_Service).ApplicationFees.ToString();

            lblUser.Text=clsGlobal.CurrentUser.UserName;
        }

        private void linkLabelViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void lblStatusDate_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void lblApplicant_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblFees_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gbNewLicense_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate=AutoValidate.Disable;
            this.Close();
        }

        private void ucDriverLicenseInfoWithFilter_OnLicenseSelected(int obj)
        {
            int SelectesLicenseID = obj;

            lblOldLicenseID.Text = SelectesLicenseID.ToString();
            linkLabelShowLicenseHistory.Enabled = (SelectesLicenseID != -1);

            if(SelectesLicenseID == -1)
            {
                return;
            }

            int DefaultValidityLength= ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.LicenseClass.DefaultValidityLength;

            lblExpirationDate.Text=DateTime.Now.AddYears(DefaultValidityLength).ToShortDateString();
            lblLicenseFees.Text= ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.LicenseClass.ClassFees.ToString();

            lblTotalFees.Text=(Convert.ToString(lblAppFees.Text)+ Convert.ToString(lblLicenseFees.Text)).ToString();

            txtNotes.Text= ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.Notes.ToString();


            if(!ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.IsLicenseExpiered())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.ExpirationDate.ToShortDateString(), "Not Allowed", MessageBoxButtons.OK);
                btnRenew.Enabled = false;
                this.AutoValidate = AutoValidate.Disable;
                this.Close();
            }


            if (!ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is Not Active,choose another license ", "Not Allowed", MessageBoxButtons.OK);
                btnRenew.Enabled = false;
                this.AutoValidate = AutoValidate.Disable;
                this.Close();
            }


            btnRenew.Enabled = true;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            clsLicense NewLicense = ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (NewLicense == null) 
            {
                MessageBox.Show("Failed to Renew the license","Error",MessageBoxButtons.OK);
                return;
            }


            lbRLLAppID.Text= NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.ApplicationID;
            lblRLicenseID.Text= _NewLicenseID.ToString();

            btnRenew.Enabled = false;
            ucDriverLicenseInfoWithFilter.FilterEnabled = false;
            linkLabelShowNewLicensesInfo.Enabled = true;

            MessageBox.Show("License Renewed Successfully with ID: " + _NewLicenseID.ToString(), "Success", MessageBoxButtons.OK);

        }

        private void linkLabelShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void ucDriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm=new frmShowPersonLicenseHistory(ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.Driver.PersonID);
            frm.ShowDialog();
        }
    }
}
