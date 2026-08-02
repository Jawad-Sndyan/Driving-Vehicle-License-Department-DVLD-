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

namespace DVLD
{
    public partial class ucDriverInternationalLicenseInfo : UserControl
    {

        private enum enGendor { Male = 0, Female = 1 };
        private clsInternationalLicense _InternationalLicense;
        private int _InternationalLicenseID = -1;

        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }

        public clsInternationalLicense SelectedInternationalLicense
        {
            get { return _InternationalLicense; }
        }

        private void _ResetDefaultValues()
        {
            lblIntLicenseID.Text = "-1";
            lblAppID.Text = "-1";
            lblName.Text = "????";
            lblLicenceID.Text = "-1";
            lblNationalNo.Text = "-1";
            lblGendor.Text = "Male";
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblIsActive.Text = "????";
            lblDOB.Text = DateTime.Now.ToString("dd/mm/yyyy");
            lblDriverID.Text = "-1";
            lblExpirationDate.Text = DateTime.Now.ToShortDateString();
            picGendor.BackgroundImage = Resources.Man_32;
        }

        private void _LoadInternationalLicenseInfo()
        {
            lblIntLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString().Trim();
            lblAppID.Text = _InternationalLicense.ApplicationID.ToString().Trim();

            lblName.Text = _InternationalLicense.Driver.Person.FirstName.Trim();
            lblLicenceID.Text = _InternationalLicense.ToString().Trim();
            lblNationalNo.Text = _InternationalLicense.Driver.Person.NationalNo.Trim();
            lblGendor.Text = (_InternationalLicense.Driver.Person.Gendor == Convert.ToBoolean(enGendor.Male)) ? "Male" : "Female";
            picGendor.BackgroundImage = (_InternationalLicense.Driver.Person.Gendor == Convert.ToBoolean(enGendor.Male)) ? Resources.Man_32 : Resources.Woman_32;

            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString().Trim();
            lblIsActive.Text = (_InternationalLicense.IsActive == true) ? "Yes" : "No";
            lblDOB.Text = _InternationalLicense.Driver.Person.DateOfBirth.ToShortDateString().Trim();
            lblDriverID.Text = _InternationalLicense.Driver.DriverID.ToString().Trim();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString().Trim();

            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            if (_InternationalLicense.Driver.Person.Gendor == Convert.ToBoolean(enGendor.Male))
                picImage.Image = Resources.Male_512;
            else
                picImage.Image = Resources.Female_512;

            string ImagePath = _InternationalLicense.Driver.Person.ImagePath;
            if (ImagePath != "")
                if (clsValidator.IsValidImagePath(ImagePath) && File.Exists(ImagePath))
                    picImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public ucDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInternationalLicenseInfo(int internationalLicenseID)
        {
            _InternationalLicenseID = internationalLicenseID;
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);

            if (_InternationalLicense == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("No International License found with ID: " + _InternationalLicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadInternationalLicenseInfo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ucDriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}