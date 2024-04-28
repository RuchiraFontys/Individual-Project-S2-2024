using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHMSDomain
{
    public class MedicalRecord
    {
        public int RecordId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Diagnosis { get; set; }
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public DateTime LastModifiedDate { get; set; }

        
    }
}
