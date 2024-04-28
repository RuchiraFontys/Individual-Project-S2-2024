using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAppointment
    {
        void CreateAppointment(Appointment appointment);
        void UpdateAppointment(int appointmentId, Appointment updatedAppointment);
        void CancelAppointment(int appointmentId);
        Appointment GetAppointmentDetails(int appointmentId);
    }
}
