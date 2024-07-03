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

namespace FoodSystem.View
{
    public partial class MainForm : Form
    {
        private Timer timer;
        public MainForm()
        {
            InitializeComponent();

            // Initialize and start the timer
            timer1 = new Timer();
            timer1.Interval = 1000; // 1 minute interval
            timer1.Tick += Timer_Tick;
            timer1.Start();

            // Set the initial time on the label
            UpdateCambodiaTime();
            lblUserModel.Text = UserDetail.Username;



        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Addcontroll(new FrmHome());
            btnHome.Checked = true;

            if(UserDetail.Type == "Manager")
            {
                btnUserInfo.Enabled = false;
            }
            else if (UserDetail.Type == "Sale")
            {
                btnUserInfo.Enabled = false;
                btnTable.Enabled = false;
                btnStaffPosi.Enabled = false;
                btnStaffInfor.Enabled = false;
                btnFoodCate.Enabled = false;
                btnFoodMenu.Enabled = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the time on the label every minute
            UpdateCambodiaTime();
        }

        private void UpdateCambodiaTime()
        {
            // Get the Cambodia time zone
            TimeZoneInfo cambodiaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Convert the current UTC time to Cambodia time
            DateTime cambodiaTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cambodiaTimeZone);

            // Display the Cambodia time on the label
            lblDateTime.Text = cambodiaTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Addcontroll(Form F)
        {
            pnlShow.Controls.Clear();
            F.Dock = DockStyle.Fill;
            F.TopLevel = false;
            pnlShow.Controls.Add( F );
            F.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Addcontroll(new FrmHome());
            sidePanel.Height = btnHome.Height;
            sidePanel.Top = btnHome.Top;
        }
        private void btnOrder_Click_1(object sender, EventArgs e)
        {
            sidePanel.Height = btnOrder.Height;
            sidePanel.Top = btnOrder.Top;
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnPayment.Height;
            sidePanel.Top = btnPayment.Top;
        }

        private void btnFoodMenu_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnFoodMenu.Height;
            sidePanel.Top = btnFoodMenu.Top;
            Addcontroll(new FrmFoodList());

        }

        private void btnFoodCate_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnFoodCate.Height;
            sidePanel.Top = btnFoodCate.Top;
            Addcontroll(new FrmCategory());

        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnTable.Height;
            sidePanel.Top = btnTable.Top;
        }

        private void btnStaffPosi_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnStaffPosi.Height;
            sidePanel.Top = btnStaffPosi.Top;
            Addcontroll(new FrmPosition());
        }

        private void btnStaffInfor_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnStaffInfor.Height;
            sidePanel.Top = btnStaffInfor.Top;
            Addcontroll(new FrmStaffInfo());
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            Addcontroll(new FrmUserStaff());
            sidePanel.Height = btnUserInfo.Height;
            sidePanel.Top = btnUserInfo.Top;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

    }
}
