using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AdministratorDAL
    {
        
        public void CreateAdministrator(Administrator administrator)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                // SQL command to insert doctor record
                // Execute the command
            }
        }

        public Administrator? GetAdministratorById(int administratorId)
        {
            // retrieve an administrator by their ID
            return null;
        }

        public void UpdateAdministrator(Administrator administrator)
        {
            // update an existing administrator's details
        }

        public void DeleteAdministrator(int administratorId)
        {
            // delete an administrator by their ID
        }
    }
}
