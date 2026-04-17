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
    public partial class ucPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int personId)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(personId);
            }
        }

        public int PersonID
        {
            get { return ucPersonCard.PersonID; }
        }
            

        private void Find()
        {
            switch(cbFilter.Text)
            {
                case "Person ID":
                    ucPersonCard.LoadPersonInfo(int.Parse(txtFilter.Text));
                    break;

                case "National No.":
                    ucPersonCard.LoadPersonInfo(txtFilter.Text);
                    break;

                default:
                    break;
            }


            if (OnPersonSelected != null)
                OnPersonSelected(ucPersonCard.PersonID);
        }

       
        public ucPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int personId)
        {
            cbFilter.SelectedIndex = cbFilter.FindString("Person ID");
            txtFilter.Text = personId.ToString();
            Find();

        }

        public void LoadPersonInfo(string NationalNo)
        {
            cbFilter.SelectedIndex = cbFilter.FindString("National No.");
            txtFilter.Text = NationalNo;
            Find();

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            txtFilter.Focus();  
        }

        private void ucPersonCard_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            txtFilter.Focus();
        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {
            if (txtFilter.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(txtFilter, "This field is required!");
                return;
            }

            if (cbFilter.Text == "Person ID")
            {
                if (!int.TryParse(txtFilter.Text.Trim(), out int id) || !clsValidator.IsValidID(id))
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtFilter, "Invalid person ID!");
                }
                else
                    errorProvider.SetError(txtFilter, null);
            }
            else if (cbFilter.Text == "National No.")
            {
                if (!clsValidator.IsValidNationalID(txtFilter.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtFilter, "Invalid national number format!");
                }
                else
                    errorProvider.SetError(txtFilter, null);
            }
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilter.SelectedIndex = 1;
            txtFilter.Text=PersonID.ToString(); 
            ucPersonCard.LoadPersonInfo(PersonID);  
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();
            frmAddUpdatePerson.DataBack += DataBackEvent;
            frmAddUpdatePerson.ShowDialog();


        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Space ASCII code is 13
            if(e.KeyChar==(char)13)
            {
                btnFind.PerformClick();
            }
            if (cbFilter.Text.Trim() == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid! \nPut the mouse over the red circle", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Find();

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void ucPersonCardWithFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
