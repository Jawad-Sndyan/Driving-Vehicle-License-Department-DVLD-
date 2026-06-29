using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD_Buisness
{
    public class clsTest
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointment {  get; set; }    
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        private bool _AddNewTest()
        {
            TestID = clsTestData.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);

            return TestID != -1;
        }

        private bool _UpdateTest()
        {
            return clsTestData.UpdateTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }
        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestAppointment = null;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }
        public clsTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            this.TestID = testID;
            this.TestAppointmentID = testAppointmentID;
            this.TestAppointment= clsTestAppointment.FindTestAppointmentByID(testAppointmentID);
            this.TestResult = testResult;
            this.Notes = notes;
            this.CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }

        public static clsTest FindTestInfoByID(int TestID)
        {
            int testAppointmentID, createdByUserID;
            testAppointmentID = createdByUserID = -1;
            bool testResult= false;
            string notes=string.Empty;

            bool IsFound = clsTestData.GetTestInfoByID(TestID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID);

            if (IsFound)
                return new clsTest(TestID, testAppointmentID, testResult, notes, createdByUserID);

            return null;
        }

        public static clsTest FindLastTestInfoForPerson(int PersonID, int LicenseClassID, int TestTypeID)
        {
            int testID,testAppointmentID, createdByUserID;
            testID=testAppointmentID = createdByUserID = -1;
            bool testResult = false;
            string notes = string.Empty;

            bool IsFound = clsTestData.GetLastTestInfoForPerson(PersonID, LicenseClassID, TestTypeID,ref testID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID);

            if (IsFound)
                return new clsTest(testID, testAppointmentID, testResult, notes, createdByUserID);

            return null;
        }

        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllTests();
        }

        public static int GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestData.GetPassedTestsCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return clsTestData.GetPassedTestsCount(LocalDrivingLicenseApplicationID) == 3;
        }

        public static int GetTestIDForTestAppointment(int TestAppointmentID)
        {
            return clsTestData.GetTestIDForTestAppointment(TestAppointmentID);
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateTest();
            }

            return false;
        }
    }
}