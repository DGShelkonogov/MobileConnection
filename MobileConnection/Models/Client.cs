using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Client : INotifyPropertyChanged
    {

        public Client()
        {

        }

        public Client(Client client)
        {
            Account_Number = client.Account_Number;
            Contract_Number = client.Contract_Number;
            Contract_Conclusion_Date = client.Contract_Conclusion_Date;
            Client_Email = client.Client_Email;
            Client_Password = client.Client_Password;
            Phone_Number = client.Phone_Number;
            Tariff_Cost = client.Tariff_Cost;
        }


        [Key]
        public int ID_Client { get; set; }

        [Required]
        [StringLength(20)]
        public string Account_Number { get; set; }

        [Required]
        public int Contract_Number { get; set; }

        [Required]
        public DateOnly Contract_Conclusion_Date { get; set; }
  
        [StringLength(50)]
        public string Client_Email { get; set; }

        [Required]
        [StringLength(25)]
        public string Client_Password { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone_Number { get; set; }

        [Required]
        public decimal Tariff_Cost { get; set; }

        public virtual ICollection<Service> Services { get; set; } = new List<Service>();

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
