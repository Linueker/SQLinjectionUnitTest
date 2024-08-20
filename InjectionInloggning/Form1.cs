using MySql.Data.MySqlClient;
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
            string server = "localhost";
            string database = "sqlinkectexample";

            string dbUser = "root";
            string dbPass = "SokrateS13";

            string connString = $"SERVER={server};DATABASE={database};UID={dbUser};PASSWORD={dbPass};";

            MySqlConnection conn = new MySqlConnection(connString);

            //Hämta data från textfält
            string user = txtUser.Text;
            string pass = txtPass.Text;

            //Bygger upp SQL querry
            string sqlQuerry = $"SELECT * FROM users WHERE users_username = '{user}' AND users_password = '{pass}';";

            lblQuerry.Text = sqlQuerry;

            MySqlCommand cmd = new MySqlCommand(sqlQuerry, conn);

            //Exekverar querry
            try
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                //Kontrollerar resultatet
                if (reader.Read())
                    lblStatus.Text = "Du har loggat in";
                else
                    lblStatus.Text = "Du är utloggad";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } finally
            {
                conn.Close();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inloggning();
        }
    }
}
