using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationData
    {

        public static bool GetApplicationByID(int ApplicationID, ref int ApplicantPersonID,
        ref DateTime ApplicationDate, ref int ApplicationTypeID, ref int ApplicationStatus,
        ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from Applications
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

                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (int)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                    isFound = false;

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
        public static bool UpdateApplication(int ApplicationID,int ApplicantPersonID,
        DateTime ApplicationDate,int ApplicationTypeID,int ApplicationStatus,
        DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int rowesAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Applications
                             SET ApplicantPersonID = @ApplicantPersonID
                                ,ApplicationDate = @ApplicationDate
                                ,ApplicationTypeID = @ApplicationTypeID
                                ,ApplicationStatus = @ApplicationStatus
                                ,LastStatusDate = @LastStatusDate
                                ,PaidFees = @PaidFees
                                ,CreatedByUserID = @CreatedByUserID
                            where ApplicationID=@ApplicationID";


            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowesAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowesAffected > 0;

        }

        public static int AddNewApplication(int ApplicantPersonID,
            int ApplicationTypeID, float PaidFees, int CreatedByUserID)
        {

            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Applications
           (ApplicantPersonID
           ,ApplicationTypeID
           ,PaidFees
           ,CreatedByUserID)
     VALUES
           (@ApplicantPersonID,@ApplicationTypeID,@PaidFees,@CreatedByUserID);
            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
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


            return ApplicationID;
        }

        public static bool DeleteApplication(int ApplicationID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Applications
                            where ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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


        public static bool IsApplicationExist(int ApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 from Applications where ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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


        public static int GetActiveApplicationID(int ApplicantPersonID, int ApplicationTypeID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //  ApplicationStatus: 1=New  2=Cancelled  3=Completed
            string query = @"select ActiveAplicationID=ApplicationID from Applications
                           where ApplicantPersonID=@ApplicantPersonID and ApplicationTypeID=@ApplicationTypeID and ApplicationStatus=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return ApplicationID;

        }


        public static bool DoesPersonHaveActiveApplication(int ApplicantPersonID, int ApplicationTypeID)
        {
            return GetActiveApplicationID(ApplicantPersonID, ApplicationTypeID) != -1;
        }


        public static bool UpdateStatus(int ApplicationID, int NewStatus)
        {
            int rowesAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Applications
                             SET ApplicationStatus = @NewStatus
                                ,LastStatusDate = @LastStatusDate
                            where ApplicationID=@ApplicationID";


            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@NewStatus", NewStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

            try
            {
                connection.Open();
                rowesAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowesAffected > 0;

        }
    }


}
