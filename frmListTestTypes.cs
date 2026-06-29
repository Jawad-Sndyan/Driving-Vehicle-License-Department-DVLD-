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
    public partial class frmListTestTypes : Form
    {
        private DataTable _dtAllTestTypes;

        private void _SetupDataGridView()
        {
            dgvTestTypes.AutoGenerateColumns = false;
            colID.DataPropertyName = "TestTypeID";
            colTitle.DataPropertyName = "TestTypeTitle";
            colDescription.DataPropertyName = "TestTypeDescription";
            colFees.DataPropertyName = "TestTypeFees";
        }

        private void _RefreshApplicationTypesList()
        {
            _dtAllTestTypes = clsTestTypes.GetAllTestTypes();
            dgvTestTypes.DataSource = _dtAllTestTypes;
            lblRecords.Text= _dtAllTestTypes.Rows.Count.ToString(); 
        }

        private int _GetSelectedApplicationTypeID()
        {
            if (dgvTestTypes.CurrentRow == null) return -1;
            return (int)dgvTestTypes.CurrentRow.Cells[0].Value;
        }
        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        private void frmTestTypes_Load(object sender, EventArgs e)
        {
            _SetupDataGridView();
            _RefreshApplicationTypesList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((clsTestTypes.enTestType)_GetSelectedApplicationTypeID());
            frm.ShowDialog();
            _RefreshApplicationTypesList();
        }

        private void TestTypeDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypeDetailes frm =new frmTestTypeDetailes((clsTestTypes.enTestType)_GetSelectedApplicationTypeID());
            frm.ShowDialog();
        }
    }
}
