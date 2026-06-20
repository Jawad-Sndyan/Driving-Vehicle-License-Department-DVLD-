using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select LDLA.LocalDrivingLicenseApplicationID,LC.ClassName,P.NationalNo,
                              FullName = P.FirstName+' '+P.SecondName+ ISNULL(' '+P.ThirdName,'')+'     '+P.LastName
                              ,App.ApplicationDate,Pass=3,
                              case App.ApplicationStatus
                               when 1 then 'New'
                               when 2 then 'Cancelled'
                               when 3 then 'Completed'
                               else 'Unknown' 
                              end
                              as [Status]
                              from LocalDrivingLicenseApplications LDLA 
                              join LicenseClasses LC on LC.LicenseClassID=LDLA.LicenseClassID 
                              join Applications App on App.ApplicationID=LDLA.ApplicationID
                              join People P on P.PersonID=App.ApplicantPersonID
                              Order By LDLA.LocalDrivingLicenseApplicationID Desc";

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

        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from LocalDrivingLicenseApplications
                              where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;


                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);

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



        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from LocalDrivingLicenseApplications
                              where ApplicationID=@ApplicationID";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;


                    LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);

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


        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {

            int LocalDrivingLicenseApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO LocalDrivingLicenseApplications
                                    (ApplicationID
                                    ,LicenseClassID)
                              VALUES
                                    (@ApplicationID
                                    ,@LicenseClassID)
                              SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LocalDrivingLicenseApplicationID = insertedID;
                }
            }

            catch (Exception ex)
            {
                return -1;
            }

            finally
            {
                connection.Close();
            }


            return LocalDrivingLicenseApplicationID;
        }


        public static bool UpdateLocalDrivingLicenseApplication(int ID, int ApplicationID, int LicenseClassID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE LocalDrivingLicenseApplications
                              SET ApplicationID = @ApplicationID
                                 ,LicenseClassID = @LicenseClassID
                            WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static bool DeleteLocalDrivingLicenseApplication(int ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM LocalDrivingLicenseApplications
                            WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }


    }
}
