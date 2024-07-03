using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodSystem.View
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        Connection myconn = new Connection();
        int i;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Empty user or password", "Empty your input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "select * from V_userwithstaff where staffname = '" + txtusername.Text + "' AND password = '" + txtpassword.Text + "'";
                OracleCommand cmd = myconn.conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt16(dt.Rows.Count.ToString());
                if (dt.Rows.Count > 0)
                {
                    UserDetail.Username = dt.Rows[0]["staffname"].ToString();
                    UserDetail.Type = dt.Rows[0]["usertype"].ToString();
                    this.Hide();
                    View.MainForm frmmainform = new View.MainForm();
                    frmmainform.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid user or password", "Invalid your login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void picLock_Click(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '\0')
            {
                txtpassword.PasswordChar = '*';
                picLock.Image = Properties.Resources.padlock;
            }
            else
            {
                txtpassword.PasswordChar = '\0';
                picLock.Image = Properties.Resources.unlock;
            }
        }
    }
}
