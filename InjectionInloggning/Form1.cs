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
        public Form1()
        {
            InitializeComponent();
        }

        private void Inloggning()
        {
            
            //Hämta data från textfält
            string user = txtUser.Text;
            string pass = txtPass.Text;

            using (InjectionDBContext dbContext = new InjectionDBContext())
            {
                User currentUser = dbContext.Users.Where(u => u.UserName == user).FirstOrDefault();

                if (currentUser != null)
                {
                    if (pass == currentUser.Password)
                    {
                        lblStatus.Text = "Du har loggat in";
                    }
                    else
                    {
                        lblStatus.Text = "Du är utloggad";
                    }
                }
                else
                {
                    MessageBox.Show("Det finns ingen användare med det namnet!");
                }

                
                
            }

            

            //if (!user.Contains("\"") && !user.Contains("'"))
            //{
            //    //Bygger upp SQL querry
            //    string sqlQuerry = $"SELECT * FROM users WHERE users_username = '{user}' AND users_password = '{pass}';";

            //    lblQuerry.Text = sqlQuerry;

            //    MySqlCommand cmd = new MySqlCommand(sqlQuerry, conn);

            //    //Exekverar querry
            //    try
            //    {
            //        conn.Open();

            //        MySqlDataReader reader = cmd.ExecuteReader();

            //        //Kontrollerar resultatet
            //        if (reader.Read())
            //            lblStatus.Text = "Du har loggat in";
            //        else
            //            lblStatus.Text = "Du är utloggad";
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show(e.Message);
            //    }
            //    finally
            //    {
            //        conn.Close();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(@"Användarnamnet får inte innehålla "" eller '");
            //}

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inloggning();
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
