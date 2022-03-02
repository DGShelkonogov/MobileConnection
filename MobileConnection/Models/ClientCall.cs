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
    public class ClientCall : INotifyPropertyChanged
    {

        public ClientCall()
        {

        }

        public ClientCall(ClientCall ClientCall)
        {
            Client = new Client
            {
                Phone_Number = ClientCall.Client.Phone_Number
            };
            Call = new Call
            {
                Subscriber_Called_Number = ClientCall.Call.Subscriber_Called_Number,
            };
        }

        [Key]
        public int ID_ClientCall { get; set; }

        public Client Client { get; set; }

        public Call Call { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
