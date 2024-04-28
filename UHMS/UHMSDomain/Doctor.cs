using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHMSDomain
{
    public enum Specialization
    {
        Dentist,
        EyeDoctor,
        GeneralPractitioner,
        Neurologist,
        Oncologist
    }

    public class Doctor : User
    {
        public int DoctorJobId { get; set; }
        public Specialization Specialization { get; set; }

        
    }
}
