using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public int TestID
        {
            get
            {
                return clsTest.GetTestIDForTestAppointment(TestAppointmentID);
            }
        }


        private clsApplication _RetakeTestApplication;
        public clsApplication RetakeTestApplication
        {
            get
            {
                if (RetakeTestApplicationID==-1)
                    return null;

                if (_RetakeTestApplication == null)
                    _RetakeTestApplication = clsApplication.FindBaseApplicationByID(RetakeTestApplicationID);

                return _RetakeTestApplication;
            }
        }

        private bool _AddNewTestAppointment()
        {
            TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            return TestAppointmentID != -1;
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
        }
        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;

            Mode = enMode.AddNew;
        }

        public clsTestAppointment(int testAppointmentID, clsTestTypes.enTestType testTypeID, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked,
            int retakeTestApplicationID)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = (int)testTypeID;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.IsLocked = isLocked;
            this.RetakeTestApplicationID = retakeTestApplicationID;

            Mode = enMode.Update;
        }

        public static clsTestAppointment FindTestAppointmentByID(int testAppointmentID)
        {
            int testTypeID, localDrivingLicenseApplicationID, createdByUserID , retakeTestApplicationID;
            testTypeID = localDrivingLicenseApplicationID = createdByUserID = retakeTestApplicationID =- 1; 
            DateTime appointmentDate= DateTime.MinValue;
            float paidFees = -1;
            bool isLocked = false;

            bool IsFound = clsTestAppointmentData.GetTestAppointmentByID((int)testAppointmentID, ref testTypeID, ref localDrivingLicenseApplicationID,
            ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked,
            ref retakeTestApplicationID);

            if (IsFound)
                return new clsTestAppointment((int)testAppointmentID, (clsTestTypes.enTestType)testTypeID, localDrivingLicenseApplicationID,
             appointmentDate, paidFees, createdByUserID, isLocked,
             retakeTestApplicationID);


            return null;
        }

        public static clsTestAppointment LastTestAppointment(int localDrivingLicenseApplicationID, clsTestTypes.enTestType testTypeID)
        {
            int  testAppointmentID, createdByUserID, retakeTestApplicationID;
            testAppointmentID = createdByUserID = retakeTestApplicationID = -1;
            DateTime appointmentDate = DateTime.MinValue;
            float paidFees = -1;
            bool isLocked = false;

            bool IsFound = clsTestAppointmentData.GetLastTestAppointment(localDrivingLicenseApplicationID,(int)testTypeID, ref testAppointmentID,
         ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked,
         ref retakeTestApplicationID);

            if (IsFound)
                return new clsTestAppointment(testAppointmentID, testTypeID, localDrivingLicenseApplicationID,
             appointmentDate, paidFees, createdByUserID, isLocked,
             retakeTestApplicationID);


            return null;
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }

        public static DataTable GetAllTestAppointmentsPerTestType(int localDrivingLicenseApplicationID, clsTestTypes.enTestType testTypeID)
        {
            return clsTestAppointmentData.GetAllTestAppointmentsPerTestType(localDrivingLicenseApplicationID, (int)testTypeID);
        }

        public  DataTable GetAllTestAppointmentsPerTestType(clsTestTypes.enTestType testTypeID)
        {
            return GetAllTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, testTypeID);
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateTestAppointment();
            }

            return false;
        }

    }
}