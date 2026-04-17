using DVLD.Properties;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        private enum enMode { AddNew = 0, Update = 1 };
        private enum enGendor { Male = 0, Female = 1 };

        private enMode _Mode;
        private int _PersonID = -1;
        clsPerson _Person = null;

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }
        private void _RestoreDefaultValues()
        {
            _FillCountriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                rbMale.Checked = true;
            }
            else
            {
                lblMode.Text = "Update Person";
                _Person = clsPerson.Find(_PersonID);
                if (_Person != null)
                    rbMale.Checked = (clsPerson.Find(_PersonID).Gendor == Convert.ToBoolean(enGendor.Male)) ? true : false;
                else
                    rbMale.Checked = true;
            }


            if (rbMale.Checked)
                picImage.Image = Resources.Male_512;
            else
                picImage.Image = Resources.Female_512;

            linkLabelRemoveImage.Visible = (picImage.ImageLocation != null);

            dtpDOB.MaxDate = DateTime.Now.AddYears(-18);
            dtpDOB.MinDate = DateTime.Now.AddYears(-100);

            dtpDOB.Value = dtpDOB.MaxDate;

            cbCountries.SelectedIndex = cbCountries.FindString("Syria");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";



        }

        private void _LoadData()
        {
            if (_Person == null)
            {
                MessageBox.Show("No Person with ID " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDOB.Value = _Person.DateOfBirth;
            if (_Person.Gendor == Convert.ToBoolean(enGendor.Male))
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);

            if (_Person.ImagePath != "")
                picImage.ImageLocation = _Person.ImagePath;

            linkLabelRemoveImage.Visible = (_Person.ImagePath != "");

        }

        private bool _HandlePersonImage()
        {
            if (picImage.ImageLocation == _Person.ImagePath)
                return true;

            if (picImage.ImageLocation == null)
            {
                clsUtil.DeleteImageFromImagesFolder(_Person.ImagePath);
                return true;
            }

            string SourceImageFile = picImage.ImageLocation.ToString();

            if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
            {
                clsUtil.DeleteImageFromImagesFolder(_Person.ImagePath);
                picImage.ImageLocation = SourceImageFile;
                return true;
            }
            else
            {
                MessageBox.Show("Error copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;

        }






        private void linkLabelSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                picImage.ImageLocation = selectedFilePath;
                linkLabelRemoveImage.Visible = true;
            }
        }




        private void linkLabelRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picImage.ImageLocation = null;



            if (rbMale.Checked)
                picImage.Image = Resources.Male_512;
            else
                picImage.Image = Resources.Female_512;

            linkLabelRemoveImage.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid! \nPut the mouse over the red circle", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!_HandlePersonImage())
                return;

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDOB.Value;
            if (rbMale.Checked)
                _Person.Gendor = Convert.ToBoolean(enGendor.Male);
            else
                _Person.Gendor = Convert.ToBoolean(enGendor.Female);

            if (picImage.ImageLocation != null)
                _Person.ImagePath = picImage.ImageLocation;
            else
                _Person.ImagePath = "";

                _Person.NationalityCountryID = clsCountry.Find(cbCountries.Text).ID; ;

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                _Mode = enMode.Update;
                lblMode.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _RestoreDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }



        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (picImage.ImageLocation == null)
                picImage.Image = Resources.Male_512;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (picImage.ImageLocation == null)
                picImage.Image = Resources.Female_512;
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim().Length == 0)
            { return; }

            if (!clsValidator.IsValidEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, "Invalid Email address format!");
            }
            else
                errorProvider.SetError(txtEmail, null);
        }



        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void _ValidatingName(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            int startIndex = 3;
            int NameIndexlength = txt.Name.Length - startIndex - 4;
            int Namelength = txt.Name.Length - startIndex-1;
            string  NameIndex= txt.Name.Substring(startIndex, NameIndexlength).ToLower();   
            string Name= txt.Name.Substring(Namelength).ToLower();
            if (!clsValidator.IsValidName(txt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txt, $"Please enter a valid {NameIndex} {Name} between 2 and 50 characters!");
            }
        }
        private void _HandleKeyPressForNames(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyTextBox(sender, e);
            _ValidatingName(sender, e);
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            _HandleKeyPressForNames(sender, e);
        }

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyTextBox(sender, e);
            _ValidatingName(sender, e);
        }

        private void txtSecondName_KeyPress(object sender, KeyPressEventArgs e)
        {
            _HandleKeyPressForNames(sender, e);
        }

        private void txtThirdName_KeyPress(object sender, KeyPressEventArgs e)
        {
             _HandleKeyPressForNames(sender, e);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyTextBox(sender, e);
            _ValidatingName(sender, e);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            _HandleKeyPressForNames(sender, e);
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (_ValidateEmptyTextBox(sender, e))
                return;

            if (!clsValidator.IsValidNationalID(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNationalNo, "Invalid national number format!");
                return;

            }
            else
                errorProvider.SetError(txtNationalNo, null);

            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNationalNo, "National Number is user for another person");
                return;
            }
            else
                errorProvider.SetError(txtNationalNo, null);
        }


        private void txtNationalNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyTextBox(sender, e);
            if(!clsValidator.IsValidPhone(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPhone, "Invalid phone number number format!");
            }
            else
                errorProvider.SetError(txtPhone, null);

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyTextBox(sender,e);
            if(!clsValidator.IsValidAddress(txtAddress.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPhone, "Please enter a valid Address between 5 and 255 characters!");
            }
            else
                errorProvider.SetError(txtPhone, null);

        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
