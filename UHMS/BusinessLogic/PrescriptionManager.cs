using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer;

namespace BusinessLogic
{
    public class PrescriptionManager
    {
        public void CreatePrescription(Prescription prescription)
        {
            // prescription creation logic
        }

        public Prescription GetPrescription(int prescriptionId)
        {
            // logic to retrieve a prescription
            return null;
        }

        public void UpdatePrescription(int prescriptionId, Prescription updatedPrescription)
        {
            // prescription update logic
        }

        public void DeletePrescription(int prescriptionId)
        {
            // prescription deletion logic
        }

        public List<Prescription> GetPatientPrescriptions(int patientId)
        {
            // logic to retrieve all prescriptions for a patient
            return new List<Prescription>();
        }
    }

}
