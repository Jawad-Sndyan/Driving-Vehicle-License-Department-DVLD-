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
    public partial class frmListLocalDrivingLicenseApplication : Form
    {
        private DataTable _dtLocalDrivingLicenseApplications;

        private void _SetupDataGridView()
        {
            dgvLDLApp.AutoGenerateColumns = false;
            colLDLAppID.DataPropertyName = "LocalDrivingLicenseApplicationID";
            colDrivingClass.DataPropertyName = "ClassName";
            colNationalNo.DataPropertyName = "NationalNo";
            colFullName.DataPropertyName = "FullName";
            colPassedTests.DataPropertyName = "Pass";
            colStatus.DataPropertyName = "Status";
        }

        private void _RefreshLocalDrivingLicenseApplicationsList()
        {
            _dtLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLDLApp.DataSource = _dtLocalDrivingLicenseApplications;
            DataView dv = _dtLocalDrivingLicenseApplications.DefaultView;
            lblRecords.Text= dv.Count.ToString();   

        }

        private void _ApplyFilter()
        {
            if (_dtLocalDrivingLicenseApplications == null) return;

            string textFilter = txtSearch.Text.Trim();
            string comboFilter = cbSearch.SelectedItem?.ToString();

           
            if (cbFilter.Text == "Status")
            {
                DataView dv = _dtLocalDrivingLicenseApplications.DefaultView;
                dv.RowFilter = string.IsNullOrEmpty(comboFilter)
                    ? ""
                    : $"Status = '{comboFilter}'";
                lblRecords.Text = dv.Count.ToString();
                return;
            }

            if (string.IsNullOrEmpty(textFilter))
            {
                _RefreshLocalDrivingLicenseApplicationsList();
                lblRecords.Text = _dtLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            DataView dv2 = _dtLocalDrivingLicenseApplications.DefaultView;
            string textExpression = "";

            switch (cbFilter.Text)
            {
                case "L.D.L.AppID":
                    if (int.TryParse(textFilter, out int appID))
                        textExpression = $"LocalDrivingLicenseApplicationID = {appID}";
                    else
                        textExpression = "1 = 0";
                    break;

                case "National No.":
                    textExpression = $"NationalNo LIKE '{textFilter}%'";
                    break;

                case "Full Name":
                    textExpression = $"FullName LIKE '{textFilter}%'";
                    break;
            }

            dv2.RowFilter = textExpression;
            lblRecords.Text = dv2.Count.ToString();
        }

        private int _GetSelectedLocalDrivingLicenseApplication()
        {
            if (dgvLDLApp.CurrentRow == null) return -1;
            return (int)dgvLDLApp.CurrentRow.Cells[0].Value;
        }

        public frmListLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _SetupDataGridView();
        }

        private void frmListLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = cbFilter.FindString("None");
            txtSearch.Visible = false;
            cbSearch.Visible = false;
            _RefreshLocalDrivingLicenseApplicationsList();
            lblRecords.Text = dgvLDLApp.RowCount.ToString();
        }

        private void btnAddLDLApp_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            this.Close();
        }

       

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            string filter = cbFilter.Text;
            switch (filter)
            {
                case "Full Name":
                    e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;
                case "L.D.L.AppID":
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;
                case "National No.":
                    e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;
                default:
                    break;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshLocalDrivingLicenseApplicationsList();
            txtSearch.Text = "";

            string filter = cbFilter.Text;
            switch (filter)
            {
                case "None":
                    txtSearch.Visible = false;
                    cbSearch.Visible = false;
                    break;
                case "L.D.L.AppID":
                case "National No.":
                case "Full Name":
                    txtSearch.Visible = true;
                    cbSearch.Visible = false;
                    break;
                case "Status":
                    txtSearch.Visible = false;
                    cbSearch.Visible = true;
                    cbSearch.SelectedIndex = -1;
                    break;
                default:
                    break;
            }
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetSelectedLocalDrivingLicenseApplication();
            if (ID == -1)
                return;

            frmDrivingLicenseApplicationInfo frm = new frmDrivingLicenseApplicationInfo(ID);
            frm.Show();
        }

        private void addNewApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddLDLApp_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetSelectedLocalDrivingLicenseApplication();
            if (ID == -1)
                return;
            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication(ID);
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();

        }

        private void CancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this Appliction\nApplictionID:" + _GetSelectedLocalDrivingLicenseApplication().ToString(), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication=clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationInfoByID(_GetSelectedLocalDrivingLicenseApplication());

            if (LocalDrivingLicenseApplication != null)
            {
                LocalDrivingLicenseApplication.Cancel();
                _RefreshLocalDrivingLicenseApplicationsList();
            }

        }
    }
}