using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Message : INotifyPropertyChanged
    {
        [Key]
        public int ID_Message { get; set; }

        [Required]
        public DateOnly Message_Date { get; set; }

        [Required]
        public TimeOnly Sending_Time { get; set; }

        [Required]
        [StringLength(11)]
        public string Subscriber_Number { get; set; }

        public Type_Of_Calls_And_Messages Type { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
