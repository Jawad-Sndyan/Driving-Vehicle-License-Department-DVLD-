using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsValidator
    {
        public static bool IsValidID(int ID) => ID > 0;

        public static bool IsValidName(string Name)
        => !string.IsNullOrWhiteSpace(Name) &&
           Name.Length >= 2 &&
           Name.Length <= 50 &&
           Regex.IsMatch(Name, @"^[a-zA-Z\u0600-\u06FF\s]+$");
        public static bool IsValidFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return false;

            string normalized = Regex.Replace(fullName.Trim(), @"\s{2,}", " ");

            return normalized.Length >= 4 &&
                   normalized.Length <= 200 &&
                   Regex.IsMatch(normalized, @"^[a-zA-Z\u0600-\u06FF\s]+$");
        }

       
        public static bool IsValidAddress(string address)
                => string.IsNullOrWhiteSpace(address) ||
                   (address.Length >= 5 && address.Length <= 255);

        public static bool IsValidPhone(string phone)
        => string.IsNullOrWhiteSpace(phone) ||
           Regex.IsMatch(phone, @"^\+?[\d\s\-\(\)]{7,20}$");

        public static bool IsValidEmail(string email)
        => string.IsNullOrWhiteSpace(email) || 
           Regex.IsMatch(email,
               @"^[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}$");

        public static bool IsValidNationalID(string nationalID)
        {
            if (string.IsNullOrWhiteSpace(nationalID))
                return false;

            nationalID = nationalID.Trim();

           
            if (nationalID.Length != 8)
                return false;

            if (!Regex.IsMatch(nationalID, @"^\d+$"))
                return false;

            return true;
        }

        public static bool IsValidImagePath(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                return true; 

            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            string ext = Path.GetExtension(imagePath).ToLower();

            return allowedExtensions.Contains(ext);
        }

        public static bool IsValidPassword(string password)
    => !string.IsNullOrWhiteSpace(password) &&
       password.Length >= 4 &&
       Regex.IsMatch(password, @"^\d+$");

        public static bool IsValidUsername(string username)
    => !string.IsNullOrWhiteSpace(username) &&
       username.Length >= 3 &&
       username.Length <= 20 &&
       Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$");


        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }
    }
}
