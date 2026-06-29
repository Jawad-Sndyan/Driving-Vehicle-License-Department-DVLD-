using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLicenseClass LicenseClass { get; set; }


        private bool _AddNewLocalDrivingLicenseApplication()
        {
             LocalDrivingLicenseApplicationID =
                clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(
                    ApplicationID, LicenseClassID);

            return LocalDrivingLicenseApplicationID != -1;
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
        }

        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
            LicenseClass = null;
            _Mode = enMode.AddNew;
        }

        public clsLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID, int licenseClassID,
    int applicationID, int applicantPersonID,
    DateTime applicationDate, enApplicationTypes applicationTypeID, enApplicationStatus applicationStatus,
    DateTime lastStatusDate, float paidFees, int createdByUserID)
    : base(applicationID, applicantPersonID, applicationDate, applicationTypeID, applicationStatus,
           lastStatusDate, paidFees, createdByUserID)
        {
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            LicenseClassID = licenseClassID;
            LicenseClass = clsLicenseClass.FindByID(licenseClassID);

            _Mode = enMode.Update;
        }

        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationInfoByID
            (int localDrivingLicenseApplicationID)
        {
            int licenseClassID, applicationID;
            licenseClassID = applicationID = -1;
            bool isFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(localDrivingLicenseApplicationID, ref applicationID, ref licenseClassID);

            if (isFound)
            {
                clsApplication App = clsApplication.FindBaseApplicationByID(applicationID);
                if (App != null)
                {
                    return new clsLocalDrivingLicenseApplication(localDrivingLicenseApplicationID, licenseClassID, App.ApplicationID, App.PersonID, App.ApplicationDate, App.ApplicationTypeID, App.Status, App.LastStatusDate, App.PaidFees, App.UserID);
                }
            }

            return null;


        }


        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationInfoByApplicationID
           (int applicationID)
        {
            int licenseClassID, localDrivingLicenseApplicationID;
            licenseClassID = localDrivingLicenseApplicationID = -1;
            bool isFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(applicationID ,ref localDrivingLicenseApplicationID, ref licenseClassID);

            if (isFound)
            {
                clsApplication App = clsApplication.FindBaseApplicationByID(applicationID);
                if (App != null)
                {
                    return new clsLocalDrivingLicenseApplication(localDrivingLicenseApplicationID, licenseClassID, App.ApplicationID, App.PersonID, App.ApplicationDate, App.ApplicationTypeID, App.Status, App.LastStatusDate, App.PaidFees, App.UserID);
                }
            }

            return null;


        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public bool Delete()
        {
            return clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }

        public static bool DoesPassTest(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool DoesPassTest(clsTestTypes.enTestType TestTypeID)
        {
            return DoesPassTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool AttendedTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool AttendedTest(clsTestTypes.enTestType TestTypeID)
        {
            return AttendedTest(LocalDrivingLicenseApplicationID,TestTypeID);
        }

        public static int TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public  int TotalTrialsPerTest(clsTestTypes.enTestType TestTypeID)
        {
            return TotalTrialsPerTest(LocalDrivingLicenseApplicationID,TestTypeID);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public  bool IsThereAnActiveScheduledTest(clsTestTypes.enTestType TestTypeID)
        {
            return IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public int GetPassedTestsCount()
        {
            return clsTest.GetPassedTestsCount(LocalDrivingLicenseApplicationID);
        }

        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(LocalDrivingLicenseApplicationID);
        }

        public clsTest FindLastTestInfoPerTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsTest.FindLastTestInfoForPerson(PersonID, LicenseClassID, (int)TestTypeID);
        }

        public bool Save()
        {
            base._Mode = (clsApplication.enMode)_Mode;

            if(!base.Save()) 
                return false;


            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLocalDrivingLicenseApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }

                    return false;
                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();

                default:
                    return false;
            }
            return false;
        }
    }
}
