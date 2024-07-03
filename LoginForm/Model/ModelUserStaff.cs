using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace FoodSystem.Model
{
    internal class ModelUserStaff : Connection
    {
        public int userid { get; set; }
        public int staffid { get; set; }
        public string usertype { get; set; }
        public string password { get; set; }
        public string position { get; set; }
    }
}
