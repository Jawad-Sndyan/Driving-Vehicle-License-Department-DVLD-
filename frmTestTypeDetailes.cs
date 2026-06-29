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
    public partial class frmTestTypeDetailes : Form
    {
        private clsTestTypes _TestType;
        private clsTestTypes.enTestType _TestTypeID;

        private void _LoadData()
        {
            _TestType = clsTestTypes.FindTestTypeByID(_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show("No Test Type with ID = " + _TestTypeID.ToString(), "Test Type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblTestTypeID.Text = _TestTypeID.ToString();
            txtDescription.Text = _TestType.TestTypeDescription.Trim();
            txtTitle.Text = _TestType.TestTypeTitle.Trim();
            txtFees.Text = _TestType.TestTypeFees.ToString();
        }
        public frmTestTypeDetailes(clsTestTypes.enTestType testTypeID)
        {
            InitializeComponent();
            _TestTypeID = testTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate=AutoValidate.Disable;
            this.Close();
        }

        private void frmTestTypeDetailes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
