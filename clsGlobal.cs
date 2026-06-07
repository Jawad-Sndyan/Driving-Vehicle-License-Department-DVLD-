using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Buisness
{
    public class clsGlobal
    {
        public static clsUser CurrentUser { get; set; }

        private static readonly string FilePath = @"F:\credentials.txt";

        public static bool SaveCredentials(string username, string password)
        {
            try
            {
                if (username == "" && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return true;

                }


                password = clsUtil.Encrypt(password);
                username = clsUtil.Encrypt(username);
                string[] lines =
                {
            $"Username={username.Trim()}",
            $"Password={password.Trim()}"
             };

                // Creates the file if it doesn't exist, overwrites it if it does
                File.WriteAllLines(FilePath, lines);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

            return true;
        }

        public static bool RetrieveCredentials(ref string username, ref string password)
        {
            if (!File.Exists(FilePath))
               return false;

            foreach (string line in File.ReadAllLines(FilePath))
            {
                if (line.StartsWith("Username="))
                    username = clsUtil.Decrypt(line.Substring("Username=".Length)).Trim();
                else if (line.StartsWith("Password="))
                    password = clsUtil.Decrypt(line.Substring("Password=".Length)).Trim(); 
            }

            return true;
        }
    }
}
