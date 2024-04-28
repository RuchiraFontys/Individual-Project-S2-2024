using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPatient
    {
        void RegisterPatient(Patient patient);
        MedicalRecord ViewMedicalRecord(int patientId);
        void BookAppointment(Appointment appointment);
        void AddAllergy(int patientId, Allergy allergy);
        void RemoveAllergy(int patientId, Allergy allergy);
        void DeletePatient(int patientId);
    }
}
