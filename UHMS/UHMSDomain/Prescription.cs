using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHMSDomain
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public int PatientId { get; set; } 
        public int MedicalRecordId { get; set; } 
        public string MedicationDetails { get; set; } 
        public string Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }

        
    }
}
