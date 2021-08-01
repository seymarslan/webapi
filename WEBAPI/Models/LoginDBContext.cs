using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class LoginDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("data source=LAPTOP-E2KQ5PQ4;initial catalog=DbLogin; Integrated security=true;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
    }
}
