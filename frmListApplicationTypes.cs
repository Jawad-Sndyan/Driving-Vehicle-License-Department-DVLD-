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
    public partial class frmListApplicationTypes : Form
    {
        private DataTable _dtAllApplicationTypes;

        private void _SetupDataGridView()
        {
            dgvApplicationTypes.AutoGenerateColumns = false;
            colID.DataPropertyName = "ApplicationTypeID";
            colTitle.DataPropertyName = "ApplicationTypeTitle";
            colFees.DataPropertyName = "ApplicationFees";
        }

        private void _RefreshApplicationTypesList()
        {
            _dtAllApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;
        }

        private int _GetSelectedApplicationTypeID()
        {
            if (dgvApplicationTypes.CurrentRow == null) return -1;
            return (int)dgvApplicationTypes.CurrentRow.Cells[0].Value;
        }
        public frmListApplicationTypes()
        {
            InitializeComponent();
            _SetupDataGridView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();
            lblRecords.Text=dgvApplicationTypes.RowCount.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationTypes frm=new frmEditApplicationTypes(_GetSelectedApplicationTypeID());
            frm.ShowDialog();
            _RefreshApplicationTypesList();
        }
    }
}
