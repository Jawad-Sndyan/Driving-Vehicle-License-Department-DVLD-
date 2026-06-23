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
    public partial class ucApplicationBasicInfo : UserControl
    {

        private clsApplication _Application;

        public int ApplicationID
        {
            get { return (_Application != null) ? _Application.ApplicationID : -1; }
        }
        private void FillApplicationInfo()
        {
            lblAppID.Text= ApplicationID.ToString();
            lblStatus.Text= _Application.StatusText;
            lblFees.Text= _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationType.ApplicationTypeTitle;
            lblApplicant.Text = _Application.Person.FullName;
            lblDate.Text = _Application.ApplicationDate.ToShortDateString();
           lblStatusDate.Text= _Application.LastStatusDate.ToShortDateString();
            lblUser.Text= _Application.User.UserName;
        }
        public ucApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(int applicationID)
        {
            _Application = clsApplication.FindBaseApplicationByID(applicationID);

            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application found with ID: " + applicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillApplicationInfo();
        }

        public void ResetApplicationInfo()
        {
            lblAppID.Text = "???";
            lblStatus.Text = "???";
            lblFees.Text = "???";
            lblType.Text = "???";
            lblApplicant.Text = "???";
            lblDate.Text = "???";
            lblStatusDate.Text = "???";
            lblUser.Text = "???";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabelViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetailes frm = new frmPersonDetailes(_Application.PersonID);

            frm.ShowDialog();

            LoadApplicationInfo(ApplicationID);
        }
    }
}
