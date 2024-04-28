using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer;

namespace BusinessLogic
{
    public class AppointmentManager
    {
        public void CreateAppointment(Appointment appointment)
        {
            // appointment creation logic
        }

        public void UpdateAppointment(int appointmentId, Appointment updatedAppointment)
        {
            // update logic
        }

        public void CancelAppointment(int appointmentId)
        {
            // cancellation logic
        }

        public Appointment GetAppointmentDetails(int appointmentId)
        {
            // logic to retrieve appointment details
            return null;
        }
    }
}
