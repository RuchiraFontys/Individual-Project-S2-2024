using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHMSDomain
{
    public class Medication
    {
        public int MedicationId { get; set; }
        public string Name { get; set; }
        public string PossibleSideEffects { get; set; }
        public string Contraindications { get; set; }
        public string DosageForm { get; set; } 
        public string Dosage { get; set; } 
        public string UsedFor { get; set; }

       
    }
}
