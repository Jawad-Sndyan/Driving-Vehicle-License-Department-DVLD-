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
    public partial class frmReleaseDetainedLicense : Form
    {

        private int _SelectedLicenseID = -1;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }
         public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID=LicenseID;

            ucDriverLicenseInfoWithFilter.LoadLicenseInfo(_SelectedLicenseID);
            ucDriverLicenseInfoWithFilter.FilterEnabled = false;

        }

        private void ucDriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate= AutoValidate.Disable;
            this.Close();
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {

        }

        private void ucDriverLicenseInfoWithFilter_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID=obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            linkLabelShowLicensesInfo.Enabled = (_SelectedLicenseID != -1);

            if(_SelectedLicenseID==-1)
                return;

            if (ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is not detained, choose another one.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnRelease.Enabled = false;

                return;
            }

            lblAppFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Release_Detained_Driving_License).ApplicationFees.ToString();  

            lblDetainID.Text = ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();

            lblLicenseID.Text= ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.LicenseID.ToString();

            lblUser.Text = ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            lblDetainDate.Text= ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.DetainedInfo.DetainDate.ToShortDateString();

            lblFineFees.Text = ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();

            lblTotalFees.Text=(Convert.ToSingle(lblFineFees.Text.Trim())+ Convert.ToSingle(lblAppFees.Text.Trim())).ToString();

            btnRelease.Enabled = true;

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            { return; }


            int ApplicationID = -1;

            bool IsReleased = !ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID,ref ApplicationID);    

            lblAppID.Text = ApplicationID.ToString();

           
            
            if(!IsReleased)
            {
                MessageBox.Show("Failed to release the detained License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRelease.Enabled = false;

                return;
            }

            MessageBox.Show("Detained License released Successfully", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);


            btnRelease.Enabled = false;
            ucDriverLicenseInfoWithFilter.FilterEnabled = false;
            linkLabelShowLicensesInfo.Enabled = true;
        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.Driver.PersonID);
            frm.ShowDialog();
        }

        private void linkLabelShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }
    }
}
