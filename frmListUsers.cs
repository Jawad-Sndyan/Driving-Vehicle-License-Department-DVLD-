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
    public partial class frmListUsers : Form
    {
        private DataTable _dtUsers;
        


        private void _SetupDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            colUserID.DataPropertyName = "UserID";
            colPersonID.DataPropertyName = "PersonID";
            colName.DataPropertyName = "FullName";
            colUserName.DataPropertyName = "UserName";
            checkboxIsActive.DataPropertyName = "IsActive";


        }

        private void _SetUpSearchComboBox()
        {
            if(cbFilter.Text=="Is Active")
                cbSearch.SelectedIndex = cbSearch.FindString("All");

        }

        private void _RefreshUsersList()
        {
            _dtUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtUsers;
        }

        private void _ApplyFilter()
        {
            if (_dtUsers == null) return;

            string textFilter = txtSearch.Text.Trim();
            string comboFilter = cbSearch.SelectedItem?.ToString() ?? "All";

            if (string.IsNullOrEmpty(textFilter) && (comboFilter == "All"))
            {
                _RefreshUsersList();
                lblRecords.Text = _dtUsers.Rows.Count.ToString();
                return;
            }

            DataView dv = _dtUsers.DefaultView;
            string filterExpression = "";

            if (comboFilter == "Yes")
                filterExpression = "IsActive = true";
            else if (comboFilter == "No")
                filterExpression = "IsActive = false";

            if (!string.IsNullOrEmpty(textFilter))
            {
                string textExpression = "";
                switch (cbFilter.Text)
                {
                    case "UserID":
                        if (int.TryParse(textFilter, out int userID))
                            textExpression = $"UserID = {userID}";
                        else
                            textExpression = "1 = 0";
                        break;

                    case "PersonID":
                        if (int.TryParse(textFilter, out int personID))
                            textExpression = $"PersonID = {personID}";
                        else
                            textExpression = "1 = 0";
                        break;

                    case "Full Name":
                        textExpression = $"FullName LIKE '{textFilter}%'";
                        break;

                    case "UserName":
                        textExpression = $"UserName LIKE '{textFilter}%'";
                        break;
                }

                filterExpression = string.IsNullOrEmpty(filterExpression)
                    ? textExpression
                    : $"({filterExpression}) AND ({textExpression})";
            }

            dv.RowFilter = filterExpression;
            lblRecords.Text = dv.Count.ToString();
        }

        private int _GetSelectedUserID()
        {
            if (dgvUsers.CurrentRow == null) return -1;
            return (int)dgvUsers.CurrentRow.Cells[0].Value;
        }
        public frmListUsers()
        {
            InitializeComponent();
            _SetupDataGridView();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = cbFilter.FindString("PersonID");
            txtSearch.Visible = true;
            cbSearch.Visible = false;
            _RefreshUsersList();
            lblRecords.Text = dgvUsers.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm=new frmAddEditUser();    
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            addNewPersonToolStripMenuItem_Click(sender, e);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID=_GetSelectedUserID();
            if (UserID == -1) return;

            frmUserInfo frm=new frmUserInfo(UserID);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = _GetSelectedUserID();
            if (UserID == -1) return;

            frmAddEditUser frm = new frmAddEditUser(UserID);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = _GetSelectedUserID();
            if (UserID == -1) return;

            if (MessageBox.Show("Are you sure you want to delete this User?", "Confirm Delete",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if(clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User deleted successfully.", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("Failed to delete. User may be linked to other records.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            string filter = cbFilter.Text;
            switch (filter)
            {
                case "Full Name":
                case "UserName":
                    e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;
                case "UserID":
                case "PersonID":
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
            _RefreshUsersList();
            txtSearch.Text = "";
            string filter = cbFilter.Text;
            switch (filter)
            {
                case "None":
                    txtSearch.Visible = false;
                    cbSearch.Visible = false;
                    break;
                case "UserID":
                case "PersonID":
                case "Full Name":
                case "UserName":
                    txtSearch.Visible = true;
                    cbSearch.Visible = false;
                    break;
                case "Is Active":
                    txtSearch.Visible = false;
                    cbSearch.Visible = true;
                    _SetUpSearchComboBox();
                    break;
                default:
                    break;
            }
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int UserID = _GetSelectedUserID();
            if (UserID == -1) return;

            FrmChangePassword frm=new FrmChangePassword(UserID);  
            frm.ShowDialog();
        }
    }
}
