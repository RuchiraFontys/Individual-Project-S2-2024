using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPrescription
    {
        void CreatePrescription(Prescription prescription);
        Prescription GetPrescription(int prescriptionId);
        void UpdatePrescription(int prescriptionId, Prescription updatedPrescription);
        void DeletePrescription(int prescriptionId);
        List<Prescription> GetPatientPrescriptions(int patientId);
    }
}
