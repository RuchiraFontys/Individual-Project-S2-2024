using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Patient : User
    {
        public MedicalRecord? MedicalRecord { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Allergy>? Allergies { get; set; }
    }

    public enum Allergy
    {
        Penicillin = 1,
        Nuts = 2,
        Latex = 3,
        Pollen = 4,
        AnimalDander = 5
    }
}
