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
    public partial class frmListInternationalLicenseApplications : Form
    {
        private DataTable _dtInternationalLicenseApplications;

        public frmListInternationalLicenseApplications()
        {
            InitializeComponent();
            _SetupDataGridView();
        }

        private void _SetupDataGridView()
        {
            dgvApplications.AutoGenerateColumns = false;
            colIntLicenseID.DataPropertyName = "InternationalLicenseID";
            colAppID.DataPropertyName = "ApplicationID";
            colDriverID.DataPropertyName = "DriverID";
            colLLicenseID.DataPropertyName = "IssuedUsingLocalLicenseID";
            colIssueDate.DataPropertyName = "IssueDate";
            colExpirationDate.DataPropertyName = "ExpirationDate";
            colIsActive.DataPropertyName = "IsActive";
        }

        private void _RefreshApplicationsList()
        {
            _dtInternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            dgvApplications.DataSource = _dtInternationalLicenseApplications;
            DataView dv = _dtInternationalLicenseApplications.DefaultView;
            lblRecords.Text = dv.Count.ToString();
        }

        private void _ApplyFilter()
        {
            if (_dtInternationalLicenseApplications == null) return;

            string textFilter = txtSearch.Text.Trim();
            string comboFilter = cbFilter.Text == "Is Active"
                ? (cbSearch.SelectedItem?.ToString() ?? "All")
                : "None";

            if (string.IsNullOrEmpty(textFilter) && (comboFilter == "None" || comboFilter == "All"))
            {
                _RefreshApplicationsList();
                lblRecords.Text = _dtInternationalLicenseApplications.Rows.Count.ToString();
                return;
            }

            DataView dv = _dtInternationalLicenseApplications.DefaultView;
            string filterExpression = "";

            if (comboFilter == "Active" || comboFilter == "Not Active")
                filterExpression = $"IsActive = {(comboFilter == "Active" ? 1 : 0)}";

            if (!string.IsNullOrEmpty(textFilter))
            {
                string textExpression = "";
                switch (cbFilter.Text)
                {
                    case "International License ID":
                        if (int.TryParse(textFilter, out int intLicenseID))
                            textExpression = $"InternationalLicenseID = {intLicenseID}";
                        else
                            textExpression = "1 = 0";
                        break;

                    case "Application ID":
                        if (int.TryParse(textFilter, out int applicationID))
                            textExpression = $"ApplicationID = {applicationID}";
                        else
                            textExpression = "1 = 0";
                        break;

                    case "Driver ID":
                        if (int.TryParse(textFilter, out int driverID))
                            textExpression = $"DriverID = {driverID}";
                        else
                            textExpression = "1 = 0";
                        break;

                    case "Local License ID":
                        if (int.TryParse(textFilter, out int localLicenseID))
                            textExpression = $"LocalLicenseID = {localLicenseID}";
                        else
                            textExpression = "1 = 0";
                        break;
                }

                filterExpression = string.IsNullOrEmpty(filterExpression)
                    ? textExpression
                    : $"({filterExpression}) AND ({textExpression})";
            }

            dv.RowFilter = filterExpression;
            lblRecords.Text = dv.Count.ToString();
        }

        private int _GetSelectedIntLicenseID()
        {
            if (dgvApplications.CurrentRow == null) return -1;
            return (int)dgvApplications.CurrentRow.Cells["colIntLicenseID"].Value;
        }

        private int _GetSelectedInterbationalLicenseID()
        {
            if (dgvApplications.CurrentRow == null) return -1;
            return (int)dgvApplications.CurrentRow.Cells[0].Value;
        }

        private int _GetSelectedDriverID()
        {
            if (dgvApplications.CurrentRow == null) return -1;
            return (int)dgvApplications.CurrentRow.Cells["colDriverID"].Value;
        }

        private void frmListInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = cbFilter.FindString("None");
            txtSearch.Visible = false;
            cbSearch.Visible = false;
            _RefreshApplicationsList();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshApplicationsList();
            txtSearch.Text = "";
            string filter = cbFilter.Text;
            switch (filter)
            {
                case "None":
                    txtSearch.Visible = false;
                    cbSearch.Visible = false;
                    break;

                case "International License ID":
                case "Application ID":
                case "Driver ID":
                case "Local License ID":
                    txtSearch.Visible = true;
                    cbSearch.Visible = false;
                    break;

                case "Is Active":
                    txtSearch.Visible = false;
                    cbSearch.Visible = true;
                    cbSearch.Items.Clear();
                    cbSearch.Items.AddRange(new object[] { "All", "Active", "Not Active" });
                    cbSearch.SelectedIndex = cbSearch.FindString("All");
                    break;

                default:
                    break;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => _ApplyFilter();

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e) => _ApplyFilter();

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int driverID = _GetSelectedDriverID();
            if (driverID == -1) return;

            clsDriver driver = clsDriver.FindDriverInfoByID(driverID);
            if (driver == null) return;

            frmPersonDetailes frm = new frmPersonDetailes(driver.PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int internationalLicenseID = _GetSelectedInterbationalLicenseID();
            if (internationalLicenseID == -1) return;

            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(internationalLicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int driverID = _GetSelectedDriverID();
            if (driverID == -1) return;

            clsDriver driver = clsDriver.FindDriverInfoByID(driverID);
            if (driver == null) return;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(driver.PersonID);
            frm.ShowDialog();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        private void cms_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgvApplications.CurrentRow == null)
                e.Cancel = true;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            string filter = cbFilter.Text;
            switch (filter)
            {
                case "International License ID":
                case "Application ID":
                case "Driver ID":
                case "Local License ID":
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;

                default:
                    break;
            }
        }

        private void txtSearch_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string filter = cbFilter.Text;
            string value = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(value))
            {
                errorProvider.SetError(txtSearch, "This field is required");
                return;
            }

            switch (filter)
            {
                case "International License ID":
                case "Application ID":
                case "Driver ID":
                case "Local License ID":
                    if (!clsValidator.IsNumber(txtSearch.Text.Trim()))
                        errorProvider.SetError(txtSearch, "This field accepts numbers only.");
                    else
                        errorProvider.SetError(txtSearch, "");
                    break;

                default:
                    errorProvider.SetError(txtSearch, "");
                    break;
            }
        }
    }
}