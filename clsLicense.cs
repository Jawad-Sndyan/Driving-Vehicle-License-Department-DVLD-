using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Buisness.clsLicense;

namespace DVLD_Buisness
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;

        public enum enIssueReason {FirstTime=1, Renew=2, ReplacementDamaged=3, ReplacementLost=4};

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        private clsDriver _Driver;
        public clsDriver Driver
        {
            get
            {
                if (DriverID == -1)
                    return null;

                if(_Driver == null)
                    _Driver=clsDriver.FindDriverInfoByID(DriverID);


                return _Driver;
            }
        }
        public int LicenseClassID { get; set; }
        private clsLicenseClass _LicenseClass;
        public clsLicenseClass LicenseClass
        {
            get
            {
                if (LicenseClassID == -1)
                    return null;

                if (_LicenseClass == null)
                    _LicenseClass = clsLicenseClass.FindByID(LicenseClassID);


                return _LicenseClass;
            }
        }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(IssueReason);
            }
        }
        public int CreatedByUserID { get; set; }
        private clsUser _User = null;
        public clsUser CreatedByUser
        {
            get
            {
                if (CreatedByUserID == -1)
                    return null;

                if (_User == null)
                    _User = clsUser.FindByUserID(CreatedByUserID);

                return _User;
            }
        }

        public clsDetainedLicense DetainedInfo
        {  
            get
            {
                return clsDetainedLicense.FindByLicenseID(LicenseID);
            }
        }

        public bool IsDetained
        {
            get
            {
                return clsDetainedLicense.IsLicenseDetained(LicenseID);
            }
        }
        private bool _AddNewLicense()
        {
            LicenseID = clsLicenseData.AddNewLicense(ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes,
                PaidFees, IsActive, (int)IssueReason, CreatedByUserID);

            return LicenseID != -1;
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes,
                PaidFees, IsActive, (int)IssueReason, CreatedByUserID);
        }
        public clsLicense()
        {
            Mode = enMode.AddNew;
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate=DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes=string.Empty;
            PaidFees = -1;
            IsActive = false;
            IssueReason = enIssueReason.FirstTime;   
            CreatedByUserID = -1;
        }
        public clsLicense(int licenseID,  int applicationID,  int driverID,
             int licenseClass,  DateTime issueDate,  DateTime expirationDate,  string notes,
             float paidFees,  bool isActive,  enIssueReason issueReason,  int createdByUserID)
        {
            Mode = enMode.Update;
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClassID= licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive= isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
        }

       
        public static clsLicense Find(int LicenseID)
        {
            int applicationID, driverID, licenseClass, createdByUserID, issueReason;
            applicationID = driverID = licenseClass = createdByUserID = issueReason = -1;
            DateTime issueDate, expirationDate;
            issueDate= expirationDate=DateTime.MinValue;
            string notes = string.Empty;
            float paidFees = -1;
            bool isActive=false;

            bool IsFound = clsLicenseData.GetLicensInfoByID(LicenseID, ref applicationID, ref driverID, ref licenseClass,
                ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID);

            if(IsFound)
                return new clsLicense(LicenseID, applicationID,  driverID,  licenseClass,
                 issueDate,  expirationDate,  notes,  paidFees,  isActive, (enIssueReason) issueReason,  createdByUserID);

            return null;
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClass)
        {
            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClass);
        }
        public static bool IsLicenseExsistByPersonID(int PersonID, int LicenseClass)
        {
            return GetActiveLicenseIDByPersonID(PersonID, LicenseClass) != -1;
        }
        public  bool IsLicenseExsist(int LicenseClass)
        {
            int PersonID=clsApplication.FindBaseApplicationByID(ApplicationID).ApplicationID;
            return IsLicenseExsistByPersonID(PersonID, LicenseClass);
        }
        public static DataTable GetDriverLicense(int DriverID)
        {
            return clsLicenseData.GetDriverLicense(DriverID);
        }

        public bool IsLicenseExpiered()
        {
            return ExpirationDate < DateTime.Now;
        }

        public bool DeactivateLicense()
        {
            return clsLicenseData.DeactivateLicense(LicenseID);
        }

        public static string GetIssueReasonText(enIssueReason issueReason)
        {
            switch(issueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.ReplacementDamaged:
                    return "Replacement for Damaged";
                case enIssueReason.ReplacementLost:
                    return "Replacement for Lost";
                default:
                    return "First Time";


            }
        }

        public int Detain(float FineFees,int CreatedByUserID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = FineFees;
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
                return -1;

            return detainedLicense.DetainID;

        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID,ref int ApplicationID)
        {
            clsApplication App=new clsApplication();
            App.PersonID=Driver.PersonID;
            App.ApplicationDate = DateTime.Now;
            App.ApplicationType= clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Release_Detained_Driving_License);
            App.Status = clsApplication.enApplicationStatus.Completed;
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Release_Detained_Driving_License).ApplicationFees;
            App.UserID = ReleasedByUserID;
            App.User = clsUser.FindByUserID(ReleasedByUserID);

            if(!App.Save())
            {
                ApplicationID = -1;
                return false;
            }
            ApplicationID=App.ApplicationID;

            return DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, App.ApplicationID);

        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            clsApplication App = new clsApplication();
            App.PersonID = Driver.PersonID;
            App.Person = clsPerson.Find(Driver.PersonID);
            App.ApplicationDate = DateTime.Now;
            App.ApplicationTypeID = clsApplication.enApplicationTypes.Renew_Driving_License_Service;
            App.ApplicationType = clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Renew_Driving_License_Service);
            App.Status = clsApplication.enApplicationStatus.New;
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Renew_Driving_License_Service).ApplicationFees;
            App.UserID = CreatedByUserID;
            App.User = clsUser.FindByUserID(CreatedByUserID);

            if (!App.Save())
                return null;

            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID =App.ApplicationID;
            NewLicense.DriverID = DriverID;
            NewLicense.LicenseClassID = LicenseClassID;
            NewLicense.IssueDate=DateTime.Now;

            int ValidityLength = clsLicenseClass.FindByID(LicenseClassID).DefaultValidityLength;
            NewLicense.ExpirationDate= DateTime.Now.AddYears(ValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees=clsLicenseClass.FindByID(LicenseClassID).ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if(NewLicense.Save())
            {
                this.DeactivateLicense();
                return NewLicense;
            }

            return null;
        }

        public clsLicense Replace(enIssueReason issueReason, int CreatedByUserID)
        {
            clsApplication App = new clsApplication();
            App.PersonID = Driver.PersonID;
            App.Person = clsPerson.Find(Driver.PersonID);
            App.ApplicationDate = DateTime.Now;
            App.ApplicationTypeID = (issueReason == enIssueReason.ReplacementLost) ? clsApplication.enApplicationTypes.Replacement_for_a_Lost_Driving_License : clsApplication.enApplicationTypes.Replacement_for_a_Damaged_Driving_License;

            App.ApplicationType = (issueReason == enIssueReason.ReplacementLost) ? clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Replacement_for_a_Lost_Driving_License)
                : clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Replacement_for_a_Damaged_Driving_License)
                ;
            App.Status = clsApplication.enApplicationStatus.Completed;
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = (issueReason == enIssueReason.ReplacementLost)?clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Replacement_for_a_Lost_Driving_License).ApplicationFees
                : clsApplicationTypes.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.Replacement_for_a_Damaged_Driving_License).ApplicationFees
                ;
            App.UserID = CreatedByUserID;
            App.User = clsUser.FindByUserID(CreatedByUserID);

            if (!App.Save())
                return null;


            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = App.ApplicationID;
            NewLicense.DriverID = DriverID;
            NewLicense.LicenseClassID = LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;

            int ValidityLength = clsLicenseClass.FindByID(LicenseClassID).DefaultValidityLength;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(ValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = clsLicenseClass.FindByID(LicenseClassID).ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (NewLicense.Save())
            {
                this.DeactivateLicense();
                return NewLicense;
            }

            return null;
        }



        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLicense())
                    {
                        Mode = enMode.Update; 
                        return true;
                    }

                    return false;

                case enMode.Update:
                    return _UpdateLicense();
            }

            return false;
        }
    }
}