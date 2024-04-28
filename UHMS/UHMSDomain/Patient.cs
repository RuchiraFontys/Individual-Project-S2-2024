using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHMSDomain
{
    public class Patient : User
    {
        public List<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public List<Allergy> Allergies { get; set; } = new List<Allergy>();

        
    }
}
