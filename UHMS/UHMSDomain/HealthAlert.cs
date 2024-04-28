using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHMSDomain
{
    public class HealthAlert
    {
        public int AlertId { get; set; }
        public int PatientId { get; set; } 
        public string Message { get; set; }
        public DateTime DateGenerated { get; set; }

        
    }
}
