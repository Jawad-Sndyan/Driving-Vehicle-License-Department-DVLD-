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
    public partial class ucUserCard : UserControl
    {
       
        private clsUser _User;
        private int _UserID = -1;
        public int UserID
        {
            get { return (_User != null) ? _User.UserID : -1; }
        }

       private void _FillUserInfo()
        {
            ucPersonCard.LoadPersonInfo(_User.PersonID);
            lblUserName.Text = _User.UserName;
            lblUserID.Text = _User.UserID.ToString();
            string IsActive = "";

            if (_User.IsActive)
                IsActive = "Yes";
            else
                IsActive = "No";

            lblActivation.Text = IsActive;

        }
        public ucUserCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;   
            _User =clsUser.FindByUserID(UserID);

            if( _User == null )
            {
                ResetUserInfo();
                MessageBox.Show("No User found with ID: " + UserID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        private void ucPersonCard1_Load(object sender, EventArgs e)
        {

        }
        public void ResetUserInfo()
        {
            ucPersonCard.ResetPersonInfo();
            lblUserName.Text = string.Empty;
            lblUserID.Text = string.Empty;
            lblActivation.Text = string.Empty;
        }
    }
}
