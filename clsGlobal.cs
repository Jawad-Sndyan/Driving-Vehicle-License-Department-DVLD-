using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static readonly string appSourceName = "DVLD";
        public static clsUser CurrentUser { get; set; }

        private static readonly string FilePathRegistry = @"HKEY_CURRENT_USER\Software\AlJawadProgrames\DVLD\Credentials";

        private static readonly string FilePath = @"F:\credentials.txt";

        private static bool CreateEventLog()
        {
            if (!EventLog.SourceExists(appSourceName))
            {
                EventLog.CreateEventSource(appSourceName, "Application");
                EventLog.WriteEntry(appSourceName, "Event Source Created", EventLogEntryType.Information);
                return true;
            }

            return false;
        }


        public static void InformationPrompt(string message)
        {
            if (!CreateEventLog())
                EventLog.WriteEntry(appSourceName, message, EventLogEntryType.Information);
        }

        public static void WarningPrompt(string message)
        {
            if (!CreateEventLog())
                EventLog.WriteEntry(appSourceName, message, EventLogEntryType.Warning);
        }

        public static void ErrorPrompt(string message)
        {
            if (!CreateEventLog())
                EventLog.WriteEntry(appSourceName, message, EventLogEntryType.Error);
        }

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


        public static bool SaveCredentialsToRegistry(string username, string password)
        {
            try
            {
                Registry.SetValue(FilePathRegistry, "User Name", clsUtil.Encrypt(username), RegistryValueKind.String);
                Registry.SetValue(FilePathRegistry, "Password", clsUtil.Encrypt(password), RegistryValueKind.String);
            }
            catch (Exception ex)
            {
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

        public static bool RetrieveCredentialsFromRegistry(ref string username, ref string password)
        {
            string Username, Password;

            try
            {
                Username = clsUtil.Decrypt(Registry.GetValue(FilePathRegistry, "User Name", null) as string);

                if (Username == null)
                    return false;
                else
                    username = Username;

                Password = clsUtil.Decrypt(Registry.GetValue(FilePathRegistry, "Password", null) as string);

                if (Password == null)
                    return false;
                else
                    password = Password;
            }
            catch { return false; }

            return true;
        }
    }
}
