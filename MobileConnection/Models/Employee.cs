using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Employee
    {
        [Key]
        public int ID_Employee { get; set; }
        [Required]
        [StringLength(25)]
        public string Employee_Surname { get; set; }
        [Required]
        [StringLength(25)]
        public string Employee_Name { get; set; }
        [StringLength(25)]
        public string Employee_Patronymic { get; set; }
        [Required]
        [StringLength(50)]
        public string Employee_Email { get; set; }
        [Required]
        [StringLength(25)]
        public string Password { get; set; }
        [Required]
        public Post Post { get; set; }





    }
}
