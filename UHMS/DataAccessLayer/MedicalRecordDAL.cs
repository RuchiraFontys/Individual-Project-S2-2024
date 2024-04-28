using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class MedicalRecordDAL
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536154_uhms;User Id=dbi536154_uhms;Password=individualUHMS;";

        public void AddMedicalRecord(MedicalRecord record)
        {
            // Check if Patient is not null before trying to access its Id property
            if (record.Patient == null)
            {
                throw new InvalidOperationException("Cannot add a medical record without an associated patient.");
            }
            var query = @"
        INSERT INTO MedicalRecords (PatientId, DateCreated, VisitDate, VisitType, Symptoms, Diagnosis, MedicationNote, Note)
        VALUES (@PatientId, @DateCreated, @VisitDate, @VisitType, @Symptoms, @Diagnosis, @MedicationNote, @Note)";

            using (var connection = DBHelper.OpenConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PatientId", record.Patient!.Id); // Safe to access Id here as we've checked Patient is not null
                command.Parameters.AddWithValue("@DateCreated", record.DateCreated);
                command.Parameters.AddWithValue("@VisitDate", record.VisitDate);
                command.Parameters.AddWithValue("@VisitTypeId", (int)record.VisitType);
                command.Parameters.AddWithValue("@Symptoms", record.Symptoms ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Diagnosis", record.Diagnosis ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@MedicationNote", record.MedicationNote ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Note", record.Note ?? (object)DBNull.Value);

                command.ExecuteNonQuery();
            }
        }

        public MedicalRecord? GetMedicalRecordById(int recordId)
        {
            MedicalRecord? record = null;
            var query = "SELECT * FROM MedicalRecords WHERE RecordId = @RecordId";

            using (var connection = DBHelper.OpenConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RecordId", recordId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        record = new MedicalRecord
                        {
                            RecordId = reader.GetInt32(reader.GetOrdinal("RecordId")),
                            DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated")),
                            VisitDate = reader.GetDateTime(reader.GetOrdinal("VisitDate")),
                            VisitType = (VisitType)reader.GetInt32(reader.GetOrdinal("VisitTypeId")),
                            Symptoms = reader.IsDBNull(reader.GetOrdinal("Symptoms")) ? null : reader.GetString(reader.GetOrdinal("Symptoms")),
                            Diagnosis = reader.IsDBNull(reader.GetOrdinal("Diagnosis")) ? null : reader.GetString(reader.GetOrdinal("Diagnosis")),
                            MedicationNote = reader.IsDBNull(reader.GetOrdinal("MedicationNote")) ? null : reader.GetString(reader.GetOrdinal("MedicationNote")),
                            Note = reader.IsDBNull(reader.GetOrdinal("Note")) ? null : reader.GetString(reader.GetOrdinal("Note")),
                            Patient = new Patient { Id = reader.GetInt32(reader.GetOrdinal("PatientId")) },
                            Medications = new List<Medication>() // Placeholder, will be populated below
                        };
                    }
                }

                // Now populate the Medications property if a record was found
                if (record != null)
                {
                    record.Medications = GetMedicationsForRecord(record.Patient.Id, connection);
                }
            }

            return record;
        }

        private List<Medication> GetMedicationsForRecord(int patientId, SqlConnection connection)
        {
            var medications = new List<Medication>();
            var prescriptionQuery = @"
        SELECT PrescriptionId 
        FROM Prescriptions 
        WHERE PatientId = @PatientId";

            // Get all PrescriptionIds for this patient
            using (var prescriptionCommand = new SqlCommand(prescriptionQuery, connection))
            {
                prescriptionCommand.Parameters.AddWithValue("@PatientId", patientId);
                using (var reader = prescriptionCommand.ExecuteReader())
                {
                    var prescriptionIds = new List<int>();
                    while (reader.Read())
                    {
                        prescriptionIds.Add(reader.GetInt32(0));
                    }

                    // Return early if there are no prescriptions
                    if (prescriptionIds.Count == 0)
                    {
                        return medications;
                    }

                    // Now fetch the medications for all prescriptions
                    var medicationsQuery = @"
                SELECT Med.* 
                FROM Medications Med
                INNER JOIN PrescriptionMedications PM ON Med.MedicationId = PM.MedicationId
                WHERE PM.PrescriptionId IN ({0})";

                    var parameterNames = new List<string>();
                    for (int i = 0; i < prescriptionIds.Count; i++)
                    {
                        parameterNames.Add($"@PrescriptionId{i}");
                        prescriptionCommand.Parameters.AddWithValue($"@PrescriptionId{i}", prescriptionIds[i]);
                    }
                    medicationsQuery = string.Format(medicationsQuery, string.Join(", ", parameterNames));

                    using (var medicationsCommand = new SqlCommand(medicationsQuery, connection))
                    {
                        using (var medicationsReader = medicationsCommand.ExecuteReader())
                        {
                            while (medicationsReader.Read())
                            {
                                var medication = new Medication
                                {
                                    // Populate properties of Medication from reader
                                };
                                medications.Add(medication);
                            }
                        }
                    }
                }
            }

            return medications;
        }

        public void UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            // update an existing medical record
        }

        public void DeleteMedicalRecord(int recordId)
        {
            // delete a medical record by its ID
        }

        public List<MedicalRecord> GetMedicalRecordsByPatientId(int patientId)
        {
            // retrieve all medical records for a given patient
            return new List<MedicalRecord>();
        }
    }
}
