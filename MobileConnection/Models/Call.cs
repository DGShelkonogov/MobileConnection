using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Call
    {

        [Key]
        public int ID_Call { get; set; }

        [Required]
        public DateOnly Call_Date { get; set; }

        [Required]
        public TimeOnly Call_Start_Time { get; set; } 
        
        [Required]
        public TimeOnly Duration { get; set; }

        [Required]
        [StringLength(11)]
        public string Subscriber_Called_Number { get; set; }

        public Type_Of_Calls_And_Messages Type { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
