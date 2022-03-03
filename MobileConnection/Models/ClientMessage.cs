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

        public ClientMessage()
        {

        }
        
        public ClientMessage(ClientMessage ClientMessage)
        {
            Client = new Client
            {
                Phone_Number = ClientMessage.Client.Phone_Number
            };
            Message = new Message
            {
                Subscriber_Number = ClientMessage.Message.Subscriber_Number
            };
        }

        [Key]
        public int ID_ClientMessage { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        public Message Message { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
