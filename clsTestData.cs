using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestData
    {
        public static bool GetTestInfoByID(int TestID,ref int TestAppointmentID,ref bool TestResult,ref string Notes,ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select TestAppointmentID,TestResult,Notes,CreatedByUserID from Tests where TestID=@TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["Notes"];
                    else
                        Notes = "";

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

        public static bool GetLastTestInfoForPerson(int PersonID,int LicenseClassID,int TestTypeID,
            ref int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select top 1 T.TestID,T.TestAppointmentID,T.TestResult,
                             T.Notes,T.CreatedByUserID
                             from Tests T
                             join TestAppointments TA on TA.TestAppointmentID=T.TestAppointmentID
                             join TestTypes TT on TT.TestTypeID=TA.TestTypeID
                             join LocalDrivingLicenseApplication LDLA on LDLA.LocalDrivingLicenseApplicationID=TA.LocalDrivingLicenseApplicationID
                             join Applications A on A.ApplicationID = lDLA.ApplicationID
                             join People P on P.PersonID=A.ApplicantPersonID
                             join LicenseClasses LC on LDLA.LicenseClassID=LC.LicenseClassID
                             where P.PersonID=@PersonID and LC.LicenseClassID=@LicenseClassID and TA.TestTypeID=@TestTypeID
                             order by TA.AppointmentDate desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["Notes"];
                    else
                        Notes = "";

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

        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select  T.TestID,T.TestAppointmentID,T.TestResult,
                              T.Notes,T.CreatedByUserID
                              from Tests T
                              order by T.TestID";

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
                dt = null;
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int AddNewTest(int TestAppointmentID,bool TestResult,string Notes,int CreatedByUserID)
        {

            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Tests]
                             ([TestAppointmentID]
                            ,[CreatedByUserID]
                            ,[TestResult]
                            ,[Notes])
                      VALUES
                            (@TestAppointmentID,
                            @CreatedByUserID,
                            @TestResult,
                            @Notes);

                       Update TestAppointments
                       SET IsLocked=1 where TestAppointmentID=@TestAppointmentID

                      SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes != "" && Notes != null)
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }
            }

            catch (Exception ex)
            {
                TestID = -1;
            }

            finally
            {
                connection.Close();
            }


            return TestID;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Tests]
                           SET [TestAppointmentID] = @TestAppointmentID
                              ,[CreatedByUserID] = @CreatedByUserID
                              ,[TestResult] = @TestResult
                              ,[Notes] = @Notes
                         WHERE TestID=@TestID";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes != "" && Notes != null)
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                rowsAffected = 0;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static int GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            int PassedTestsCount = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select PassedTestsCount=Count(T.TestID) from Tests T
                             join TestAppointments TA on TA.TestAppointmentID=T.TestAppointmentID
                             join LocalDrivingLicenseApplication LDLA on LDLA.LocalDrivingLicenseApplicationID=TA.LocalDrivingLicenseApplicationID
                             where LDLA.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and T.TestResult=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int Count))
                {
                    PassedTestsCount = Count;
                }
            }

            catch (Exception ex)
            {
                PassedTestsCount = -1;
            }

            finally
            {
                connection.Close();
            }

            return PassedTestsCount;

        }

        public static int GetTestIDForTestAppointment(int TestAppointmentID)
        {
            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select TestID from Tests where TestAppointmentID=@TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    TestID = ID;
                }
            }

            catch (Exception ex)
            {
                TestID = -1;
            }

            finally
            {
                connection.Close();
            }

            return TestID;
        }


    }
}
