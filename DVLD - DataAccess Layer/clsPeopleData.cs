using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___DataAccess_Layer
{
    public class clsPeopleData
    {

        public static DataTable LoadAllPeopleFromDB()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "SELECT * FROM People";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
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
                connection.Close();
            }

            return dt;
        }

        public static int AddNewPersonToDB(int nationalNo, string firstName, string secondName,
                                string thirdName, string lastName, string gender, DateTime birthDate,
                                string address, int countryId, string phone, string email,
                                string imagePath)
        {
            int personID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, " +
                        "Gender, BirthDate, Address, CountryID, Phone, Email, Image) " +
                        "VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, " +
                        "@Gender, @BirthDate, @Address, @CountryID, @Phone, @Email, @ImagePath);" +
                        "SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NationalNo", nationalNo);
            cmd.Parameters.AddWithValue("@FirstName", firstName);

            if (secondName != null)
                cmd.Parameters.AddWithValue("@SecondName", secondName);
            else
                cmd.Parameters.AddWithValue("@SecondName", System.DBNull.Value);

            if (thirdName != null)
                cmd.Parameters.AddWithValue("@ThirdName", thirdName);
            else
                cmd.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@BirthDate", birthDate);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@CountryID", countryId);

            if (phone != null)
                cmd.Parameters.AddWithValue("@Phone", phone);
            else
                cmd.Parameters.AddWithValue("@Phone", System.DBNull.Value);

            cmd.Parameters.AddWithValue("@Email", email);

            if (imagePath != null)
                cmd.Parameters.AddWithValue("@ImagePath", imagePath);
            else
                cmd.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedId))
                {
                    personID = insertedId;
                }
            }
            catch (Exception)
            {
                ;
            }
            finally
            {
                connection.Close();
            }
            return personID;
        }

        public static bool UpdatePersonInDB(int personID, int nationalNo, string firstName, 
                string secondName, string thirdName, string lastName, string gender, 
                DateTime birthDate, string address, int countryId, string phone, 
                string email, string imagePath)
        {
            bool isUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "UPDATE People SET NationalNo = @NationalNo, FirstName = @FirstName, " +
                        "SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName, " +
                        "Gender = @Gender, BirthDate = @BirthDate, Address = @Address, " +
                        "CountryID = @CountryID, Phone = @Phone, " + "Email = @Email, Image = @ImagePath "
                        +"WHERE personID = @personid";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@personid", personID);
            cmd.Parameters.AddWithValue("@NationalNo", nationalNo);
            cmd.Parameters.AddWithValue("@FirstName", firstName);

            if (secondName != null)
                cmd.Parameters.AddWithValue("@SecondName", secondName);
            else
                cmd.Parameters.AddWithValue("@SecondName", System.DBNull.Value);

            if (thirdName != null)
                cmd.Parameters.AddWithValue("@ThirdName", thirdName);
            else
                cmd.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@BirthDate", birthDate);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@CountryID", countryId);

            if (phone != null)
                cmd.Parameters.AddWithValue("@Phone", phone);
            else
                cmd.Parameters.AddWithValue("@Phone", System.DBNull.Value);

            cmd.Parameters.AddWithValue("@Email", email);

            if (imagePath != null)
                cmd.Parameters.AddWithValue("@ImagePath", imagePath);
            else
                cmd.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    isUpdated = true;
                }
            }
            catch (Exception e)
            {
                ;
            }
            finally { connection.Close(); }

            return isUpdated;
        }



        public static DataTable GetAllCountriesFromDB()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "SELECT * from Countries";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception e)
            {

                ;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetPersonByID(int id, ref int NationalNo, ref string FirstName, ref string SecondName, 
            ref string ThirdName, ref string LastName, ref string Gender, ref DateTime BirthDate, 
            ref int CountryId,  ref string Phone, ref string Email, ref string Address, 
            ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NationalNo = (int)reader["NationalNo"];
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"] != DBNull.Value ? reader["SecondName"].ToString() : "";
                    ThirdName = reader["ThirdName"] != DBNull.Value ? reader["ThirdName"].ToString() : "";
                    LastName = reader["LastName"].ToString();
                    Gender = reader["Gender"].ToString();
                    BirthDate = (DateTime)reader["BirthDate"];
                    CountryId = (int)reader["CountryID"];
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "";
                    Email = reader["Email"].ToString();
                    ImagePath = reader["Image"] != DBNull.Value ? reader["Image"].ToString() : "";

                    reader.Close();

                }
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetPersonByNationalNumber(ref int id, int NationalNo, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref string Gender, ref DateTime BirthDate,
            ref int CountryId, ref string Phone, ref string Email, ref string Address,
            ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    id = (int)reader["PersonID"];
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"] != DBNull.Value ? reader["SecondName"].ToString() : "";
                    ThirdName = reader["ThirdName"] != DBNull.Value ? reader["ThirdName"].ToString() : "";
                    LastName = reader["LastName"].ToString();
                    Gender = reader["Gender"].ToString();
                    BirthDate = (DateTime)reader["BirthDate"];
                    CountryId = (int)reader["CountryID"];
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "";
                    Email = reader["Email"].ToString();
                    ImagePath = reader["Image"] != DBNull.Value ? reader["Image"].ToString() : "";

                    reader.Close();

                }
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetPersonByFirstName(ref int id, ref int NationalNo, string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref string Gender, ref DateTime BirthDate,
            ref int CountryId, ref string Phone, ref string Email, ref string Address,
            ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT * FROM People WHERE FirstName = @FirstName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    id = (int)reader["PersonID"];
                    NationalNo = (int)reader["NationalNo"];
                    SecondName = reader["SecondName"] != DBNull.Value ? reader["SecondName"].ToString() : "";
                    ThirdName = reader["ThirdName"] != DBNull.Value ? reader["ThirdName"].ToString() : "";
                    LastName = reader["LastName"].ToString();
                    Gender = reader["Gender"].ToString();
                    BirthDate = (DateTime)reader["BirthDate"];
                    CountryId = (int)reader["CountryID"];
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "";
                    Email = reader["Email"].ToString();
                    ImagePath = reader["Image"] != DBNull.Value ? reader["Image"].ToString() : "";

                    reader.Close();

                }
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool DeletePersonFromDB(int personID)
        {
            bool isDeleted = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "DELETE from People WHERE PersonID = @PersonID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", personID);

            try
            {
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
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
                connection.Close();
            }

            return isDeleted;
        }

        public static bool GetCountryByID(int countryId, ref string countryName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"SELECT CountryName FROM Countries
                             WHERE CountryID = @countryID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@countryID", countryId);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    countryName = reader["CountryName"].ToString();

                    reader.Close();
                }
            }
            catch (Exception)
            {
                ;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetCountryByName(string countryName, ref int countryId)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"SELECT CountryID FROM Countries
                             WHERE CountryName = @countryName;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@countryName", countryName);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    countryId = (int) reader["CountryID"];

                    reader.Close();
                }
            }
            catch (Exception)
            {
                ;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

    }
}
