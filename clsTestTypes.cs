using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsTestTypes
    {
        public int TestTypeID { get; set; } 
        public string TestTypeTitle { get; set; } 
        public string TestTypeDescription { get; set; }
         public float TestTypeFees { get; set; }    

        private bool _UpdateTestType(int testTypeID, string testTypeTitle, string testTypeDescription,
          float testTypeFees)
        {
            return clsTestTypesData.UpdateTestType(testTypeID, testTypeTitle, testTypeDescription, testTypeFees);
        }

        public clsTestTypes(int testTypeID, string testTypeTitle, string testTypeDescription,
          float testTypeFees)
        {
            TestTypeID=testTypeID;
            TestTypeTitle=testTypeTitle;
            TestTypeDescription=testTypeDescription;
            TestTypeFees=testTypeFees;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        public static clsTestTypes FindTestTypeByID(int testTypeID)
        {
            string testTypeTitle = "", testTypeDescription = "";
            float testTypeFees = -1;

            bool isFound = clsTestTypesData.GetTestTypeInfoByID(testTypeID, ref testTypeTitle, ref testTypeDescription, ref testTypeFees);

            if (isFound)
                return new clsTestTypes(testTypeID, testTypeTitle, testTypeDescription, testTypeFees);


            return null;
        }

        public bool Save()
        {
            return _UpdateTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
        }

    }
}
