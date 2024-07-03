using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace FoodSystem.Controller
{
    internal class ControllerStaffinfo : Model.ModelStaffInfo
    {
        public DataTable dtp = new DataTable();
        public DataSet dsp = new DataSet();
        public void view_data_position()
        {
            string sql = "SELECT * FROM tblposition";
            OracleDataAdapter datp = new OracleDataAdapter(sql, conn);
            datp.Fill(dsp, "position");
            dtp = dsp.Tables["position"];
        }

        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public OracleDataAdapter adapter = new OracleDataAdapter();
        public void load_data_to_dg()
        {
            string sql = "SELECT * FROM V_staffinfo";
            OracleCommand cmd = new OracleCommand(sql, conn);
            adapter.SelectCommand = cmd;
            ds.Clear();
            adapter.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Insert_staff()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "InsertStaff";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpStaffname", OracleDbType.Varchar2).Value = Staffname;
            cmd.Parameters.Add("SpGender", OracleDbType.Varchar2).Value = Gender;
            cmd.Parameters.Add("SpDOB", OracleDbType.Date).Value = dob;
            cmd.Parameters.Add("SpAddress", OracleDbType.Varchar2).Value = Address;
            cmd.Parameters.Add("SpPhonenumber", OracleDbType.Varchar2).Value = Phonenumber;
            cmd.Parameters.Add("SpPosition", OracleDbType.Int16).Value = Positionid;
            cmd.Parameters.Add("SpUsernote", OracleDbType.Varchar2).Value = Usernote;
            cmd.Parameters.Add("SpPhoto", OracleDbType.Blob).Value = Photo;
            cmd.ExecuteNonQuery();
        }

        public void Update_staff()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpdateStaff";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpStaffID", OracleDbType.Int32).Value = StaffID;
            cmd.Parameters.Add("SpStaffname", OracleDbType.Varchar2).Value = Staffname;
            cmd.Parameters.Add("SpGender", OracleDbType.Varchar2).Value = Gender;
            cmd.Parameters.Add("SpDOB", OracleDbType.Date).Value = dob;
            cmd.Parameters.Add("SpAddress", OracleDbType.Varchar2).Value = Address;
            cmd.Parameters.Add("SpPhonenumber", OracleDbType.Varchar2).Value = Phonenumber;
            cmd.Parameters.Add("SpPositionID", OracleDbType.Int32).Value = Positionid; // Corrected parameter name
            cmd.Parameters.Add("spuserupdatenote", OracleDbType.Varchar2).Value = UserUpdateNote; // Corrected parameter name
            cmd.Parameters.Add("SpPhoto", OracleDbType.Blob).Value = Photo;
            cmd.ExecuteNonQuery();

        }

        public void Delete_staff()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DeleteStaff";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpStaffId", OracleDbType.Int16).Value = StaffID;
            cmd.ExecuteNonQuery();
        }
    }
}
