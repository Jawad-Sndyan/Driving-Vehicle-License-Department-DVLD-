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
    public partial class frmScheduleTest : Form
    {
        private int _TestAppointmentID = -1;

        private int _LocalDrivingLicenseApplicationID = -1;

        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;

        public frmScheduleTest(int localDrivingLicenseApplicationID, clsTestTypes.enTestType testType, int testAppointmentID=-1)
        {
            _LocalDrivingLicenseApplicationID=localDrivingLicenseApplicationID;
            _TestAppointmentID=testAppointmentID;
            _TestType=testType;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ucScheduleTest.TestType = _TestType;
            ucScheduleTest.LoadInfo(_LocalDrivingLicenseApplicationID, _TestAppointmentID);
        }

        private void ucScheduleTest_Load(object sender, EventArgs e)
        {

        }
    }
}
