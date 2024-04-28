using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class MedicationDAL
    {
        public void CreateMedication(Medication medication)
        {
            // add a new medication to the database
        }

        public Medication GetMedicationById(int medicationId)
        {
            // retrieve a medication by its ID
            return null; // placeholder return
        }

        public void UpdateMedication(Medication medication)
        {
            // update an existing medication
        }

        public void DeleteMedication(int medicationId)
        {
            // delete a medication by its ID
        }

        public List<Medication> GetAllMedications()
        {
            // retrieve all medications
            return new List<Medication>(); // placeholder return
        }
    }
}
