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
        [StringLength(10, ErrorMessage = "Длинна ИНН не должна привышать 10 символов")]
        public string INN { get; set; }

        [Required] 
        [StringLength(40, ErrorMessage = "Длинна наименования компании не должна привышать 40 символов")]
        public string Company_Name { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "Длинна юридического адреса не должна привышать 70 символов")]
        public string Legal_Adsress { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "Длинна фактического адреса не должна привышать 70 символов")]
        public string Physical_Adsress { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "Длинна номера лицевого счета не должна привышать 70 символов")]
        public string Personal_Account_Number { get; set; }

        [Required]
        public Client Client { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
