using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ucDriverLicenses : UserControl
    {

        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtLocalLicenses;
        private DataTable _dtInternationalLisenses;


        private void _SetupDataGridView()
        {
            dgvLocalDriverLicenses.AutoGenerateColumns = false;
            colLicenseID.DataPropertyName = "LicenseID";
            colApplicationID.DataPropertyName = "ApplicationID";
            colClassName.DataPropertyName = "ClassName";
            colIssueDate.DataPropertyName = "IssueDate";
            colExpirationDate.DataPropertyName = "ExpirationDate";
            colIsActive.DataPropertyName = "IsActive";

            dgvInternationalDriverLicenses.AutoGenerateColumns = false;
            colInternationalLicenseID.DataPropertyName = "InternationalLicenseID";
            colAppID.DataPropertyName = "ApplicationID";
            colLocalLicenseID.DataPropertyName = "IssuedUsingLocalLicenseID";
            colIssDate.DataPropertyName = "IssueDate";
            colExpDate.DataPropertyName = "ExpirationDate";
            colActive.DataPropertyName = "IsActive";
        }
        
        private void _RefreshInternationalLicenseList()
        {
            _dtInternationalLisenses =clsInternationalLicense.GetDriverInternationalLicenses(_DriverID);
            dgvInternationalDriverLicenses.DataSource= _dtInternationalLisenses;
            DataView dv = _dtInternationalLisenses.DefaultView;
            lblRecords.Text = dv.Count.ToString();
        }


        private void _RefreshLocalLicenseList()
        {
            _dtLocalLicenses = clsLicense.GetDriverLicense(_DriverID);
            dgvLocalDriverLicenses.DataSource = _dtLocalLicenses;
            DataView dv = _dtLocalLicenses.DefaultView;
            lblRecords.Text = dv.Count.ToString();
        }


        private int _GetSelectedLocalLisense()
        {
            if (dgvLocalDriverLicenses.CurrentRow == null) return -1;
            return (int)dgvLocalDriverLicenses.CurrentRow.Cells[0].Value;
        }

        private int _GetSelectedInternationalLisense()
        {
            if (dgvInternationalDriverLicenses.CurrentRow == null) return -1;
            return (int)dgvInternationalDriverLicenses.CurrentRow.Cells[0].Value;
        }


        public ucDriverLicenses()
        {
            InitializeComponent();
        }

        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.FindDriverInfoByID(_DriverID);

            if( _Driver == null )
            {
                MessageBox.Show("There is no driver with id = " + _DriverID.ToString());
                return;
            }
            _SetupDataGridView();
            _RefreshInternationalLicenseList();
            _RefreshLocalLicenseList();



        }

        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver=clsDriver.FindDriverInfoByPersonID(PersonID);

            if (_Driver == null)
            {
                MessageBox.Show("There is no Driver Linked with Person ID  " + PersonID.ToString());
                return;
            }

            _DriverID = _Driver.DriverID;
            _SetupDataGridView();
            _RefreshInternationalLicenseList();
            _RefreshLocalLicenseList();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void showLocalLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_GetSelectedLocalLisense());
            frm.ShowDialog();   
        }

        private void showInternationalLisenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_GetSelectedInternationalLisense());
            frm.ShowDialog();
        }

        public void Clear()
        {
            _dtLocalLicenses.Clear();
            _dtInternationalLisenses.Clear();
        }
    }
}
