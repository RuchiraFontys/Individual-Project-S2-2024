using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class PatientDAL
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536154_uhms;User Id=dbi536154_uhms;Password=individualUHMS;";

        public int CreatePatient(Patient patient)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                // Start a transaction
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // SQL to insert basic patient info and get the new UserId
                        string insertPatientSql = @"
                    INSERT INTO Patients (UserId /*, other patient-related columns */)
                    VALUES (@UserId /*, other patient-related values */);
                    SELECT CAST(SCOPE_IDENTITY() AS int);"; // This line gets the new ID for the patient

                        using (var command = new SqlCommand(insertPatientSql, connection, transaction))
                        {
                            // Id is the ID from the Users table, and it's already set
                            command.Parameters.AddWithValue("@UserId", patient.Id); // UserId from Users table

                            // Add parameters related to patient information here
                            // Example: command.Parameters.AddWithValue("@SomeColumn", patientProperty);

                            // Execute the command and get the new PatientId
                            var result = command.ExecuteScalar();
                            if (result is int newPatientId)
                            {
                                patient.Id = newPatientId; // Set the patient's ID with the new ID from the database
                            }
                            else
                            {
                                throw new Exception("Patient creation failed. The operation did not return a valid ID.");
                            }
                        }

                        // SQL to insert a new medical record for the patient
                        string insertMedicalRecordSql = @"
                    INSERT INTO MedicalRecords (PatientId, DateCreated /*, other medical record columns */)
                    VALUES (@PatientId, GETDATE() /*, other medical record values */);";

                        using (var command = new SqlCommand(insertMedicalRecordSql, connection, transaction))
                        {
                            // Use the newly created PatientId for the medical record
                            command.Parameters.AddWithValue("@PatientId", patient.Id);

                            // Execute the command to insert the medical record
                            command.ExecuteNonQuery();
                        }

                        // Commit the transaction
                        transaction.Commit();
                        return patient.Id; // Return the new PatientId
                    }
                    catch
                    {
                        // Rollback the transaction if any error occurs
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
