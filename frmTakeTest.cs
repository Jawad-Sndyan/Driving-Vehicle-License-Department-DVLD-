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
    public partial class frmTakeTest : Form
    {

        private int _AppointmentID = -1;
        private clsTestTypes.enTestType _TestType= clsTestTypes.enTestType.VisionTest;
        private clsTest _Test = null;
        public frmTakeTest(int AppointmentID, clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestType = TestType;
            lblError.Visible=false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate=AutoValidate.Disable;
            this.Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ucScheduledTest.TestType = _TestType;
            ucScheduledTest.LoadInfo(_AppointmentID);

            if(ucScheduledTest.TestAppointmentID==-1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            int TestID = ucScheduledTest.TestID;
            if(TestID!=-1)
            {
                _Test=clsTest.FindTestInfoByID(TestID);

                if(_Test!=null)
                {
                    if(_Test.TestResult==true)
                        rbPass.Checked = true;
                    else
                        rbFail.Checked = true;

                    txtNotes.Text=_Test.Notes.ToString();

                    lblError.Visible = true;
                    rbPass.Enabled = false;
                    rbFail.Enabled = false;

                }
            }
            else
                _Test=new clsTest();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to Save","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            _Test.TestAppointmentID = _AppointmentID;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.TestResult=rbPass.Checked;
            _Test.CreatedByUserID=clsGlobal.CurrentUser.UserID;

            if(_Test.Save())
            {
                MessageBox.Show("Data Saved Susessfully", "Success", MessageBoxButtons.OK);
                btnSave.Enabled = false;
                return;
            }
            else
                MessageBox.Show("Error: Data di not Saved", "Error", MessageBoxButtons.OK);

        }
    }
}
