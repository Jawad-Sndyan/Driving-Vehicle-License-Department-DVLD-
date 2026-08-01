using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;
        public int DriverID { get; set; }
        public int PersonID { get; set; }

        private clsPerson _Person;
        public clsPerson Person
        {
            get
            {
                if (PersonID == -1)
                    return null;

                if (_Person == null)
                    _Person = clsPerson.Find(PersonID);

                return _Person;
            }
        }


        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }


        private bool _AddNewDriver()
        {
            DriverID=clsDriverData.AddNewDriver(PersonID, CreatedByUserID);

            return DriverID!=-1;    
        }

        private  bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(DriverID, PersonID, CreatedByUserID);
        }

        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        public clsDriver(int driverID, int personID, int createdByUserID,DateTime createdDate)
        {
            Mode = enMode.Update;
            DriverID=driverID;
            PersonID=personID;
            CreatedByUserID=createdByUserID;
            CreatedDate = createdDate;
        }

        public static clsDriver FindDriverInfoByID(int DriverID)
        {
            int personID, createdByUserID;
            personID = createdByUserID = -1;
            DateTime createdDate= DateTime.MinValue;

            bool IsFound = clsDriverData.GetDriverInfoByID(DriverID, ref personID, ref createdByUserID, ref createdDate);

            if (IsFound)
                return new clsDriver(DriverID, personID, createdByUserID, createdDate);


            return null;
        }

        public static clsDriver FindDriverInfoByPersonID(int PersonID)
        {
            int driverID, createdByUserID;
            driverID = createdByUserID = -1;
            DateTime createdDate = DateTime.MinValue;

            bool IsFound = clsDriverData.GetDriverInfoByPersonID(PersonID, ref driverID, ref createdByUserID,ref createdDate);

            if (IsFound)
                return new clsDriver(driverID, PersonID, createdByUserID, createdDate);


            return null;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }

        public DataTable GetLicenses()
        {
            return clsLicense.GetDriverLicense(DriverID);
        }

        public DataTable GetDriverInternationalLicenses()
        {
            return clsInternationalLicense.GetDriverInternationalLicenses(DriverID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDriver();
            }

            return false;
        }

    }
}
