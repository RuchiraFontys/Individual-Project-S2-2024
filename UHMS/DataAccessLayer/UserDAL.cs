using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class UserDAL
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536154_uhms;User Id=dbi536154_uhms;Password=individualUHMS;";

        public async Task<int> RegisterUserAsync(User user)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                // Check if a user with the same SSN or EmailAddress already exists
                string checkUserSql = @"
                    SELECT COUNT(1)
                    FROM Users
                    WHERE SSN = @SSN OR EmailAddress = @EmailAddress";

                using (var checkCommand = new SqlCommand(checkUserSql, connection))
                {
                    checkCommand.Parameters.AddWithValue("@SSN", user.SSN);
                    checkCommand.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);

                    object result = await checkCommand.ExecuteScalarAsync();
                    bool exists = result as int? > 0;

                    if (exists)
                    {
                        // A user with this SSN or EmailAddress already exists in the system
                        throw new Exception("A user with this SSN or EmailAddress already exists.");
                    }
                }

                // If the user does not exist, proceed to register the new user
                                string insertUserSql = @"
                INSERT INTO Users (FirstName, LastName, DateOfBirth, GenderId, TelephoneNumber, SSN, EmailAddress, HomeAddress, Password, RoleId)
                VALUES (@FirstName, @LastName, @DateOfBirth, @GenderId, @TelephoneNumber, @SSN, @EmailAddress, @HomeAddress, @Password, @RoleId);
                SELECT CAST(SCOPE_IDENTITY() AS int);"; // Retrieve the last inserted identity value

                using (var command = new SqlCommand(insertUserSql, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    command.Parameters.AddWithValue("@GenderId", (int)user.Gender);
                    command.Parameters.AddWithValue("@TelephoneNumber", user.TelephoneNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@SSN", user.SSN);
                    command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    command.Parameters.AddWithValue("@HomeAddress", user.HomeAddress ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Password", user.Password); // Ensure the password is already hashed
                    command.Parameters.AddWithValue("@RoleId", (int)user.Role);

                    // Execute the command and get the new UserId
                    var result = await command.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int userId))
                    {
                        return userId; // This is the newly inserted user's ID
                    }
                    else
                    {
                        throw new Exception("User registration failed. The operation did not return a valid ID.");
                    }
                }
            }
        }


        public User? GetUserByIdentifier(string identifier)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                string query = @"
                SELECT UserId, FirstName, LastName, DateOfBirth, GenderId, TelephoneNumber, SSN, EmailAddress, HomeAddress, Password, RoleId
                FROM Users
                WHERE EmailAddress = @Identifier OR SSN = @Identifier";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Identifier", identifier);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                Gender = (Gender)reader.GetInt32(reader.GetOrdinal("GenderId")),
                                TelephoneNumber = reader.IsDBNull(reader.GetOrdinal("TelephoneNumber")) ? null : reader.GetString(reader.GetOrdinal("TelephoneNumber")),
                                SSN = reader.GetString(reader.GetOrdinal("SSN")),
                                EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress")),
                                HomeAddress = reader.IsDBNull(reader.GetOrdinal("HomeAddress")) ? null : reader.GetString(reader.GetOrdinal("HomeAddress")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Role = (Role)reader.GetInt32(reader.GetOrdinal("RoleId"))
                            };
                        }
                    }
                }
            }
            return null; // Return null if the user is not found
        }

        public void UpdateUser(User user)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                string updateSql = @"
                UPDATE Users
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    DateOfBirth = @DateOfBirth,
                    GenderId = @GenderId,
                    TelephoneNumber = @TelephoneNumber,
                    EmailAddress = @EmailAddress,
                    HomeAddress = @HomeAddress,
                    RoleId = @RoleId
                WHERE UserId = @UserId";

                using (var command = new SqlCommand(updateSql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", user.Id);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    command.Parameters.AddWithValue("@GenderId", (int)user.Gender);
                    command.Parameters.AddWithValue("@TelephoneNumber", user.TelephoneNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    command.Parameters.AddWithValue("@HomeAddress", user.HomeAddress ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RoleId", (int)user.Role);

                    int result = command.ExecuteNonQuery();

                    // Check the result to see if the update was successful
                    if (result < 1)
                    {
                        // Handle the case when the user is not updated
                        throw new Exception("The user update operation failed or the user does not exist.");
                    }
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                string deleteSql = "DELETE FROM Users WHERE UserId = @UserId";

                using (var command = new SqlCommand(deleteSql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    int result = command.ExecuteNonQuery();

                    if (result < 1)
                    {
                        // No user was deleted, handle as needed
                        throw new Exception("The user deletion operation failed or the user does not exist.");
                    }
                }
            }
        }
    }
}
