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
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }


        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && !char.IsControl(e.KeyChar);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindUserInfoByUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (User != null)
            {
                if (chkRememberMe.Checked)
                {

                    clsGlobal.SaveCredentials(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                    clsGlobal.SaveCredentials("", "");

                if (!User.IsActive)
                    MessageBox.Show("Your account is not active, contact Admin", "Inactive account");


                clsGlobal.CurrentUser = User;
                this.Hide();
                MessageBox.Show("Sucsess");

            }
            else
                MessageBox.Show("Invalid Username/Password", "Wrong Credentials");
                
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";

            if(clsGlobal.RetrieveCredentials(ref Username, ref Password))
            {
                txtPassword.Text = Password;
                txtUsername.Text = Username;
                chkRememberMe.Checked = true;
                btnLogin.Focus();
            }
            else
                chkRememberMe.Checked = false;  
        }
    }
}
