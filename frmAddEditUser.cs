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
    public partial class frmAddEditUser : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        private enum enMode { AddNew = 0, Update = 1 };
        private enum enIsActive { NotActive = 0, Active = 1 };


        private enMode _Mode;
        enIsActive _IsActive { get; set; }
        private int _UserID = -1;
        clsUser _User = null;

        private void _RestoreDefaultValues()
        {
            if(_Mode==enMode.AddNew)
            {
                lblMode.Text = "Add New User";
                tcLoginInfo.Enabled = true;
                _User=new clsUser();

            }
            else
            {
                lblMode.Text = "Update User";
                tcLoginInfo.Enabled = true;
                btnSave.Enabled = true;

            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbIsActive.Checked = true;
        }

        private void _LoadData()
        {
            _User = clsUser.FindByUserID(_UserID);
            ucPersonCardWithFilter.FilterEnalbled = false;

            if( _User == null )
            {
                MessageBox.Show("No User with ID = " + _UserID.ToString(), "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            cbIsActive.Checked = _User.IsActive;
           ucPersonCardWithFilter.LoadPersonInfo(_User.PersonID);

        }
        public frmAddEditUser()
        {
            InitializeComponent();

            _Mode=enMode.AddNew;    

        }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblPersonID_Click(object sender, EventArgs e)
        {

        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _RestoreDefaultValues();

            if( _Mode == enMode.Update )
                _LoadData();
        }

        private bool _ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            TextBox Temp = ((TextBox)sender);

            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(Temp, "This field is required!");
                return false;
            }
            else
            {
                errorProvider.SetError(Temp, null);

            }
            return true;


        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateEmptyTextBox(sender, e))
                return;

           
            if (!clsValidator.IsValidUsername(txtUserName.Text))
            {
                e.Cancel=true;
                errorProvider.SetError(txtUserName, "Username must be 3–20 characters long and contain only letters, numbers, or underscores.");
            }
            else
                errorProvider.SetError(txtUserName, null);

            if(_Mode==enMode.AddNew)
                if (clsUser.IsUserExistByUserName(txtUserName.Text))
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtUserName, $"UserName {txtUserName.Text} is for another User");
                }
                else
                    errorProvider.SetError(txtUserName, null);
            else
            {
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUser.IsUserExistByUserName(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider.SetError(txtUserName, null);
                    }
                ;
                }
            }
                 
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && !char.IsControl(e.KeyChar);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateEmptyTextBox(sender, e))
                return;

            if (!clsValidator.IsValidPassword(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, "Password must be digits only and at least 4 digits long.");
            }
            else
                errorProvider.SetError(txtPassword, null);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateEmptyTextBox(sender, e))
                return;

            if (!clsValidator.IsValidPassword(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtConfirmPassword, "Password must be digits only and at least 4 digits long.");
            }
            else
                errorProvider.SetError(txtConfirmPassword, null);

            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider.SetError(txtConfirmPassword, "Passwords do not match.");
            }
            else
            {
                errorProvider.SetError(txtConfirmPassword, "");
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid! \nPut the mouse over the red circle", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtPassword.Text;
            _User.UserName = txtUserName.Text;  
            _User.IsActive=cbIsActive.Checked;
            _User.PersonID=ucPersonCardWithFilter.PersonID;
            _User.UserID = _UserID;


            if (_User.Save())
            {
               lblUserID.Text = _User.UserID.ToString();
                _Mode = enMode.Update;
                lblMode.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DataBack?.Invoke(this, _User.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode==enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcLoginInfo.SelectedTab = tcLoginInfo.TabPages["tpLoginInfo"];
                return;
            }

            if(ucPersonCardWithFilter.PersonID!=-1)
            {
                if(clsUser.IsUserExistByPersonID(ucPersonCardWithFilter.PersonID))
                {
                    MessageBox.Show("Selected Person already is a user");
                    ucPersonCardWithFilter.FilterFocus();

                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcLoginInfo.SelectedTab = tcLoginInfo.TabPages["tpLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person");
                ucPersonCardWithFilter.FilterFocus();
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tpLoginInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
