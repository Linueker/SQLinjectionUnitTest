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

        public bool Inloggning(string user, string pass)
        {
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
        }
    }
}
