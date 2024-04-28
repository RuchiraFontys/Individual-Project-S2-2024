using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUser
    {
        void RegisterUser(User user);
        User Login(string identifier, string password);
        void UpdateUserProfile(int userId, User updatedUser);
        void DeleteUser(int userId);
        void UpdatePassword(int userId, string oldPassword, string newPassword);
    }
}
