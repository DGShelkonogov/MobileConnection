using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class ClientMessage : INotifyPropertyChanged
    {

        [Key]
        public int ID_ClientMessage { get; set; }

        public Client Client { get; set; }

        public Message Message { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
