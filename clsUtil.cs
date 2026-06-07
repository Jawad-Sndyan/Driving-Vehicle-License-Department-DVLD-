using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsUtil
    {

        private static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }


        private static string ReplaceFileNameWithGUID(string sourceFile)
        {
            FileInfo file = new FileInfo(sourceFile);   
            string extn=file.Extension;
            return GenerateGUID() + extn;   
        }
        private static bool CreateFolderIfNotExists(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
                return true;
            }
            return false;
        }

        public static void DeleteImageFromImagesFolder(string imagePath)
        {
            string ImagesFolderPath = @"E:\DVLD-People-Images\";

            if (!string.IsNullOrEmpty(imagePath) && imagePath.StartsWith(ImagesFolderPath))
            {
                try { File.Delete(imagePath); }
                catch (IOException) { }
            }
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceImagePath)
        {
            string ImagesFolderPath = @"E:\DVLD-People-Images\";

            CreateFolderIfNotExists(ImagesFolderPath);
              
            try
            {
                string DestPath = ImagesFolderPath + ReplaceFileNameWithGUID(SourceImagePath); 

                File.Copy(SourceImagePath, DestPath);

                
                SourceImagePath = DestPath;
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        public static string Encrypt(string password)
        {
            string encrypted = "";
            foreach (char c in password)
                encrypted += (char)(c + 10);
            return encrypted;
        }

        public static string Decrypt(string encryptedPassword)
        {
            string decrypted = "";
            foreach (char c in encryptedPassword)
                decrypted += (char)(c - 10);
            return decrypted;
        }
    }
}
