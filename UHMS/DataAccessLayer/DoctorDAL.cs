using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class DoctorDAL
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536154_uhms;User Id=dbi536154_uhms;Password=individualUHMS;";

        public void CreateDoctor(Doctor doctor)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                // SQL command to insert administrator record
                // Execute the command
            }
        }

        public Doctor? GetDoctorById(int doctorId)
        {
            // retrieve a doctor by their ID
            return null;
        }

        public void UpdateDoctor(Doctor doctor)
        {
            // update an existing doctor's details
        }

        public void DeleteDoctor(int doctorId)
        {
            // delete a doctor by their ID
        }
    }
}
