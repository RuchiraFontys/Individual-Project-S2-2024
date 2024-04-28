using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer;

namespace BusinessLogic
{
    public class PatientManager
    {
        private readonly PatientDAL _patientDAL; // Corrected field type

        public PatientManager(PatientDAL patientDAL) // Corrected parameter type
        {
            _patientDAL = patientDAL; // Corrected field assignment
        }

        public void AddPatient(Patient patient)
        {
            // Implement the logic to add a patient record, possibly involving PatientDAL
            _patientDAL.CreatePatient(patient);
        }

        public MedicalRecord? ViewMedicalRecord(int patientId)
        {
            // view medical record logic
            return null;
        }

        public void BookAppointment(Appointment appointment)
        {
            // logic
        }

        public void AddAllergy(int patientId, Allergy allergy)
        {
            // logic
        }

        public void RemoveAllergy(int patientId, Allergy allergy)
        {
            // logic
        }
    }
}
