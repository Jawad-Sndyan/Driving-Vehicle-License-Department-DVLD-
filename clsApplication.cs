using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Buisness.clsApplication;

namespace DVLD_Buisness
{
    public class clsApplication
    {
        protected enum enMode {AddNew=0,Update=1}
        protected enMode _Mode=enMode.AddNew; 
        public enum enApplicationTypes { New_LocalDriving_License_Service=1, Renew_Driving_License_Service=2,
        Replacement_for_a_Lost_Driving_License=3, Replacement_for_a_Damaged_Driving_License=4,
            Release_Detained_Driving_License=5, New_International_License=6, Retake_Test=7
        }
        public enum enApplicationStatus {New=1, Cancelled=2, Completed=3 }

        public int ApplicationID {  get; set; }
        public int PersonID { get; set; }  

        public clsPerson Person {  get; set; }

        public DateTime ApplicationDate {  get; set; }  
        public enApplicationTypes ApplicationTypeID { get; set; }
        public clsApplicationTypes ApplicationType { get; set; }

        public enApplicationStatus Status { get; set; }

        public string StatusText
        {
            get
            {
                switch(Status)
                {
                    case enApplicationStatus.New:
                        return "New";
                        break;
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                        break ;
                    case enApplicationStatus.Completed:
                        return "Completed";
                        break;
                    default:
                        return "Unknoun";
                        break;
                }
            }
        }

        public DateTime LastStatusDate {  get; set; }   

        public float PaidFees { get; set; } 
        public int UserID {  get; set; }
        public clsUser User { get; set; }

        private bool _AddNewApplication()
        {

            int ApplicationID = clsApplicationData.AddNewApplication(PersonID, (int)ApplicationTypeID, PaidFees, UserID);

            return ApplicationID != -1;
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(ApplicationID,PersonID,ApplicationDate,(int)ApplicationTypeID,(int)Status,LastStatusDate,PaidFees,UserID);
        }

        public clsApplication()
        {
            _Mode=enMode.AddNew;
            ApplicationID = 1;
            PersonID = -1;
            Person = null;
            ApplicationDate=DateTime.MinValue;
            ApplicationTypeID = enApplicationTypes.New_LocalDriving_License_Service;
            ApplicationType = null;
            Status = enApplicationStatus.New;
            LastStatusDate= DateTime.MinValue;
            PaidFees = -1;
            UserID = -1;
            User = null;
        }

        public clsApplication(int applicationID, int applicantPersonID,
        DateTime applicationDate, enApplicationTypes applicationTypeID, enApplicationStatus applicationStatus,
        DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            _Mode = enMode.Update;
            ApplicationID = applicationID;
            PersonID=applicantPersonID;
            Person = clsPerson.Find(applicantPersonID);
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationType = clsApplicationTypes.FindApplicationTypeByID((int)applicationTypeID);
            Status = applicationStatus;
            LastStatusDate =  lastStatusDate;
            PaidFees = paidFees;
            UserID = createdByUserID;
            User = clsUser.FindByUserID(createdByUserID);
        }

        public static clsApplication FindBaseApplicationByID(int applicationID)
        {
            int applicantPersonID = -1, createdByUserID = -1;
            DateTime applicationDate= DateTime.MinValue, lastStatusDate = DateTime.MinValue;
            int applicationTypeID = -1;
            int applicationStatus = -1;
            float paidFees = -1;
            bool isFound = clsApplicationData.GetApplicationByID(applicationID, ref applicantPersonID, ref applicationDate, ref applicationTypeID
                , ref applicationStatus, ref lastStatusDate, ref paidFees,ref createdByUserID);

            if (isFound)
                return new clsApplication(applicationID, applicantPersonID, applicationDate, (enApplicationTypes)applicationTypeID
                , (enApplicationStatus)applicationStatus, lastStatusDate, paidFees, createdByUserID);


            return null;
        }

        public static bool IsApplicationExist(int applicationID)
        {
            return clsApplicationData.IsApplicationExist(applicationID);
        }

        public static int GetActiveApplicationID(int applicantPersonID, int applicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(applicantPersonID, applicationTypeID);
        }

        public static bool DoesPersonHaveActiveApplication(int applicantPersonID, int applicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(applicantPersonID , applicationTypeID);
        }

        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(ApplicationID,(int)enApplicationStatus.Cancelled);
        }

        public bool Complete()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, (int)enApplicationStatus.Completed);
        }

        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(ApplicationID);
        }
       public bool Save()
        {
            switch(_Mode)
            {
                case enMode.Update:
                    return _UpdateApplication();

                case enMode.AddNew:
                    if(_AddNewApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }


                    return false;
            }

            return false;

        }





    }
}
