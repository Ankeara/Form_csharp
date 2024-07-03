using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FoodSystem.Controller
{
    internal class ControllerPosition : Model.ModelPosition
    {
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public OracleDataAdapter adapter = new OracleDataAdapter();

        public void Select_data()
        {
            string sql = "select * from tblposition";
            OracleCommand cmd = new OracleCommand();
            cmd = new OracleCommand(sql,conn);
            adapter.SelectCommand= cmd;
            ds.Clear();
            adapter.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Insert_data()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection= conn;
            cmd.CommandText = "InsertPosition";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpPositionName", OracleDbType.Varchar2).Value = PositionName;
            cmd.ExecuteNonQuery();
        }

        public void Update_data()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpdatePosition";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpPositionID", OracleDbType.Int16).Value = PositionID;
            cmd.Parameters.Add("SpPositionName", OracleDbType.Varchar2).Value = PositionName;
            cmd.ExecuteNonQuery();
        }

        public void Delete_data()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DeletePosition";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpPositionID", OracleDbType.Int16).Value = PositionID;
            cmd.ExecuteNonQuery();
        }
    }
}
