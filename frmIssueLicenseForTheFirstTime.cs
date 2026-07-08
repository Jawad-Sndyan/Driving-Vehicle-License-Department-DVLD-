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
    public partial class frmIssueLicenseForTheFirstTime : Form
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmIssueLicenseForTheFirstTime(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate= AutoValidate.Disable;
            this.Close();
        }

        private void frmIssueLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            txtNotes.Focus();
            _LocalDrivingLicenseApplication=clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationInfoByID(_LocalDrivingLicenseApplicationID);
            if(_LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("Local Driving License Application With ID: "+ _LocalDrivingLicenseApplicationID.ToString()+" was Not Found.", "Failure", MessageBoxButtons.OK);
                btnClose_Click(sender, e);
                return;
            }

            if(!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show("Applicant Should Pass All Tests", "Not Allowed", MessageBoxButtons.OK);
                btnClose_Click(sender, e);
                return;
            }

            int LicenseID= _LocalDrivingLicenseApplication.GetActiveLicenceID();
            if(LicenseID!=-1)
            {
                MessageBox.Show("Applicant Already has License Before\nLicense ID: "+LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK);
                btnClose_Click(sender, e);
                return;
            }
            ucDrivingLicenseApplicationInfo.LoadLocalDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID= _LocalDrivingLicenseApplication.IssueLicenceForTheFirstTime(txtNotes.Text.Trim(),clsGlobal.CurrentUser.UserID);

            if(LicenseID!=-1)
            {
                MessageBox.Show("License Issued Successfully\nLicense ID: " + LicenseID.ToString(), "Success", MessageBoxButtons.OK);
                btnClose_Click(sender, e);
            }
            else
            {
                MessageBox.Show("License Was Not Issued !", "Failure", MessageBoxButtons.OK);
            }
        }
    }
}
