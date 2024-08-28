using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InjectionInloggning
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public static bool Inloggning(string user, string pass)
        {
            //Hämta data från textfält
            //string user = txtUser.Text;
            //string pass = txtPass.Text;
            if(user.Contains("\"") || user.Contains("'"))
            {
                return false; 
            }

            using (InjectionDBContext dbContext = new InjectionDBContext())
            {
                User currentUser = dbContext.Users.Where(u => u.UserName == user).FirstOrDefault();

                if (currentUser != null)
                {
                    if (pass == currentUser.Password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //MessageBox.Show("Det finns ingen användare med det namnet!");
                    return false;
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
    }
}
