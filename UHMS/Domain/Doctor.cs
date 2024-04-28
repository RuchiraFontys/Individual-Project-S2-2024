using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Doctor : User
    {
        public string? DoctorJobId { get; set; }
        public Specialization Specialization { get; set; }
    }

    public enum Specialization
    {
        Dentist = 1,
        EyeDoctor = 2,
        GeneralPractitioner = 3,
        Neurologist = 4,
        Cardiologist = 5,
        Oncologist = 6
    }
}
