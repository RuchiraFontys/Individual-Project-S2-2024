using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMedicalRecord
    {
        void CreateMedicalRecord(MedicalRecord medicalRecord);
        MedicalRecord GetMedicalRecord(int recordId);
        void UpdateMedicalRecord(int recordId, MedicalRecord updatedRecord);
        void DeleteMedicalRecord(int recordId);
        List<MedicalRecord> GetPatientMedicalRecords(int patientId);
    }
}
