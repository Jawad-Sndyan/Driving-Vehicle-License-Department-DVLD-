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
using static DVLD_Buisness.clsTestTypes;

namespace DVLD
{
    public partial class frmListTestAppointments : Form
    {
        private DataTable _dtTestAppointments;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;


        private void _LoadTestTypeImageAndCaption()
        {
            switch (_TestType)
            {
                case clsTestTypes.enTestType.VisionTest:
                    lblTitle.Text = "Vision Test";
                    picBoxTestType.BackgroundImage = Properties.Resources.Vision_512;
                    break;
                case clsTestTypes.enTestType.StreetTest:
                    lblTitle.Text = "Street Test";
                    picBoxTestType.BackgroundImage = Properties.Resources.driving_test_512;
                    break;
                case clsTestTypes.enTestType.WrittenTest:
                    lblTitle.Text = "Written Test";
                    picBoxTestType.BackgroundImage = Properties.Resources.Written_Test_512;
                    break;

            }
        }
        private void _SetupDataGridView()
        {
            dgvAppointment.AutoGenerateColumns = false;
            colAppointmentID.DataPropertyName = "TestAppointmentID";
            colAppointmentDate.DataPropertyName = "AppointmentDate";
            colPaidFees.DataPropertyName = "PaidFees";
            colIsLocked.DataPropertyName = "IsLocked";
        }
        private int _GetSelectedTestAppointmentID()
        {
            if (dgvAppointment.CurrentRow == null) return -1;
            return (int)dgvAppointment.CurrentRow.Cells[0].Value;
        }
        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _SetupDataGridView();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication=clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationInfoByID(_LocalDrivingLicenseApplicationID);

            if(LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Applicant Already have an active application for " + clsTestTypes.FindTestTypeByID(_TestType).TestTypeTitle.ToString(),"Error",MessageBoxButtons.OK);
                  return;
            }

            clsTest Test= LocalDrivingLicenseApplication.FindLastTestInfoPerTestType(_TestType);

            if(Test == null)
            {
                frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID,_TestType);
                frm.ShowDialog();
                _RefreshdgvTestAppointments();
                return;
            }

            if(Test.TestResult==true)
            {
                MessageBox.Show("Applicant Already have Passed " + clsTestTypes.FindTestTypeByID(_TestType).TestTypeTitle.ToString(), "Error", MessageBoxButtons.OK);
                return;
            }

            frmScheduleTest frm2 = new frmScheduleTest(Test.TestAppointment.LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            _RefreshdgvTestAppointments();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate= AutoValidate.Disable;
            this.Close();
        }

        public void _RefreshdgvTestAppointments()
        {
            _dtTestAppointments = clsTestAppointment.GetAllTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);
            dgvAppointment.DataSource = _dtTestAppointments;
            lblRecords.Text = dgvAppointment.Rows.Count.ToString();
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndCaption();
            ucDrivingLicenseApplicationInfo.LoadLocalDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);
            _RefreshdgvTestAppointments();
        }


      

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, _GetSelectedTestAppointmentID());
            frm.ShowDialog();
            _RefreshdgvTestAppointments();
        }

        private void dgvAppointment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm =new frmTakeTest(_GetSelectedTestAppointmentID(), _TestType);
            frm.ShowDialog();
            _RefreshdgvTestAppointments();
        }
    }
}
