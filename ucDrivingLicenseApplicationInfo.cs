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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class ucDrivingLicenseApplicationInfo : UserControl
    {

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public int LDAppID
        {
            get { return (_LocalDrivingLicenseApplication != null) ? _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID : -1; }
        }
        public ucDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void FillLocalDrivingLicenseApplicationInfo()
        {
            lblDLAppID.Text= LDAppID.ToString();
            lblLicenseClass.Text = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            //For Now
            lblPassTest.Text = "3";
            ucApplicationBasicInfo.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
        }

        public void ResetLocalDrivingLicenseApplicationInfo()
        {
            lblDLAppID.Text = "???";
            lblLicenseClass.Text = "???";
            lblPassTest.Text = "???";
            ucApplicationBasicInfo.ResetApplicationInfo();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void LoadLocalDrivingLicenseApplicationInfo(int lDLAppID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationInfoByID(lDLAppID);

            if( _LocalDrivingLicenseApplication == null )
            {
                ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Local Driving License Application found with ID: " + lDLAppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillLocalDrivingLicenseApplicationInfo();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void linkLabelShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Will Be Implemented After Bulding Licence Class");
        }

        private void ucApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
