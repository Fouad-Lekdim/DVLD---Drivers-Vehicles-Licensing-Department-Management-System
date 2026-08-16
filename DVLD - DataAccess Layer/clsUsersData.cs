using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___DataAccess_Layer
{
    public class clsUsersData
    {

        private static SqlConnection _connection = new SqlConnection(clsDataAccessSettings.connectionString);

        public static DataTable GetAllUsersFromDB()
        {
            DataTable dt = new DataTable();

            string query = @"select U.UserID, U.UserName, 
                    	    (P.FirstName + ' ' + ISNULL(P.SecondName + ' ', '') + 
                    	    ISNULL(P.ThirdName + ' ', '') + P.LastName) as FullName, U.PersonID, U.IsActive
                            FROM Users U
                            INNER JOIN People P ON P.personID = U.PersonID;";
            SqlCommand cmd = new SqlCommand(query, _connection);

            

            try
            {
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception)
            {
                ;
            }
            finally
            {
                _connection.Close();
            }

            return dt;
        }

        public static int AddNewUserToDB(int personId, string username, string password, bool isActive)
        {
            int insertedUserId = -1;

            string query = @"INSERT INTO USERS(UserName, Password, IsActive, PersonID) Values
                            (@username, @pwd, @isactive, @personid);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pwd", password);
            cmd.Parameters.AddWithValue("@isactive", isActive);
            cmd.Parameters.AddWithValue("@personid", personId);

            try
            {
                _connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int parsedResult))
                {
                    insertedUserId = parsedResult;
                }
            }
            catch (Exception)
            {
                ;
            }
            finally
            {
                _connection.Close();
            }

            return insertedUserId;
        }


        public static bool GetUserByID(int id, ref string username, ref string password, 
                ref bool isactive, ref int personId)
        {
            bool isFound = false;

            string query = @"SELECT * From Users
                             WHERE UserID = @UserID;";

            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@UserID", id);

            try
            {
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    username = reader["UserName"].ToString();
                    password = reader["Password"].ToString();
                    isactive = Convert.ToBoolean(reader["IsActive"]);
                    personId = Convert.ToInt32(reader["PersonID"]);

                    reader.Close();
                }
            }
            catch (Exception)
            {
                ;
            }
            finally { _connection.Close(); }

            return isFound;
        }

        public static bool GetUserByPersonID(int id, ref string username, ref string password,
        ref bool isactive, ref int userId)
        {
            bool isFound = false;

            string query = @"SELECT * From Users
                             WHERE PersonID = @PersonID;";

            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@PersonID", id);

            try
            {
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    username = reader["UserName"].ToString();
                    password = reader["Password"].ToString();
                    isactive = Convert.ToBoolean(reader["IsActive"]);
                    userId = Convert.ToInt32(reader["UserID"]);

                    reader.Close();
                }
            }
            catch (Exception)
            {
                ;
            }
            finally { _connection.Close(); }

            return isFound;
        }

        public static bool GetUserByUsername(string username, ref int userID, ref int personID, 
                                                            ref string password, ref bool isactive)
        {
            bool isFound = false;

            string query = @"SELECT * from Users
                             WHERE UserName = @username;";

            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@username", username);

            try
            {
                _connection.Open();
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    isFound = true;

                    userID = (int)r["UserID"];
                    personID = (int)r["PersonID"];
                    password = r["Password"].ToString();
                    isactive = Convert.ToBoolean(r["IsActive"]);

                    r.Close();
                }
            }
            catch (Exception)
            {
                ;
            }
            finally
            {
                _connection.Close();
            }

            return isFound;
                            
        }
        public static bool UpdateUser(int userId, string username, string password, bool isActive)
        {
            bool isUpdated = false;

            string query = @"Update Users 
                             SET UserName = @Username, Password = @Password, 
                                IsActive = @isactive
                             WHERE UserID = @UserId;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@isactive", isActive);
            cmd.Parameters.AddWithValue("@UserId", userId);

            try
            {
                _connection.Open();
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    isUpdated = true;

                }
            }
            catch (Exception)
            {

                ;
            }
            finally
            {
                _connection.Close();
            }

            return isUpdated;
        }

        public static bool DeleteUserFromDB(int UserID)
        {
            bool isDeleted = false;

            string query = @"Delete from Users
                             WHERE UserID = @UserId;";

            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@UserId", UserID);

            try
            {
                _connection.Open();

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    isDeleted = true;
                }
            }
            catch (Exception)
            {
                ;
            }
            finally
            {
                _connection.Close();
            }

            return isDeleted;
        }

    }
}
