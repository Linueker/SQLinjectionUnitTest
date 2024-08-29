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
            User user = new User();
            string userName = txtUser.Text; 
            string pass = txtPass.Text;
            isLoggedIn = user.Inloggning(userName, pass);
            if (isLoggedIn)
            {
                lblStatus.Text = "Du är inloggad";
            }
            else
            {
                lblStatus.Text = "Du är utloggad";
                txtUser.Text = "";
                txtPass.Text = "";
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
