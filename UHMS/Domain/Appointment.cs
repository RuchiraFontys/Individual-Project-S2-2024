using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public VisitType VisitType { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
    }

    public enum VisitType
    {
        CheckUp = 1,
        EyeCheck = 2,
        Consultation = 3,
        FollowUp = 4,
        Emergency = 5
    }

    public enum AppointmentStatus
    {
        Scheduled,
        Confirmed,
        Cancelled,
        Completed,
        NoShow
    }
}
