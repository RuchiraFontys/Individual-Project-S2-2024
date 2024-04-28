using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? SSN { get; set; }
        public string? EmailAddress { get; set; }
        public string? HomeAddress { get; set; }
        public string? Password { get; set; }
        public Role Role { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    public enum Role
    {
        Doctor = 1,
        Patient = 2,
        Administrator = 3
    }
}
