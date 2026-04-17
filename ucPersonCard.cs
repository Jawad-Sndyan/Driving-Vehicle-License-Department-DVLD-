using DVLD.Properties;
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
using System.IO;
using System.Runtime.InteropServices;

namespace DVLD
{
    public partial class ucPersonCard : UserControl
    {
        private enum enGendor { Male = 0, Female = 1 };
        private clsPerson _Person;
        public int PersonID
        {
            get { return (_Person != null) ? _Person.PersonID : -1; }
        }

        public clsPerson PersonInfo
        {
            get { return _Person; } 
        }

        private void _FillPersonInfo()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            lblName.Text = _Person.FullName;
            lblNationalNumber.Text = _Person.NationalNo;
            lblGendor.Text = _Person.Gendor == false ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblAddress.Text = _Person.Address;
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblDOB.Text = _Person.DateOfBirth.ToShortDateString();

            picGendor.BackgroundImage = _Person.Gendor == false ? Resources.Man_32 : Resources.Woman_32;

            _LoadPersonImage();
        }
        private void _LoadPersonImage()
        {
            if (_Person.Gendor == Convert.ToBoolean(enGendor.Male))
                picImage.Image = Resources.Male_512;
            else
                picImage.Image = Resources.Female_512;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (clsValidator.IsValidImagePath(ImagePath) && File.Exists(ImagePath))
                    picImage.ImageLocation = ImagePath; 
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public ucPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person found with ID: " + PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                MessageBox.Show("No Person found with National Number: " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void ResetPersonInfo()
        {
            lblPersonID.Text = "????";
            lblName.Text = "????";
            lblNationalNumber.Text = "????";
            lblGendor.Text = "????";
            lblEmail.Text = "????";
            lblPhone.Text = "????";
            lblAddress.Text = "????";
            lblCountry.Text = "????";
            lblDOB.Text = "????";

            picGendor.BackgroundImage = Resources.Man_32;
        }

        private void linkLabelEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           frmAddUpdatePerson frm=new frmAddUpdatePerson(PersonID);

            frm.ShowDialog();

            LoadPersonInfo(PersonID);   
        }
    }
}
