using DVLD_Buisness;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmListPeople : Form
    {
        private DataTable _dtPeople;
        


        private void _SetupDataGridView()
        {
            dgvPeople.AutoGenerateColumns = false;
            colID.DataPropertyName = "PersonID";
            colNationalNo.DataPropertyName = "NationalNo";
            colFirstName.DataPropertyName = "FirstName";
            colSecondName.DataPropertyName = "SecondName";
            colThirdName.DataPropertyName = "ThirdName";
            colLastName.DataPropertyName = "LastName";
            colGendor.DataPropertyName = "GendorCaption";
            colDOB.DataPropertyName = "DateOfBirth";
            colEmail.DataPropertyName = "Email";
            colPhone.DataPropertyName = "Phone";
            colNationality.DataPropertyName = "CountryName";
        }

        private void _LoadSearchComboBox()
        {

            cbSearch.Items.Clear();
            switch (cbFilter.Text)
            {
                case "Gendor":
                    cbSearch.SelectedIndex = cbSearch.FindString("All");
                    break;

                case "Nationality":
                    DataTable dtCountries = clsCountry.GetAllCountries();
                    foreach (DataRow row in dtCountries.Rows)
                        cbSearch.Items.Add(row["CountryName"].ToString());

                    cbSearch.SelectedIndex = cbSearch.FindString("Syria");
                    break;

            }

        }


        private void _ApplyFilter()
        {
            if (_dtPeople == null) return;

            string textFilter = txtSearch.Text.Trim();
            string comboFilter = cbSearch.SelectedItem?.ToString() ?? "None";

            if (string.IsNullOrEmpty(textFilter) && (comboFilter == "None" || comboFilter == "All"))
            {
                _RefreshPeopleList();
                lblRecords.Text = _dtPeople.Rows.Count.ToString();
                return;  
            }

            DataView dv = _dtPeople.DefaultView;   
            string filterExpression = "";

            if (comboFilter == "Male" || comboFilter == "Female")
                filterExpression = $"GendorCaption = '{comboFilter}'";
            else if (comboFilter != "All" && comboFilter != "None")
            {
                clsCountry country = clsCountry.Find(comboFilter);
                if (country != null)
                    filterExpression = $"NationalityCountryID = {country.ID}";
            }

            if (!string.IsNullOrEmpty(textFilter))
            {
                string textExpression = "";
                switch (cbFilter.Text)
                {
                    case "PersonID":         
                        if (int.TryParse(textFilter, out int personID))
                            textExpression = $"PersonID = {personID}";
                        else
                            textExpression = "1 = 0";
                        break;

                    case "National No.":
                        textExpression = $"NationalNo LIKE '{textFilter}%'";
                        break;
                    case "First Name":
                        textExpression = $"FirstName LIKE '{textFilter}%'";
                        break;
                    case "Second Name":
                        textExpression = $"SecondName LIKE '{textFilter}%'";
                        break;
                    case "Third Name":
                        textExpression = $"ThirdName LIKE '{textFilter}%'";
                        break;
                    case "Last Name":
                        textExpression = $"LastName LIKE '{textFilter}%'";
                        break;
                    case "Phone":
                        textExpression = $"Phone LIKE '{textFilter}%'";
                        break;
                    case "Email":
                        textExpression = $"Email LIKE '{textFilter}%'";
                        break;
                }

                filterExpression = string.IsNullOrEmpty(filterExpression)
                    ? textExpression
                    : $"({filterExpression}) AND ({textExpression})";
            }

            dv.RowFilter = filterExpression;
            lblRecords.Text = dv.Count.ToString();
        }
        private void _RefreshPeopleList()
        {
            _dtPeople = clsPerson.GetAllPeople();
            dgvPeople.DataSource = _dtPeople;
        }



        private int _GetSelectedPersonID()
        {
            if (dgvPeople.CurrentRow == null) return -1;
            return (int)dgvPeople.CurrentRow.Cells[0].Value;
        }


        public frmListPeople()
        {
            InitializeComponent();
            _SetupDataGridView();
        }


        private void frmListPeople_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = cbFilter.FindString("PersonID");
            txtSearch.Visible = true;
            cbSearch.Visible = false;
            _RefreshPeopleList();
            lblRecords.Text = dgvPeople.RowCount.ToString();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
            => addNewPersonToolStripMenuItem_Click(sender, e);

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = _GetSelectedPersonID();
            if (personID == -1) return;

            frmPersonDetailes frm = new frmPersonDetailes(personID);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = _GetSelectedPersonID();
            if (personID == -1) return;

            frmAddUpdatePerson frm = new frmAddUpdatePerson(personID);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = _GetSelectedPersonID();
            if (personID == -1) return;

            if (MessageBox.Show("Are you sure you want to delete this person?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsPerson.DeletePerson(personID))
                {
                    MessageBox.Show("Person deleted successfully.", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Failed to delete. Person may be linked to other records.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPeople_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int personID = _GetSelectedPersonID();
                if (personID == -1) return;

                frmFindPerson frm = new frmFindPerson(personID);
                frm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e) => _ApplyFilter();



        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            txtSearch.Text = "";
            string Filter = cbFilter.Text;
            switch (Filter)
            {
                case "None":
                    txtSearch.Visible = false;
                    cbSearch.Visible = false;
                    break;
                case "PersonID":
                case "National No.":
                case "First Name":
                case "Second Name":
                case "Third Name":
                case "Last Name":
                case "Phone":
                case "Email":
                    txtSearch.Visible = true;
                    cbSearch.Visible = false;
                    break;
                case "Gendor":
                case "Nationality":
                    txtSearch.Visible = false;
                    cbSearch.Visible = true;
                    _LoadSearchComboBox();
                    break;
                default:

                    break;
            }
        }

      
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
        
            string filter = cbFilter.Text;


            switch (filter)
            {
                case "First Name":
                case "Second Name":
                case "Third Name":
                case "Last Name":
                    e.Handled=!char.IsLetter(e.KeyChar)&& !char.IsControl(e.KeyChar);  
                    break;

                case "Phone":
                case "PersonID":
                case "National No.":
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;

                default:
                    break;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => _ApplyFilter();
    }
}
