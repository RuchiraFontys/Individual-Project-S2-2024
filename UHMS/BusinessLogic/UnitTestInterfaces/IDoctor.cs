using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IDoctor
    {
        void RegisterDoctor(Doctor doctor);
        void UpdateMedicalRecord(int patientId, int recordId, MedicalRecord updatedRecord);
        void DeleteDoctor(int doctorId);
    }
}
