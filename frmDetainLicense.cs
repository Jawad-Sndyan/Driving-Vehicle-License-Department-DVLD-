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
    public partial class frmDetainLicense : Form
    {

        private int _DetainedID=-1;
        private int _SelectedLicenseID = -1;
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate= AutoValidate.Disable;
            this.Close();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblUser.Text=clsGlobal.CurrentUser.UserName;
        }

        private void ucDriverLicenseInfoWithFilter_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID= obj;

            lblLicenseID.Text= _SelectedLicenseID.ToString();

            linkLabelShowLicensesInfo.Enabled = (_SelectedLicenseID != -1);

            if(_SelectedLicenseID == -1)
                return;

            if(ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is already detained, choose another one.","Detain Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);

                btnDetain.Enabled = false;

                return;
            }

            txtFineFees.Focus();    
            btnDetain.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to detain this license?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) 
                { return; }

            _DetainedID = ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text), clsGlobal.CurrentUser.UserID);


            if( _DetainedID == -1)
            {
                MessageBox.Show("Failed to Detain License", "Detain Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnDetain.Enabled = false;

                return;
            }

            lblDetainID.Text=_DetainedID.ToString();

            MessageBox.Show("License Detained Successfully\nID = "+_DetainedID.ToString(), "Detain Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDetain.Enabled = false;
            ucDriverLicenseInfoWithFilter.Enabled = false;
            txtFineFees.Enabled = false;
            linkLabelShowLicensesInfo.Enabled = true;


        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm=new frmShowPersonLicenseHistory(ucDriverLicenseInfoWithFilter.SelectedLicenseInfo.Driver.PersonID);
            frm.ShowDialog();
        }

        private void linkLabelShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtFineFees, "This field is required!");
                return;
            }
            else
            {
                errorProvider.SetError(txtFineFees, null);

            }


            if (!clsValidator.IsNumber(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtFineFees, "Fine Fees must be digits only.");
            }
            else
                errorProvider.SetError(txtFineFees, null);


        }
    }
}
