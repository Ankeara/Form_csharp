using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using static System.Net.WebRequestMethods;

namespace FoodSystem.Controller
{
    internal class ControllerUserStaff : Model.ModelUserStaff
    {
        public DataTable dtu = new DataTable();
        public DataSet dsu = new DataSet();
        public void Select_Staff()
        {
            string sql = "SELECT * FROM V_STAFFINFO";
            OracleDataAdapter datu = new OracleDataAdapter(sql, conn);
            dsu.Clear();
            datu.Fill(dsu, "staffname");
            dtu = dsu.Tables["staffname"];
        }

        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public OracleDataAdapter adapter = new OracleDataAdapter();
        public void show_v_user()
        {
            string sql = "SELECT * FROM V_USERWITHSTAFF";
            OracleCommand cmd = new OracleCommand(sql, conn);
            adapter.SelectCommand = cmd;
            ds.Clear();
            adapter.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Insert_userstaff()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "InsertUserStaff";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpStaffId", OracleDbType.Int16).Value = staffid;
            cmd.Parameters.Add("SpPass", OracleDbType.Varchar2).Value = password;
            cmd.Parameters.Add("SpUsertype", OracleDbType.Varchar2).Value = usertype;
            cmd.Parameters.Add("SpPosition", OracleDbType.Varchar2).Value = position;
            cmd.ExecuteNonQuery();
        }

        public void Update_userstaff()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpdateUserStaff";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpUserId", OracleDbType.Int16).Value = userid;
            cmd.Parameters.Add("SpStaffid", OracleDbType.Int16).Value = staffid;
            cmd.Parameters.Add("SpPass", OracleDbType.Varchar2).Value = password;
            cmd.Parameters.Add("SpUsertype", OracleDbType.Varchar2).Value = usertype;
            cmd.Parameters.Add("SpPosition", OracleDbType.Varchar2).Value = position;
            cmd.ExecuteNonQuery();
        }
        public void Delete_userstaff()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DeleteUserStaff";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpUserId", OracleDbType.Int16).Value = userid;
            cmd.ExecuteNonQuery();
        }
    }
}
