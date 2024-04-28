using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHMSDomain
{
    public enum VisitType
    {
        CheckUp,
        EyeCheck,
        Consultation,
        FollowUp,
        Emergency
    }

    public enum AppointmentStatus
    {
        Scheduled,
        Confirmed,
        Cancelled,
        Completed,
        NoShow
    }

    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public VisitType VisitType { get; set; }
        public AppointmentStatus Status { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }

}