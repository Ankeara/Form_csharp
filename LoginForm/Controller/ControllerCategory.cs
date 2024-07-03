using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Controller
{
    internal class ControllerCategory : Model.ModelCategory
    {
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public OracleDataAdapter adapter = new OracleDataAdapter();

        public void Select_data()
        {
            string sql = "select * from tblcategory";
            OracleCommand cmd = new OracleCommand();
            cmd = new OracleCommand(sql, conn);
            adapter.SelectCommand = cmd;
            ds.Clear();
            adapter.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Insert_data()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "InsertCategory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpCategory", OracleDbType.Varchar2).Value = Categoryname;
            cmd.ExecuteNonQuery();
        }

        public void Update_data()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpdateCategory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpCateId", OracleDbType.Int16).Value = CateId;
            cmd.Parameters.Add("SpCategory", OracleDbType.Varchar2).Value = Categoryname;
            cmd.ExecuteNonQuery();
        }

        public void Delete_data()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DeleteCategory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpCateId", OracleDbType.Int16).Value = CateId;
            cmd.ExecuteNonQuery();
        }
    }
}
