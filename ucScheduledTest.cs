using DVLD.Properties;
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
using static DVLD.ucScheduleTest;

namespace DVLD
{
    public partial class ucScheduledTest : UserControl
    {

        private clsTestTypes.enTestType _TestType;
        private int _TestID = -1;
        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointment;
        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }


        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public clsTestTypes.enTestType TestType
        {
            get
            {
                return _TestType;
            }
            set
            {
                _TestType = value;

                switch (_TestType)
                {

                    case clsTestTypes.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            picBoxTestType.BackgroundImage = Resources.Vision_512;
                            break;
                        }

                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            picBoxTestType.BackgroundImage = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            picBoxTestType.BackgroundImage = Resources.driving_test_512;
                            break;


                        }
                }
            }
        }

       

        private void CenterLabelToPictureBox(Label lbl)
        {
            lbl.Left = picBoxTestType.Left + (picBoxTestType.Width / 2) - (lbl.Width / 2);
        }

        public void LoadInfo(int TestAppointmentID)
        {

            _TestAppointmentID = TestAppointmentID;


            _TestAppointment = clsTestAppointment.FindTestAppointmentByID(_TestAppointmentID);

           
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationInfoByID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lblPerson.Text = _LocalDrivingLicenseApplication.Person.FullName;


         
            lblTrialCount.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestType).ToString();



            lblDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();    
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();



        }

        public ucScheduledTest()
        {
            InitializeComponent();
            CenterLabelToPictureBox(lblTitle);
        }


        private void gbRetakeTest_Enter(object sender, EventArgs e)
        {

        }

        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
    }
}
