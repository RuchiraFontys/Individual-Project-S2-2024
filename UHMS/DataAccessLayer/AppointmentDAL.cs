using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class AppointmentDAL
    {
        public void CreateAppointment(Appointment appointment)
        {
            // add a new appointment to the database
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            // retrieve an appointment by its ID
            return null;
        }

        public void UpdateAppointment(Appointment appointment)
        {
            // update an existing appointment
        }

        public void DeleteAppointment(int appointmentId)
        {
            // delete an appointment by its ID
        }
    }
}
