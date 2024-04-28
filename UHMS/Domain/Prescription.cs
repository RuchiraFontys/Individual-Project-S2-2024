using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public Patient Patient { get; set; }
        public List<Medication> Medications { get; set; }
        public string Notes { get; set; }
        public DateTime ValidUntil { get; set; }
        public string IssuedPlace { get; set; }
    }
}
