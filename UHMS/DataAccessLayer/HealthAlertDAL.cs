using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class HealthAlertDAL
    {
        public void CreateHealthAlert(HealthAlert healthAlert)
        {
            // add a new health alert to the database
        }

        public HealthAlert GetHealthAlertById(int alertId)
        {
            // retrieve a health alert by its ID
            return null; // placeholder return
        }

        public void UpdateHealthAlert(HealthAlert healthAlert)
        {
            // update an existing health alert
        }

        public void DeleteHealthAlert(int alertId)
        {
            // delete a health alert by its ID
        }

        public List<HealthAlert> GetHealthAlertsByPatientId(int patientId)
        {
            // retrieve all health alerts for a given patient
            return new List<HealthAlert>(); // placeholder return
        }
    }
}
