using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IHealthAlert
    {
        void GenerateHealthAlert(HealthAlert healthAlert);
        HealthAlert GetHealthAlertById(int alertId);
        void UpdateHealthAlert(HealthAlert updatedAlert);
        void DeleteHealthAlert(int alertId);
        List<HealthAlert> GetHealthAlertsByPatientId(int patientId);
    }
}
