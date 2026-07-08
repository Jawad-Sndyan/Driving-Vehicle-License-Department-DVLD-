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
    public partial class frmReplaceLostOrDamagedLicense : Form
    {

        private int _NewLicenseID = -1;

        private int _GetApplicationtypeID()
        {
            if (rbDamaged.Checked)
                return (int)clsApplication.enApplicationTypes.Replacement_for_a_Damaged_Driving_License;

            return (int)clsApplication.enApplicationTypes.Replacement_for_a_Lost_Driving_License;
        }

        private clsLicense.enIssueReason _GetReplacementReason()
        {
            if (rbDamaged.Checked)
                return clsLicense.enIssueReason.ReplacementDamaged;

            return clsLicense.enIssueReason.ReplacementLost;
        }
        public frmReplaceLostOrDamagedLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate= AutoValidate.Disable;
            this.Close();
        }

        private void frmReplaceLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            btnReplacement.Enabled = false;
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblUser.Text=clsGlobal.CurrentUser.UserName;

            rbDamaged.Checked = true;
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lblTiltle.Text = "Replacement for Damaged License";
            this.Text = lblTiltle.Text;
            lblAppFees.Text=clsApplicationTypes.FindApplicationTypeByID(_GetApplicationtypeID()).ApplicationFees.ToString();

        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lblTiltle.Text = "Replacement for Lost License";
            this.Text = lblTiltle.Text;
            lblAppFees.Text = clsApplicationTypes.FindApplicationTypeByID(_GetApplicationtypeID()).ApplicationFees.ToString();
        }

        private void ucDriverLicenseInfoWithFilter_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            linkLabelShowNewLicensesInfo.Enabled = (SelectedLicenseID != -1);

            if(SelectedLicenseID == -1)
            {
                return;
            }

            if (!ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is Not Active,choose another license ", "Not Allowed", MessageBoxButtons.OK);
                btnReplacement.Enabled = false;
                this.AutoValidate = AutoValidate.Disable;
                this.Close();
            }

            btnReplacement.Enabled = true;
        }

        private void btnReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            clsLicense NewLicense = ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.Replace(_GetReplacementReason(), clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Failed to Renew the license", "Error", MessageBoxButtons.OK);
                return;
            }


            lbRLLAppID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.ApplicationID;
            lblRLicenseID.Text = _NewLicenseID.ToString();

            btnReplacement.Enabled = false;
            ucDriverLicenseInfoWithFilter.FilterEnabled = false;
            linkLabelShowNewLicensesInfo.Enabled = true;
            MessageBox.Show("License Renewed Successfully with ID: " + _NewLicenseID.ToString(), "Success", MessageBoxButtons.OK);
        }

        private void linkLabelShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }
    }
}
