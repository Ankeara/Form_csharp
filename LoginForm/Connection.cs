using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem
{
    internal class Connection
    {

        public OracleConnection conn;
        public Connection()
        {
            string sql = @"DATA SOURCE=localhost:1521/xe;User ID=CafeCraze;PASSWORD=CFC;";
            conn = new OracleConnection(sql);
            conn.Open();
        }
    }
}
