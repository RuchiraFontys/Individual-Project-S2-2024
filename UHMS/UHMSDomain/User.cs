using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace UHMSDomain
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public abstract class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string TelephoneNumber { get; set; }
        public string SSN { get; set; }
        public string EmailAddress { get; set; }
        public string HomeAddress { get; set; }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = HashPassword(value); }
        }

        protected string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        
    }
}
