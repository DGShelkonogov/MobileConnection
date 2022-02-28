using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Type_Of_Calls_And_Messages
    {
        [Key]
        public int ID_Type_Of_Calls_And_Messages { get; set; }

        [Required]
        [StringLength(40)]
        public string Type_Name { get; set; }
    }
}
