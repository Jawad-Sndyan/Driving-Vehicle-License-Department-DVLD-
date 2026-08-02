using DVLD_Buisness;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmListDetainedLicenses : Form
    {
        private DataTable _dtDetainedLicenses;

        public frmListDetainedLicenses()
        {
            InitializeComponent();
            _SetupDataGridView();
        }

        private void _SetupDataGridView()
        {
            dgvDetainedLicenses.AutoGenerateColumns = false;
            colDID.DataPropertyName = "DetainID";
            colLID.DataPropertyName = "LicenseID";
            colDDate.DataPropertyName = "DetainDate";
            colIsReleased.DataPropertyName = "IsReleased";
            colFineFees.DataPropertyName = "FineFees";
            colReleaseDate.DataPropertyName = "ReleaseDate";
            colNationalNo.DataPropertyName = "NationalNo";
            colFullName.DataPropertyName = "FullName";
            colReleaseAppID.DataPropertyName = "ReleaseApplicationID";
        }

        private void _RefreshDetainedLicensesList()
        {
            _dtDetainedLicenses = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            DataView dv = _dtDetainedLicenses.DefaultView;
            lblRecords.Text = dv.Count.ToString();
        }

        private void _ApplyFilter()
        {
            if (_dtDetainedLicenses == null) return;

            string textFilter = txtSearch.Text.Trim();
            string comboFilter = cbFilter.Text == "Is Released"
                ? (cbSearch.SelectedItem?.ToString() ?? "All")
                : "None";

            if (string.IsNullOrEmpty(textFilter) && (comboFilter == "None" || comboFilter == "All"))
            {
                _RefreshDetainedLicensesList();
                lblRecords.Text = _dtDetainedLicenses.Rows.Count.ToString();
                return;
            }

            DataView dv = _dtDetainedLicenses.DefaultView;
            string filterExpression = "";

            if (comboFilter == "Released" || comboFilter == "Not Released")
                filterExpression = $"IsReleased = {(comboFilter == "Released" ? 1 : 0)}";

            if (!string.IsNullOrEmpty(textFilter))
            {
                string textExpression = "";
                switch (cbFilter.Text)
                {
                    case "Detain ID":
                        if (int.TryParse(textFilter, out int detainID))
                            textExpression = $"DetainID = {detainID}";
                        else
                            textExpression = "1 = 0";
                        break;

                    case "License ID":
                        if (int.TryParse(textFilter, out int licenseID))
                            textExpression = $"LicenseID = {licenseID}";
                        else
                            textExpression = "1 = 0";
                        break;

                    case "National No.":
                        textExpression = $"NationalNo LIKE '{textFilter}%'";
                        break;

                    case "Full Name":
                        textExpression = $"FullName LIKE '%{textFilter}%'";
                        break;
                }

                filterExpression = string.IsNullOrEmpty(filterExpression)
                    ? textExpression
                    : $"({filterExpression}) AND ({textExpression})";
            }

            dv.RowFilter = filterExpression;
            lblRecords.Text = dv.Count.ToString();
        }

        private int _GetSelectedDetainID()
        {
            if (dgvDetainedLicenses.CurrentRow == null) return -1;
            return (int)dgvDetainedLicenses.CurrentRow.Cells["colDID"].Value;
        }

        private int _GetSelectedLicenseID()
        {
            if (dgvDetainedLicenses.CurrentRow == null) return -1;
            return (int)dgvDetainedLicenses.CurrentRow.Cells["colLID"].Value;
        }

        private int _GetSelectedPersonID()
        {
            int licenseID = _GetSelectedLicenseID();
            if (licenseID == -1) return -1;

            clsLicense license = clsLicense.Find(licenseID);
            return license?.DriverID ?? -1;
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = cbFilter.FindString("None");
            txtSearch.Visible = false;
            cbSearch.Visible = false;
            _RefreshDetainedLicensesList();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshDetainedLicensesList();
            txtSearch.Text = "";
            string filter = cbFilter.Text;
            switch (filter)
            {
                case "None":
                    txtSearch.Visible = false;
                    cbSearch.Visible = false;
                    break;

                case "Detain ID":
                case "License ID":
                case "National No.":
                case "Full Name":
                    txtSearch.Visible = true;
                    cbSearch.Visible = false;
                    break;

                case "Is Released":
                    txtSearch.Visible = false;
                    cbSearch.Visible = true;
                    cbSearch.Items.Clear();
                    cbSearch.Items.AddRange(new object[] { "All", "Released", "Not Released" });
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
            int personID = _GetSelectedPersonID();
            if (personID == -1) return;

            frmPersonDetailes frm = new frmPersonDetailes(personID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licenseID = _GetSelectedLicenseID();
            if (licenseID == -1) return;

            frmShowLicenseInfo frm = new frmShowLicenseInfo(licenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = _GetSelectedPersonID();
            if (personID == -1) return;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(personID);
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int detainID = _GetSelectedDetainID();
            if (detainID == -1) return;

            bool isReleased = (bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
            if (isReleased)
            {
                MessageBox.Show("This license is already released.", "Already Released",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense(detainID);
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

       

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void cms_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            string filter = cbFilter.Text;
            switch (filter)
            {
                case "Detain ID":
                case "License ID":
                case "National No.":
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;

                case "Full Name":
                    e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
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
                case "Detain ID":
                case "License ID":
                    if (!clsValidator.IsNumber(txtSearch.Text.Trim()))
                        errorProvider.SetError(txtSearch, "This field accepts numbers only.");
                    else
                        errorProvider.SetError(txtSearch, "");
                    break;

                case "National No.":
                    if (!clsValidator.IsNumber(txtSearch.Text.Trim()))
                        errorProvider.SetError(txtSearch, "National No. accepts digits only.");
                    else
                        errorProvider.SetError(txtSearch, "");
                    break;

                case "Full Name":
                    if (!clsValidator.IsValidFullName(txtSearch.Text.Trim()))
                        errorProvider.SetError(txtSearch, "Full Name accepts letters only.");
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