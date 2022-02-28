using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Corporate_Client
    {
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
        public Client Client { get; set; }
    }
}
