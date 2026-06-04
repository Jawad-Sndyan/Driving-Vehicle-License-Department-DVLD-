using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsUser
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;
        private enum enIsActive {NotActive=0,Active=1 };
        public int UserID { get; set; }
        public int PersonID {  get; set; }
        public string UserName { get;set; }
        public string Password { get;set; }
        public bool IsActive { get;set; }


        public clsPerson Person;

        private bool _AddUser()
        {
            UserID = clsUserData.AddNewUser(PersonID, UserName, Password, IsActive);

            return UserID != -1;
        }


        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(UserID,PersonID, UserName, Password, IsActive);
        }


        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = Convert.ToBoolean(enIsActive.NotActive);
            Person=new clsPerson();
            Mode = enMode.AddNew;
        }

        public clsUser(int UserID,int PersonID, string UserName, string Password,bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;   
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            Person =clsPerson.Find(PersonID);
            Mode = enMode.Update;
        }


        public static bool DeleteUser(int ID)
            => clsUserData.DeleteUser(ID);


        public static DataTable GetAllUsers()
            { return clsUserData.GetAllUsers(); }

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1;
            string  UserName = "", Password = "";
            bool IsActive = false;



            bool Found = clsUserData.GetUserInfoByID(UserID,ref PersonID,ref UserName,ref Password,ref IsActive);


            if(Found)   
                return new clsUser(UserID,PersonID,UserName,Password,IsActive);

            return null;


        }



         public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string  UserName = "", Password = "";
            bool IsActive = false;



            bool Found = clsUserData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName,ref Password,ref IsActive);


            if(Found)   
                return new clsUser(UserID,PersonID,UserName,Password,IsActive);

            return null;


        }


        public static bool IsUserExistByUserID(int UserID)
        {
            return clsUserData.IsUserExistByUserID(UserID);
        }

        public static bool IsUserExistByUserName(string UserName)
            => clsUserData.IsUserExistByUserName(UserName);

        public static bool IsUserExistByPersonID(int PersonID)
            => clsUserData.IsUserExistByPersonID(PersonID);
        public bool Save()
        {
            switch(Mode)
                {
                case enMode.AddNew:
                    if(_AddUser()) 
                        return true;

                    return false;
                case enMode.Update:
                    if(_UpdateUser())
                        return true;

                    return false;
            }

            return false;
        }


    }
}
