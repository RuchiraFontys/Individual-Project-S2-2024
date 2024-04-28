using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer;
using BCrypt.Net;
using Microsoft.Data.SqlClient;

namespace BusinessLogic
{
    public class UserManager
    {
        private UserDAL _userDAL = new UserDAL();

        public async Task<int> RegisterUserAsync(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            try
            {
                // The RegisterUserAsync method should return the user's ID upon successful insertion
                int userId = await _userDAL.RegisterUserAsync(user);
                if (userId == 0)
                {
                    throw new Exception("User registration failed. The operation did not modify any records.");
                }
                return userId;
            }
            catch (SqlException ex)
            {
                // Log the exception details here
                throw new Exception("User registration failed due to a database error.", ex);
            }
            catch (Exception ex)
            {
                // Log unexpected exceptions
                throw new Exception("An unexpected error occurred during user registration.", ex);
            }
        }

        public User Login(string identifier, string password)
        {
            // Retrieve the user by identifier from the database
            User? user = _userDAL.GetUserByIdentifier(identifier);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            else
            {
                throw new Exception("Login failed. Please check your identifier and password.");
            }
        }

        public void UpdateUserProfile(int userId, User updatedUser)
        {
            // user profile update logic
        }

        public void DeleteUser(int userId)
        {
            // user deletion logic
        }

        public void UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            // password update logic here
        }
    }
}
