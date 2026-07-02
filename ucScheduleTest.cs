using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ucScheduleTest : UserControl
    {
        public enum enMode {AddNew=0,Update=1 }
        private enMode _Mode=enMode.AddNew;

        public enum enCreationMode { FirstTime=0,RetakeTest=1}
        private enCreationMode _CreationMode=enCreationMode.FirstTime;

        private clsTestTypes.enTestType _TestType= clsTestTypes.enTestType.VisionTest;

        public clsTestTypes.enTestType TestType
        {
            get { return _TestType; }
            set
            {
                _TestType = value;
                switch (_TestType)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        gbTestType.Text = "Vision Test";
                        picBoxTestType.BackgroundImage = Properties.Resources.Vision_512;
                        break;
                    case clsTestTypes.enTestType.StreetTest:
                        gbTestType.Text = "Street Test";
                        picBoxTestType.BackgroundImage = Properties.Resources.driving_test_512;
                        break;
                    case clsTestTypes.enTestType.WrittenTest:
                        gbTestType.Text = "Written Test";
                        picBoxTestType.BackgroundImage = Properties.Resources.Written_Test_512;
                        break;

                }
            }
        }

        private int _LocalDrivingLicenseApplicationID = -1;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _TestAppointmentID=-1;  

        private clsTestAppointment _TestAppointment;

        private void CenterLabelToPictureBox(Label lbl)
        {
            lbl.Left = picBoxTestType.Left + (picBoxTestType.Width / 2) - (lbl.Width / 2);
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment=clsTestAppointment.FindTestAppointmentByID(_TestAppointmentID);

            if (_TestAppointment==null)
            {
                MessageBox.Show("Error: No Test Appointment with ID: " + _TestAppointmentID.ToString(), "Error");
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text= _TestAppointment.PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpTestDate.MaxDate = DateTime.Now;
            else
                dtpTestDate.MaxDate = _TestAppointment.AppointmentDate;

            dtpTestDate.Value = dtpTestDate.MaxDate;

            if(_TestAppointment.RetakeTestApplicationID==-1)
            {
                gbRetakeTest.Enabled = false;
                lblReTest_AppID.Text = "0";
                lblReTest_AppID.Text = "N/A";
            }
            else
            {
                gbRetakeTest.Enabled = true;
                lblR_AppFees.Text = _TestAppointment.RetakeTestApplication.PaidFees.ToString();
                lblTitle.Text = "Schedule Retake Test";
                CenterLabelToPictureBox(lblTitle);
                lblReTest_AppID.Text= _TestAppointment.RetakeTestApplication.ApplicationID.ToString();

            }
            return true;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, _TestType))
            {
                lblError.Visible = true;
                lblError.Text = "Applicant Already have an active application for " + clsTestTypes.FindTestTypeByID(_TestType).TestTypeTitle.ToString();
                CenterLabelToPictureBox(lblError);
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            else
            {
                lblError.Visible = false;
                btnSave.Enabled = true;
                dtpTestDate.Enabled = true;
            }

            return true;
        }

        private bool _HandleApplicationLockedConstraint()
        {
            if(_TestAppointment.IsLocked)
            {
                lblError.Visible = true;
                lblError.Text = "Applicant already sat for this test, application locked.";
                CenterLabelToPictureBox(lblError);
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            else
            {
                lblError.Visible = false;
                btnSave.Enabled = true;
                dtpTestDate.Enabled = true;
            }

            return true;
        }

        private bool _HandlePreviouseTestConstraint()
        {
            switch(_TestType)
            {
                case clsTestTypes.enTestType.VisionTest:
                    lblError.Visible = false;
                    return true;
                case clsTestTypes.enTestType.WrittenTest:
                    if(!_LocalDrivingLicenseApplication.DoesPassTest(clsTestTypes.enTestType.VisionTest))
                    {
                        lblError.Visible = true;
                        lblError.Text = "Connot Schedule, Vision Test should be passed first.";
                        CenterLabelToPictureBox(lblError);
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblError.Visible=false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                        return true;
                    }

                case clsTestTypes.enTestType.StreetTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTest(clsTestTypes.enTestType.WrittenTest))
                    {
                        lblError.Visible = true;
                        lblError.Text = "Connot Schedule, Written Test should be passed first.";
                        CenterLabelToPictureBox(lblError);
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblError.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                        return true;
                    }



            }

            return true;
        }

        private bool _HandleRetakeApplication()
        {
            if(_Mode==enMode.AddNew && _CreationMode==enCreationMode.RetakeTest)
            {
                clsApplication application = new clsApplication();

                application.PersonID = _LocalDrivingLicenseApplication.PersonID;
                application.ApplicationDate=DateTime.Now;
                application.ApplicationTypeID = clsApplication.enApplicationTypes.Retake_Test;
                application.Status= clsApplication.enApplicationStatus.Completed;
                application.LastStatusDate= DateTime.Now;
                application.PaidFees = clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Retake_Test).ApplicationFees;
                application.UserID=clsGlobal.CurrentUser.UserID;

                if(!application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Failed to create application", "Failed",
                        MessageBoxButtons.OK);
                    return false;   
                }

                _TestAppointment.RetakeTestApplicationID=application.ApplicationID;
            }

            return true;
        }
        public ucScheduleTest()
        {
            InitializeComponent();
            CenterLabelToPictureBox(lblError);
            CenterLabelToPictureBox(lblTitle);
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID,int ApplicationID=-1)
        {
            if (ApplicationID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = ApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID);

            if( _LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("Error: No Local Driving License Application with ID: " + LocalDrivingLicenseApplicationID.ToString(), "Error");
                btnSave.Enabled = false;
                return;
            }

            if (_LocalDrivingLicenseApplication.AttendedTest(_TestType))
                _CreationMode = enCreationMode.RetakeTest;
            else
                _CreationMode = enCreationMode.FirstTime;

            
            if (_CreationMode == enCreationMode.RetakeTest)
            {
                lblR_AppFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Retake_Test).ApplicationFees.ToString();
                lblTitle.Text = "Schedule Retake Test";
                CenterLabelToPictureBox(lblTitle);
                gbRetakeTest.Enabled = true;

                if (_Mode == enMode.AddNew)
                    lblReTest_AppID.Text = "Will be generated on save";
                else
                    lblReTest_AppID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            }
            else
            {
                gbRetakeTest.Enabled=false;
                lblTitle.Text = "Schedule Test";
                 CenterLabelToPictureBox(lblTitle);
                lblReTest_AppID.Text = "N/A";
                lblR_AppFees.Text = "0";
            }

            lblLocalDrivingLicenseApplicationID.Text= _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblClass.Text= _LocalDrivingLicenseApplication.LicenseClass.ClassName.ToString();
            lblPerson.Text= _LocalDrivingLicenseApplication.Person.FullName.ToString();
            lblTrialCount.Text= _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestType).ToString();

            if(_Mode==enMode.AddNew)
            {
                lblFees.Text=clsTestTypes.FindTestTypeByID(_TestType).TestTypeFees.ToString();
                dtpTestDate.MinDate=DateTime.Now;
                lblReTest_AppID.Text = "N/A";
                _TestAppointment =new clsTestAppointment();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            lblTotalFees.Text=(Convert.ToSingle(lblFees.Text)+ Convert.ToSingle(lblR_AppFees.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleApplicationLockedConstraint())
                return;


            if(!_HandlePreviouseTestConstraint())
                return;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_HandleRetakeApplication())
                { return; }

            _TestAppointment.TestTypeID = (int)_TestType;
            _TestAppointment.LocalDrivingLicenseApplicationID= _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID=clsGlobal.CurrentUser.UserID;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;

                lblReTest_AppID.Text = _TestAppointment.RetakeTestApplicationID != -1
                    ? _TestAppointment.RetakeTestApplicationID.ToString()
                    : "N/A";

                MessageBox.Show("Data Saves Successfully.", "Saved", MessageBoxButtons.OK);
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error: Data Is Not Saves Successfully.", "Error", MessageBoxButtons.OK);
            }

        }

        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }

        private void dtpTestDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gbRetakeTest_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalFees_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void lblReTest_AppID_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblR_AppFees_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void lblFees_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void lblTrialCount_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lblPerson_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblClass_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblLocalDrivingLicenseApplicationID_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void picBoxTestType_Click(object sender, EventArgs e)
        {

        }
    }
}
