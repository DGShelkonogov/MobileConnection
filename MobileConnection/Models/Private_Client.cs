using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Private_Client : INotifyPropertyChanged
    {
        public Private_Client()
        {

        }

        public Private_Client(Private_Client Private_Client)
        {
            Client_Surname = Private_Client.Client_Surname;
            Client_Name = Private_Client.Client_Name;
            Client_Patronymic = Private_Client.Client_Patronymic;
            Date_Of_Birth = Private_Client.Date_Of_Birth;
            Passport_Series = Private_Client.Passport_Series;
            Passport_Number = Private_Client.Passport_Number;
            Adsress = Private_Client.Adsress;
            Client = Private_Client.Client;
        }


        [Key]
        public int ID_Private_Client { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Длинна фамилии не должна привышать 25 символов")]
        public string Client_Surname { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Длинна имени не должна привышать 25 символов")]
        public string Client_Name { get; set; }

        [StringLength(25, ErrorMessage = "Длинна отчества не должна привышать 25 символов")]
        public string Client_Patronymic { get; set; }

        [Required]
        public DateOnly Date_Of_Birth { get; set; }

        [Required]
        public int Passport_Series { get; set; }

        [Required]
        public int Passport_Number { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "Длинна  адреса не должна привышать 70 символов")]
        public string Adsress { get; set; }

        [Required]
        public Client Client { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
