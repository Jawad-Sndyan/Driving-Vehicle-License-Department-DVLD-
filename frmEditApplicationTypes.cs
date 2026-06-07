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
    public partial class frmEditApplicationTypes : Form
    {
        private clsApplicationTypes _ApplicationType;
        private int _ApplicationTypeID = -1;

        private void _LoadData()
        {
            _ApplicationType = clsApplicationTypes.FindApplicationTypeByID(_ApplicationTypeID);
            if (_ApplicationType == null )
            {
                MessageBox.Show("No Application Type with ID = " + _ApplicationTypeID.ToString(), "Application Type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            txtFees.Text= _ApplicationType.ApplicationFees.ToString();
            txtTitle.Text = _ApplicationType.ApplicationTypeTitle;

        }
        public frmEditApplicationTypes(int applicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = applicationTypeID;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
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

        private void X(object sender, EventArgs e)
        {

        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateEmptyTextBox(sender, e))
                return;
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (!_ValidateEmptyTextBox(sender, e))
                return;

            if (!clsValidator.IsNumber(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtFees, "Fees must be digits only.");
            }
            else
                errorProvider.SetError(txtFees, null);


            if(Convert.ToSingle(txtFees.Text.Trim())==_ApplicationType.ApplicationFees)
            {
                e.Cancel=true;
                errorProvider.SetError(txtFees, $"New Fees must be Diferent from the Old Fees.\nOld Fees = {_ApplicationType.ApplicationFees}");
            }
            else
                errorProvider.SetError(txtFees, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid! \nPut the mouse over the red circle", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.ApplicationTypeTitle=txtTitle.Text.Trim();
            _ApplicationType.ApplicationFees = Convert.ToSingle(txtFees.Text.Trim());

            if(_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Error: Data Is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
