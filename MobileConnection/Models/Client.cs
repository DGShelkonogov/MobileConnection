using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Client
    {
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

        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Call> Calls { get; set; }

    }
}
