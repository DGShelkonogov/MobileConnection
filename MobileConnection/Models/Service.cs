using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{

    public class Service : INotifyPropertyChanged
    {

        public Service()
        {

        }

        public Service(Service Service)
        {
            Service_Name = Service.Service_Name;
            Service_Status = Service.Service_Status;
            Cost = Service.Cost;
            Employee = new Employee
            {
                Employee_Name = Service.Employee.Employee_Name
            };
        }



        [Key]
        public int ID_Service { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Длинна наименования не должна привышать 25 символов")]
        public string Service_Name { get; set; }

        public bool Service_Status { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public Employee Employee { get; set; }

        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
