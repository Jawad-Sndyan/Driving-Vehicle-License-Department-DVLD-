using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDriverData
    {
        public static bool GetDriverInfoByID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select PersonID,CreatedByUserID,CreatedDate from Drivers where DriverID=@DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    CreatedDate = (DateTime)reader["CreatedDate"];
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

        public static bool GetDriverInfoByPersonID(int PersonID,ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select DriverID,CreatedByUserID,CreatedDate from Drivers where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    CreatedDate = (DateTime)reader["CreatedDate"];
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
        public static DataTable GetAllDrivers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select D.DriverID,D.PersonID,P.NationalNo,
                             FullName=P.FirstName+' '+P.SecondName+ISNULL(' '+P.ThirdName,'')+' '+P.LastName,
                             D.CreatedDate,
                             NumberOfActiveLicenses=
                             (select Count(L.LicenseID) from Licenses L
                             where L.IsActive=1 and L.DriverID=D.DriverID)
                             from Drivers D
                             join People P on P.PersonID=D.PersonID";

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
        public static int AddNewDriver(int PersonID,int CreatedByUserID)
        {

            int DriverID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Drivers]
                             ([PersonID]
                             ,[CreatedByUserID]
                             ,[CreatedDate])
                       VALUES
                             (@PersonID,
                             @CreatedByUserID,
                             @CreatedDate)
                      
                      SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DriverID = insertedID;
                }
            }

            catch (Exception ex)
            {
                DriverID = -1;
            }

            finally
            {
                connection.Close();
            }


            return DriverID;
        }
        public static bool UpdateDriver(int DriverID,int PersonID, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Drivers]
                             SET [PersonID] = @PersonID
                              ,[CreatedByUserID] = @CreatedByUserID
                              ,[CreatedDate] = @CreatedDate
                            WHERE DriverID=@DriverID
";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);


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
    }
}
