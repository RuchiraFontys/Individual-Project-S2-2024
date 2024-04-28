using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMedication
    {
        void AddMedication(Medication medication);
        Medication GetMedication(int medicationId);
        void UpdateMedication(int medicationId, Medication updatedMedication);
        void DeleteMedication(int medicationId);
        List<Medication> GetAllMedications();
        void CheckForHealthAlerts(int patientId, Medication medication);
    }
}
