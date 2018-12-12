using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "";
            if (Convert.ToInt32(comboBox1.SelectedIndex) == 0)
            {
                query = "SELECT * FROM tbl_login WHERE username = '" + txtUsername.Text.Trim() + "' AND password = '" + txtPassword.Text.Trim() + "'";
            }
            if (Convert.ToInt32(comboBox1.SelectedIndex) == 1)
            {
                query = "SELECT * FROM moderators WHERE username = '" + txtUsername.Text.Trim() + "' AND password = '" + txtPassword.Text.Trim() + "'";
            }
            if (Convert.ToInt32(comboBox1.SelectedIndex) == 2)
            {
                query = "SELECT * FROM admin WHERE username = '" + txtUsername.Text.Trim() + "' AND password = '" + txtPassword.Text.Trim() + "'";
            }


            SqlConnection sqlcon = new SqlConnection(@"Data Source=riasdb.database.windows.net;Initial Catalog=Rias;User ID=admin123;Password=Test123!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                if (Convert.ToInt32(comboBox1.SelectedIndex) == 0)
                    new frmMain().Show();
                if (Convert.ToInt32(comboBox1.SelectedIndex) == 1)
                    new frmMain().Show();
                if (Convert.ToInt32(comboBox1.SelectedIndex) == 2)
                    new frmMain().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Check your username and password");
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
