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
    public partial class frmDrivingLicenseApplicationInfo : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmDrivingLicenseApplicationInfo(int LDLAPP)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID= LDLAPP;
        }

        private void frmDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ucDrivingLicenseApplicationInfo.LoadLocalDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            this.Close();
        }
    }
}
