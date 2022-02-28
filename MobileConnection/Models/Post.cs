using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Post
    {
        [Key]
        public int ID_Post { get; set; }

        [Required]
        [StringLength(20)]
        public string Post_Name { get; set; }
    }
}
