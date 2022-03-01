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
        [Key]
        public int ID_Private_Client { get; set; }

        [Required]
        [StringLength(25)]
        public string Client_Surname { get; set; }

        [Required]
        [StringLength(25)]
        public string Client_Name { get; set; }

        [StringLength(25)]
        public string Client_Patronymic { get; set; }

        [Required]
        public DateOnly Date_Of_Birth { get; set; }

        [Required]
        public int Passport_Series { get; set; }

        [Required]
        public int Passport_Number { get; set; }

        [Required]
        [StringLength(70)]
        public string Adsress { get; set; }

        [Required]
        public Client Client { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
