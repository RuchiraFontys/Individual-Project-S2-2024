using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DBHelper
    {
        private static readonly string _connectionString = "Server=mssqlstud.fhict.local;Database=dbi536154_uhms;User Id=dbi536154_uhms;Password=individualUHMS;TrustServerCertificate=True";

        public static SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}