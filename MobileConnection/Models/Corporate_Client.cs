using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Corporate_Client : INotifyPropertyChanged
    {

        public Corporate_Client()
        {

        }

        public Corporate_Client(Corporate_Client Corporate_Client)
        {
            INN = Corporate_Client.INN;
            Company_Name = Corporate_Client.Company_Name;
            Legal_Adsress = Corporate_Client.Legal_Adsress;
            Physical_Adsress = Corporate_Client.Physical_Adsress;
            Personal_Account_Number = Corporate_Client.Personal_Account_Number;
            Client = new Client
            {
                Account_Number = Corporate_Client.Client.Account_Number
            };
        }



        [Key]
        public int ID_Corporate_Client { get; set; }

        [Required]
        [StringLength(10)]
        public string INN { get; set; }

        [Required] 
        [StringLength(40)]
        public string Company_Name { get; set; }

        [Required]
        [StringLength(70)]
        public string Legal_Adsress { get; set; }

        [Required]
        [StringLength(70)]
        public string Physical_Adsress { get; set; }

        [Required]
        [StringLength(70)]
        public string Personal_Account_Number { get; set; }

        [Required]
        public Client Client { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
