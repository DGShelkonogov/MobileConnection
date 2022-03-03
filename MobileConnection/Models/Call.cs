using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Call : INotifyPropertyChanged
    {
        public Call()
        {

        }

        public Call(Call call)
        {
            Call_Date = call.Call_Date;
            Call_Start_Time = call.Call_Start_Time;
            Duration = call.Duration;
            Subscriber_Called_Number = call.Subscriber_Called_Number;
            Type = new Type_Of_Call_And_Message
            {
                Type_Name = call.Type.Type_Name
            };
        }

        [Key]
        public int ID_Call { get; set; }


        [Required(ErrorMessage = "дата звонка не заполнена")]
        public DateOnly Call_Date { get; set; }

        [Required(ErrorMessage = "время начала звонка не заполнено")]
        public TimeOnly Call_Start_Time { get; set; }

        [Required(ErrorMessage = "Длительность звонка не заполнена")]
        public string Duration { get; set; }

        [Required(ErrorMessage = "Номер вызываемого абонента не заполнен")]
        [StringLength(11, ErrorMessage = "Длинна должна быть меньше или равна 11 символов")]
        public string Subscriber_Called_Number { get; set; }

        [Required(ErrorMessage = "тип звонка не заполнен")]
        public Type_Of_Call_And_Message Type { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
