//using MySql.Data.MySqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InjectionInloggning
{
    public partial class Form1 : Form
    {
        private bool isLoggedIn;
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text; 
            string pass = txtPass.Text;
            isLoggedIn = User.Inloggning(user, pass);
            if (isLoggedIn)
            {
                lblStatus.Text = "Du är inloggad";
            }
            else
            {
                lblStatus.Text = "Du är utloggad";
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (txtUser.Text.Contains("\"") || txtUser.Text.Contains("'"))
            {
                MessageBox.Show(@"Användarnamnet får inte innehålla "" eller '");
                txtUser.Text = "";
            }
        }
    }
}
