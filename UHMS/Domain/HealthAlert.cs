using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class HealthAlert
    {
        public int AlertId { get; set; }
        public Patient Patient { get; set; }
        public string Message { get; set; }
        public DateTime DateGenerated { get; set; }
    }
}
