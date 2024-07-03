using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Controller
{
    internal class ControllerFoodList : Model.ModelFoodList
    {
        public DataTable dtc = new DataTable();
        public DataSet dsc = new DataSet();
        public void view_data_cate()
        {
            string sql = "SELECT * FROM tblcategory";
            OracleDataAdapter datp = new OracleDataAdapter(sql, conn);
            datp.Fill(dsc, "categoryname");
            dtc = dsc.Tables["categoryname"];
        }

        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public OracleDataAdapter adapter = new OracleDataAdapter();

        public void Select_data()
        {
            string sql = "select * from V_Foodlist";
            OracleCommand cmd = new OracleCommand();
            cmd = new OracleCommand(sql, conn);
            adapter.SelectCommand = cmd;
            ds.Clear();
            adapter.Fill(ds);
            dt = ds.Tables[0];
        }


        public void Insert_Foodlist()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "InsertFoodlist";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpFoodName", OracleDbType.Varchar2).Value = FoodName;
            cmd.Parameters.Add("SpCategoryid", OracleDbType.Int16).Value = FoodCategory;
            cmd.Parameters.Add("SpFoodName", OracleDbType.Double).Value = FoodPrice;
            cmd.Parameters.Add("SpFoodPhoto", OracleDbType.Blob).Value = FoodPhoto;
            cmd.Parameters.Add("SpUserNote", OracleDbType.Varchar2).Value = UserNote;
            cmd.ExecuteNonQuery();
        }

        public void Update_Foodlist()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpdateFoodlist";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpFoodlistId", OracleDbType.Int16).Value = FoodListID;
            cmd.Parameters.Add("SpFoodName", OracleDbType.Varchar2).Value = FoodName;
            cmd.Parameters.Add("SpCategoryid", OracleDbType.Int16).Value = FoodCategory;
            cmd.Parameters.Add("SpFoodName", OracleDbType.Double).Value = FoodPrice;
            cmd.Parameters.Add("SpFoodPhoto", OracleDbType.Blob).Value = FoodPhoto;
            cmd.Parameters.Add("SpUserUpdateNote", OracleDbType.Varchar2).Value = UserUpdateNote;
            cmd.ExecuteNonQuery();
        }

        public void Delete_Foodlist()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DeleteFoodlist";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SpFoodlistId", OracleDbType.Int16).Value = FoodListID;
            cmd.ExecuteNonQuery();
        }
    }
}
