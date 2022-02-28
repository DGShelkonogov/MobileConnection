using Microsoft.EntityFrameworkCore;
using MobileConnection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Call> Calls { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Corporate_Client> Corporate_Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Private_Client> Private_Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Type_Of_Calls_And_Messages> Type_Of_Calls_And_Messages { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MobileConnection;Username=postgres;Password=123");
        }
    }
}
