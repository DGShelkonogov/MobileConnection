using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Post : INotifyPropertyChanged
    {

        public Post()
        {

        }
        public Post(Post Post)
        {
            Post_Name = Post.Post_Name;
        }

        [Key]
        public int ID_Post { get; set; }

        [Required (ErrorMessage ="Пустое имя")]
        [StringLength(20, ErrorMessage = "Длинна должна быть меньше 20 символов")]
        public string Post_Name { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
