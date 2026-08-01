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
    public partial class frmListDrivers : Form
    {
        private DataTable _dtAllDrivers;

        private void _SetupDataGridView()
        {
            dgvDrivers.AutoGenerateColumns = false;
            colDriverID.DataPropertyName = "DriverID";
            colPersonID.DataPropertyName = "PersonID";
            colNationalNo.DataPropertyName = "NationalNo";
            colName.DataPropertyName = "FullName";
            colDate.DataPropertyName = "CreatedDate";
            colActiveLicenses.DataPropertyName = "NumberOfActiveLicenses";
        }

        private void _RefreshDriversList()
        {
            _dtAllDrivers =clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _dtAllDrivers;
            DataView dv = _dtAllDrivers.DefaultView;
            lblRecords.Text = dv.Count.ToString();
        }
        private int _GetSelectedPersonID()
        {
            if (dgvDrivers.CurrentRow == null) return -1;
            return (int)dgvDrivers.CurrentRow.Cells[1].Value;
        }

        private void _ApplyFilter()
        {
            if (dgvDrivers == null) return;

            string textFilter = txtSearch.Text.Trim();

            string filterExpression = "";

            DataView dv = _dtAllDrivers.DefaultView;
            if (!string.IsNullOrEmpty(textFilter))
            {
                string textExpression = "";
                switch (cbFilter.Text)
                {
                    case "Driver ID":
                        if (int.TryParse(textFilter, out int driverID))
                            textExpression = $"DriverID = {driverID}";
                        else
                            textExpression = "1 = 0";
                        break;
                    case "Person ID":
                        if (int.TryParse(textFilter, out int personID))
                            textExpression = $"PersonID = {personID}";
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

                filterExpression = textExpression;
            }

            dv.RowFilter = filterExpression;
            lblRecords.Text = dv.Count.ToString();
        }
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _SetupDataGridView();
            cbFilter.SelectedIndex = 0;
            _RefreshDriversList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate= AutoValidate.Disable;
            this.Close();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshDriversList();
            txtSearch.Text = "";
            string Filter = cbFilter.Text;
            switch (Filter)
            {
                case "None":
                    txtSearch.Visible = false;
                    break;
                case "Driver ID":
                case "PersonID":
                case "National No.":
                case "Full Name":
                    txtSearch.Visible = true;
                    break;
                default:

                    break;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            string filter = cbFilter.Text;


            switch (filter)
            {
                case "Full Name":
                    e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;

                case "Driver ID":
                case "PersonID":
                case "National No.":
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;

                default:
                    break;
            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetailes frm=new frmPersonDetailes(_GetSelectedPersonID());
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(_GetSelectedPersonID());
            frm.ShowDialog();
        }
    }
}
