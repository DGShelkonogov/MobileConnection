using Microsoft.EntityFrameworkCore;
using MobileConnection.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Annotation = System.ComponentModel.DataAnnotations;


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
        public DbSet<Type_Of_Call_And_Message> Type_Of_Calls_And_Messages { get; set; }
        public DbSet<ClientCall> ClientCalls { get; set; }
        public DbSet<ClientMessage> ClientMessages { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MobileConnection;Username=postgres;Password=123");
        }


        public static bool validData(Object args)
        {
            var results = new List<Annotation.ValidationResult>();
            var context = new ValidationContext(args);
            if (!Validator.TryValidateObject(args, context, results, true))
            {
                string message = "";
                foreach (var error in results)
                {
                    message += error.ErrorMessage + '\n';
                }
                MessageBox.Show(message);
                return false;
            }
            return true;
        }

        public static bool checkEmail(string email)
        {
            ApplicationContext db = DBConnection.getConnection();
            var client = db.Clients.FirstOrDefault(x => x.Client_Email.Equals(email));
            var employee = db.Employees.FirstOrDefault(x => x.Employee_Email.Equals(email));
            if (client != null) return false;
            if (employee != null) return false;
            return true;
        }
    }
}
