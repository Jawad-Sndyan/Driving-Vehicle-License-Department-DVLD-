using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsApplicationTypes
    {
        public int ApplicationTypesID { get; private set; }
        public string ApplicationTypeTitle { get; set; }    
        public float ApplicationFees { get; set; }


        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationType(ApplicationTypesID, ApplicationTypeTitle, ApplicationFees);
        }

        public  clsApplicationTypes(int applicationTypesID, string applicationTypeTitle, float applicationFees)
        {
            ApplicationTypesID=applicationTypesID;
            ApplicationTypeTitle=applicationTypeTitle;
            ApplicationFees=applicationFees;
        }


        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }


        public static clsApplicationTypes FindApplicationTypeByID(int applicationTypesID)
        {
            string applicationTypeTitle = "";
            float applicationFees = -1;
            bool Found = clsApplicationTypesData.GetApplicationTypeByID(applicationTypesID, ref applicationTypeTitle, ref applicationFees);

            if (Found)
                return new clsApplicationTypes(applicationTypesID, applicationTypeTitle, applicationFees);


            return null;
        }
        

        public bool Save()
        {
            return _UpdateApplicationType();
        }

    }
}
