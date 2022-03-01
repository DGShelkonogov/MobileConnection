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
        [Key]
        public int ID_Service { get; set; }

        [Required]
        [StringLength(25)]
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
