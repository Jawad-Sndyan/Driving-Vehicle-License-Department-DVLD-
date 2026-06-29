using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                            LDLA.LocalDrivingLicenseApplicationID,
                            LC.ClassName,
                            P.NationalNo,
                            FullName = P.FirstName + ' ' + P.SecondName + ISNULL(' ' + P.ThirdName, '') + '     ' + P.LastName,
                            App.ApplicationDate,
                            Pass = (
                                SELECT COUNT(Tests.TestResult)
                                FROM TestAppointments
                                INNER JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                WHERE TestAppointments.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                                  AND Tests.TestResult = 1
                            ),
                            [Status] = CASE App.ApplicationStatus
                                           WHEN 1 THEN 'New'
                                           WHEN 2 THEN 'Cancelled'
                                           WHEN 3 THEN 'Completed'
                                           ELSE 'Unknown'
                                       END
                        FROM LocalDrivingLicenseApplication LDLA
                        JOIN LicenseClasses LC ON LC.LicenseClassID = LDLA.LicenseClassID
                        JOIN Applications App ON App.ApplicationID = LDLA.ApplicationID
                        JOIN People P ON P.PersonID = App.ApplicantPersonID
                        ORDER BY LDLA.LocalDrivingLicenseApplicationID DESC
                        ";

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

            string query = @"select ApplicationID, LicenseClassID from LocalDrivingLicenseApplication
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


                    ApplicationID = (int)(reader["ApplicationID"]);
                    LicenseClassID = (int)(reader["LicenseClassID"]);

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

            string query = @"select * from LocalDrivingLicenseApplication
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

            string query = @"INSERT INTO LocalDrivingLicenseApplication
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
                LocalDrivingLicenseApplicationID= - 1;
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

            string query = @"UPDATE LocalDrivingLicenseApplication
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

            string query = @"DELETE FROM LocalDrivingLicenseApplication
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

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool TestResult = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select top 1 Tests.TestResult 
                             from LocalDrivingLicenseApplication LDLA
                             join TestAppointments TestApp on LDLA.LocalDrivingLicenseApplicationID =   TestApp.LocalDrivingLicenseApplicationID
                             join Tests on Tests.TestAppointmentID = TestApp.TestAppointmentID
                             where TestApp.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             and TestApp.TestTypeID = @TestTypeID
                             order by TestApp.AppointmentDate desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && bool.TryParse(result.ToString(), out bool testResult))
                {
                    TestResult = testResult;
                }
            }

            catch (Exception ex)
            {
                TestResult = false;
            }

            finally
            {
                connection.Close();
            }


            return TestResult;
        }


        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int Attended = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                      string query = @"SELECT TOP 1
                     CASE WHEN T.TestID IS NULL THEN -1 ELSE 1 END AS Attended
                 FROM TestAppointments TA
                 LEFT JOIN Tests T 
                     ON T.TestAppointmentID = TA.TestAppointmentID
                 WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                   AND TA.TestTypeID =@TestTypeID
                 ORDER BY TA.AppointmentDate DESC;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int attended))
                {
                    Attended = attended;
                }
            }

            catch (Exception ex)
            {
                Attended = -1;
            }

            finally
            {
                connection.Close();
            }

            return Attended == 1;
        }

        public static int TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int TotalTrials = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select TotalTrials=count(TestApp.TestAppointmentID)
                       from TestAppointments TestApp
                       Left join Tests T on T.TestAppointmentID = TestApp.TestAppointmentID
                       WHERE TestApp.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                         AND TestApp.TestTypeID =@TestTypeID
                       ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int Trials))
                {
                    TotalTrials = Trials;
                }
            }

            catch (Exception ex)
            {
                TotalTrials = -1;
            }

            finally
            {
                connection.Close();
            }

            return TotalTrials;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select top 1 Found=1
                             from TestAppointments TA
                             where TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             and TA.TestTypeID = @TestTypeID and TA.IsLocked=0 ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Result = true;
                }
            }
            catch (Exception ex)
            {
                Result = false;
            }
            finally
            {
                connection.Close();
            }

            return Result;
        }

    }
}
