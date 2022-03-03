using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Type_Of_Call_And_Message : INotifyPropertyChanged
    {

        public Type_Of_Call_And_Message()
        {

        }

        public Type_Of_Call_And_Message(Type_Of_Call_And_Message Type_Of_Call_And_Message)
        {
            Type_Name = Type_Of_Call_And_Message.Type_Name;
        }

        [Key]
        public int ID_Type_Of_Call_And_Message { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Длинна типа не должна привышать 40 символов")]
        public string Type_Name { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
