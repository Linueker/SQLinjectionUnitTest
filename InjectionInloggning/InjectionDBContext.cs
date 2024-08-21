using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionInloggning
{
    public class InjectionDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-ONS01784; Initial Catalog=SQLinjection; Integrated Security=True;Connect Timeout=30;Encrypt=False");
        }
    }
}
