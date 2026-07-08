using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ucDriverLicenseInfoWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;

        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler= OnLicenseSelected;

            if(handler != null)
            {
                handler(LicenseID);
            }
        }
        public ucDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set 
            {
                _FilterEnabled = value; 
                gbFilter.Enabled = value;
            }
        }

        private int _LicenseID = -1;
        public int LicenseID
        {
            get
            {
                return ucDriverLicenseInfo.LicenseID;
            }
        }

        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return ucDriverLicenseInfo.SelecetedLicense;
            }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            txtFilter.Text = LicenseID.ToString();
            ucDriverLicenseInfo.LoadLicenseInfo(LicenseID);
            _LicenseID= ucDriverLicenseInfo.LicenseID ;
            if(OnLicenseSelected!=null && FilterEnabled)
                OnLicenseSelected(LicenseID);
        }
        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid! \nPut the mouse over the red circle", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilter.Focus();
                return;
            }
            _LicenseID=int.Parse(txtFilter.Text);
            LoadLicenseInfo(_LicenseID);
        }

        public void txtFilterFocus()
        {
            txtFilter.Focus();
        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilter.Text.Trim()))
                {
                e.Cancel = true;
                errorProvider.SetError(txtFilter, "This Field is required \nPut the mouse over the red circle");
            }
            else
            {
                errorProvider.SetError(txtFilter,null);
            }

            if(clsValidator.IsNumber(txtFilter.Text.Trim()))
                errorProvider.SetError(txtFilter, null);
            else
            {
                e.Cancel = true;
                errorProvider.SetError(txtFilter, "License ID is a Digit");
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar);
        }
    }
}
