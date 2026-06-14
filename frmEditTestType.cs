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
    public partial class frmEditTestType : Form
    {
        private clsTestTypes _TestType;
        private int _TestTypeID = -1;

        private void _LoadData()
        {
            _TestType=clsTestTypes.FindTestTypeByID(_TestTypeID);

            if(_TestType == null )
            {
                MessageBox.Show("No Test Type with ID = " + _TestTypeID.ToString(), "Test Type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblTestTypeID.Text = _TestTypeID.ToString();    
            txtDescription.Text= _TestType.TestTypeDescription.Trim();  
            txtTitle.Text = _TestType.TestTypeTitle.Trim(); 
            txtFees.Text= _TestType.TestTypeFees.ToString();
        }
        public frmEditTestType(int testTypeID)
        {
            InitializeComponent();
            _TestTypeID= testTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            TextBox Temp = ((TextBox)sender);

            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(Temp, "This field is required!");
                return false;
            }
            else
            {
                errorProvider.SetError(Temp, null);

            }
            return true;


        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if(!_ValidateEmptyTextBox(sender,e))
                { return; }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateEmptyTextBox(sender, e))
            { return; }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateEmptyTextBox(sender, e))
            { return; }

            if (!clsValidator.IsNumber(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtFees, "Fees must be digits only.");
            }
            else
                errorProvider.SetError(txtFees, null);


            if (Convert.ToSingle(txtFees.Text.Trim()) == _TestType.TestTypeFees)
            {
                e.Cancel = true;
                errorProvider.SetError(txtFees, $"New Fees must be Diferent from the Old Fees.\nOld Fees = {_TestType.TestTypeFees}");
            }
            else
                errorProvider.SetError(txtFees, null);
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')';
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid! \nPut the mouse over the red circle", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.TestTypeTitle = txtTitle.Text.Trim();
            _TestType.TestTypeDescription =txtDescription.Text.Trim();
            _TestType.TestTypeFees = Convert.ToSingle(txtFees.Text.Trim());

            if (_TestType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
