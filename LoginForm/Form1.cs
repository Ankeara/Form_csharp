using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace FoodSystem
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        Connection myconn = new Connection();

        private void Form1_Load(object sender, EventArgs e)
        {
            if(myconn.conn.State == ConnectionState.Open)
            {
                myconn.conn.Close();
                MessageBox.Show("success");
            }
        }
    }
}
