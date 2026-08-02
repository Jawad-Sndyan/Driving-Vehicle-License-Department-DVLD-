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
    public partial class frmNewInternationalLicenseApplication : Form
    {

        private int _InternationalLicenseID = -1;
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate= AutoValidate.Disable;
            this.Close();
        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            linkLabelShowLicenseHistory.Enabled= false;
            linkLabelShowLicensesInfo.Enabled= false;   
        }

        private void ucDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblLocalLicenseID.Text= SelectedLicenseID.ToString();

            linkLabelShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
                return;

            if(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID!=3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one","disallowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            int ActiveInternationalLicenseID=
                clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if(ActiveInternationalLicenseID!=-1)
            {
                MessageBox.Show("Person already have an active international license \nID = " + ActiveInternationalLicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                linkLabelShowLicensesInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternationalLicenseID;
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue the license?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;


            clsInternationalLicense InternationalLicense = new clsInternationalLicense();


            InternationalLicense.PersonID = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Driver.PersonID;
            InternationalLicense.ApplicationDate=DateTime.Now;
            InternationalLicense.Status = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.New_International_License).ApplicationFees;
            InternationalLicense.UserID=clsGlobal.CurrentUser.UserID;

            InternationalLicense.DriverID= ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;

            InternationalLicense.IssuedUsingLocalLicenseID= ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;

            InternationalLicense.IssueDate= DateTime.Now;

            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);


            if(!InternationalLicense.Save())
            {
                MessageBox.Show("Failed to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblIntLicenseAppID.Text= InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID= InternationalLicense.InternationalLicenseID;
            lblIntLicenseID.Text= _InternationalLicenseID.ToString();

            MessageBox.Show("International License Issued Successfully \n ID = " + _InternationalLicenseID.ToString(), "International License Issued",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssue.Enabled= false;

            ucDriverLicenseInfoWithFilter1.FilterEnabled= false;
           linkLabelShowLicensesInfo.Enabled= true;

        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Driver.PersonID);
            frm.ShowDialog();

        }

        private void linkLabelShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
