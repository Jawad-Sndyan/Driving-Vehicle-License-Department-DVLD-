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
    public partial class FrmChangePassword : Form
    {
        private int _UserID = -1;
        private clsUser _User;
        private bool _isClosing = false;

        private void ResetDefaultValues()
        {
            ucUserCard.ResetUserInfo(); 
            txtConfirmPassword.Text=string.Empty;
            txtCurrentPassword.Text=string.Empty;
            txtNewPassword.Text=string.Empty;   
            txtConfirmPassword.Focus(); 
        }
        public FrmChangePassword(int UserID)
        {
            InitializeComponent();
            btnClose.CausesValidation = false;
            _UserID =UserID;
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            _User = clsUser.FindByUserID(_UserID);
            if(_User==null)
            {
                ResetDefaultValues();
                MessageBox.Show("No User with ID = " + _UserID.ToString(), "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ucUserCard.LoadUserInfo(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _isClosing = true;
            this.Close();
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
        private void _Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtCurrentPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Password_KeyPress(sender, e);
        }

        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Password_KeyPress(sender, e);
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Password_KeyPress(sender, e);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

            if (_isClosing) return;
            if (!_ValidateEmptyTextBox(sender, e))
                return;

            if (!clsValidator.IsValidPassword(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtCurrentPassword, "Password must be digits only and at least 4 digits long.");
            }
            else
                errorProvider.SetError(txtCurrentPassword, null);

            if(txtCurrentPassword.Text.Trim()!=_User.Password)
            {
                e.Cancel = true;
                errorProvider.SetError(txtCurrentPassword, "Current Password is wrong.");
            }
            else
                errorProvider.SetError(txtCurrentPassword, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_isClosing) return;
            if (txtConfirmPassword.TextLength!=0)
                if (!_ValidateEmptyTextBox(sender, e))
                    return;

            if (!clsValidator.IsValidPassword(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtConfirmPassword, "Password must be digits only and at least 4 digits long.");
            }
            else
                errorProvider.SetError(txtConfirmPassword, null);

            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider.SetError(txtConfirmPassword, "Passwords do not match.");
            }
            else
            {
                errorProvider.SetError(txtConfirmPassword, "");
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_isClosing) return;
            if (!_ValidateEmptyTextBox(sender, e))
                return;

            if (!clsValidator.IsValidPassword(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNewPassword, "Password must be digits only and at least 4 digits long.");
            }
            else
                errorProvider.SetError(txtNewPassword, null);

            if (txtNewPassword.Text.Trim() == _User.Password)
            {
                e.Cancel = true;
                errorProvider.SetError(txtNewPassword, "New Password should be deferent from Current Password.");
            }
            else
                errorProvider.SetError(txtNewPassword, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid! \nPut the mouse over the red circle", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtNewPassword.Text;


            if (_User.Save())
            {

                MessageBox.Show("Password Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ResetDefaultValues();
            }
            else
                MessageBox.Show("Password Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
