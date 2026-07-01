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
using static DVLD_Buisness.clsApplication;

namespace DVLD
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _Local_D_L_App_ID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;

        private void _LoadCoboBox()
        {
            DataTable dtAllLicenseClass = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow dataRow in dtAllLicenseClass.Rows)
            {
                cbLicenseClass.Items.Add((dataRow["ClassName"]).ToString());
            }
        }
        private void _RestoreDefaultValues()
        {
            _LoadCoboBox();
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                tcApplicationInfo.Enabled = true;

                ucPersonCardWithFilter.FilterFocus();
                tpApplicationInfo.Enabled = false;
                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.New_LocalDriving_License_Service).ApplicationFees.ToString();
                lblDate.Text = DateTime.Now.ToShortDateString();
                lblUser.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblMode.Text = "Update Local Driving License Application";
                tcApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            lblDLAppID.Text = string.Empty;
        }



        private void _LoadData()
        {
            ucPersonCardWithFilter.FilterEnalbled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationInfoByID(_Local_D_L_App_ID);
            ucPersonCardWithFilter.FilterEnalbled = false;

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Local Driving License Application with ID = " + _Local_D_L_App_ID.ToString(), "Local Driving License Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ucPersonCardWithFilter.LoadPersonInfo(_LocalDrivingLicenseApplication.PersonID);
            lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblUser.Text = _LocalDrivingLicenseApplication.User.UserName.ToString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LocalDrivingLicenseApplication.LicenseClass.ClassName);

        }
        public frmAddEditLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditLocalDrivingLicenseApplication(int local_D_L_App_ID)
        {
            InitializeComponent();
            _Local_D_L_App_ID = local_D_L_App_ID;
            _Mode = enMode.Update;
        }

        private void frmAddEditLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _RestoreDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenceClassID = clsLicenseClass.FindByClassName(cbLicenseClass.Text).LicenseClassID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(ucPersonCardWithFilter.PersonID, (int)clsApplication.enApplicationTypes.New_LocalDriving_License_Service, LicenceClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choos another Licence Class,Choosen Person allready has an Application for selected class with id: " + ActiveApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbLicenseClass.Focus();
                return;
            }

            int AccomplishedApplicationID = clsApplication.GetAccomplishedApplicationIDForLicenseClass(ucPersonCardWithFilter.PersonID, (int)clsApplication.enApplicationTypes.New_LocalDriving_License_Service, LicenceClassID);

            if (AccomplishedApplicationID != -1)
            {
                MessageBox.Show("Choos another Licence Class,Choosen Person allready has Local Driving License in "+ cbLicenseClass.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbLicenseClass.Focus();
                return;
            }

            _LocalDrivingLicenseApplication.PersonID = ucPersonCardWithFilter.PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (clsApplication.enApplicationTypes)1;
            _LocalDrivingLicenseApplication.Status = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicenseApplication.UserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenceClassID;


            if (_LocalDrivingLicenseApplication.Save())
            {

                lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                lblMode.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Error: Data Is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ucPersonCardWithFilter_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void frmAddEditLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ucPersonCardWithFilter.FilterFocus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }

            if (ucPersonCardWithFilter.PersonID == -1)
            {
                MessageBox.Show("Please Select a Person");
                ucPersonCardWithFilter.FilterFocus();
                return; 
            }

          
            tpApplicationInfo.Enabled = true;
            tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            this.Close();   
        }
    }
}
