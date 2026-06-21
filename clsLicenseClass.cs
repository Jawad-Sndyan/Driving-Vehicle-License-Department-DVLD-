using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; set; }
        string ClassName { get; set; }
        string ClassDescription { get; set; }
        int MinimumAllowedAge { get; set; }
        int DefaultValidityLength { get; set; }
        float ClassFees { get; set; }

        public clsLicenseClass()
        {
            LicenseClassID = -1;
            ClassName = string.Empty;
            ClassDescription = string.Empty;
            MinimumAllowedAge = -1;
            DefaultValidityLength = -1;
            ClassFees = -1;
        }

        public clsLicenseClass(int licenseClassID, string className, string classDescription, int minimumAllowedAge, int defaultValidityLength, float classFees)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }
        public static clsLicenseClass FindByID(int licenseClassID)
        {
            string className, classDescription;
            int minimumAllowedAge, defaultValidityLength;
            float classFees;
            className = classDescription = string.Empty;
            minimumAllowedAge = defaultValidityLength = -1;
            classFees = -1;


            bool isFound = clsLicenseClassData.GetLicenseClassInfoByID(licenseClassID, ref className, ref classDescription, ref minimumAllowedAge,
              ref defaultValidityLength, ref classFees);

            if (isFound)
            {
                return new clsLicenseClass(licenseClassID, className, classDescription, minimumAllowedAge,
                    defaultValidityLength, classFees);
            }

            return null;    
        }


        public static clsLicenseClass FindByClassName(string className)
        {
            string classDescription;
            int minimumAllowedAge, defaultValidityLength, licenseClassID;
            float classFees;
            classDescription = string.Empty;
            minimumAllowedAge = defaultValidityLength = licenseClassID = -1;
            classFees = -1;


            bool isFound = clsLicenseClassData.GetLicenseClassInfoByClassName(className, ref licenseClassID, ref classDescription, ref minimumAllowedAge,
              ref defaultValidityLength, ref classFees);

            if (isFound)
            {
                return new clsLicenseClass(licenseClassID, className, classDescription, minimumAllowedAge,
                    defaultValidityLength, classFees);
            }

            return null;
        }
    }
}
