using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenseClassData
    {
        public static DataTable GetAllLicenseClasses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from LicenseClasses";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool GetLicenseClassInfoByID(int LicenseClassID, ref string ClassName,ref string ClassDescription, ref int MinimumAllowedAge,ref int DefaultValidityLength,ref float ClassFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select ClassName,ClassDescription,MinimumAllowedAge,
                            DefaultValidityLength,ClassFees from LicenseClasses
                            where LicenseClassID=@LicenseClassID";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    ClassName = reader["ClassName"].ToString();
                    ClassDescription = reader["ClassDescription"].ToString();
                    MinimumAllowedAge = Convert.ToInt32(reader["MinimumAllowedAge"]);
                    DefaultValidityLength = Convert.ToInt32(reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);

                }
                else
                {
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }




        public static bool GetLicenseClassInfoByClassName(string ClassName, ref int LicenseClassID, ref string ClassDescription, ref int MinimumAllowedAge, ref int DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select LicenseClassID,ClassDescription,MinimumAllowedAge,
                            DefaultValidityLength,ClassFees from LicenseClasses
                            where ClassName=@ClassName";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                    ClassDescription = reader["ClassDescription"].ToString();
                    MinimumAllowedAge = Convert.ToInt32(reader["MinimumAllowedAge"]);
                    DefaultValidityLength = Convert.ToInt32(reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);

                }
                else
                {
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}
