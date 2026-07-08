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
    public partial class ucDriverLicenseInfo : UserControl
    {

        private enum enGendor { Male = 0, Female = 1 };
        private clsLicense _License;
        private int _LicenseID = -1;

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense SelecetedLicense
        {
            get { return _License; }    
        }

        private void _ResetDefaultValues()
        {
            lblClassName.Text = "????";
            lblName.Text = "????";
            lblLicenceID.Text = "-1";
            lblNationalNo.Text = "-1";
            lblGendor.Text = "Male";
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblReason.Text = "????";
            lblNotes.Text = "????";
            lblIsActive.Text = "????";
            lblDOB.Text= DateTime.Now.ToString("dd/mm/yyyy");
            lblDriverID.Text = "-1";
            lblExpirationDate.Text = DateTime.Now.ToShortDateString();
            lblIsDetained.Text = "????";
            picGendor.BackgroundImage= Resources.Man_32;
        }
        private void _LoadLicenseInfo()
        {
            lblClassName.Text=_License.LicenseClass.ClassName.Trim();
            lblName.Text= _License.Driver.Person.FirstName.Trim();
            lblLicenceID.Text= _License.LicenseID.ToString().Trim();
            lblNationalNo.Text= _License.Driver.Person.NationalNo.Trim();
            lblGendor.Text = (_License.Driver.Person.Gendor == Convert.ToBoolean(enGendor.Male)) ? "Male" : "Female";
            picGendor.BackgroundImage = (_License.Driver.Person.Gendor == Convert.ToBoolean(enGendor.Male)) ? Resources.Man_32 : Resources.Woman_32;
            lblIssueDate.Text= _License.IssueDate.ToString().Trim();
            lblReason.Text= _License.IssueReasonText.Trim();
            lblNotes.Text= _License.Notes.Trim();
            lblIsActive.Text = (_License.IsActive == true) ? "Yes" : "No";
            lblDOB.Text= _License.Driver.Person.DateOfBirth.ToShortDateString().Trim();
            lblDriverID.Text= _License.Driver.DriverID.ToString().Trim();
            lblExpirationDate.Text= _License.ExpirationDate.ToShortDateString().Trim();
            //For Now
            bool De = true;
            lblIsDetained.Text = (De == true) ? "Yes" : "No";

            _LoadPersonImage();
        }
        private void _LoadPersonImage()
        {
            if (_License.Driver.Person.Gendor == Convert.ToBoolean(enGendor.Male))
                picImage.Image = Resources.Male_512;
            else
                picImage.Image = Resources.Female_512;

            string ImagePath = _License.Driver.Person.ImagePath;
            if (ImagePath != "")
                if (clsValidator.IsValidImagePath(ImagePath) && File.Exists(ImagePath))
                    picImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public ucDriverLicenseInfo()
        {
            InitializeComponent();

        }

        public void LoadLicenseInfo(int licenseID)
        {
            _LicenseID = licenseID;
            _License = clsLicense.Find(_LicenseID);

            if (_License == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("No License found with ID: " + _LicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadLicenseInfo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ucDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            
        }
    }
}
