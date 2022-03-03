using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileConnection.Models
{
    public class Employee : INotifyPropertyChanged
    {

        public Employee()
        {

        }

        public Employee(Employee Employee)
        {
            Employee_Surname = Employee.Employee_Surname;
            Employee_Name = Employee.Employee_Name;
            Employee_Patronymic = Employee.Employee_Patronymic;
            Employee_Email = Employee.Employee_Email;
            Password = Employee.Password;
            Post = new Post
            {
                Post_Name = Employee.Post.Post_Name
            };
        }



        [Key]
        public int ID_Employee { get; set; }
        [Required]
        [StringLength(25, ErrorMessage ="Длинна фамилии не должна привышать 25 символов")]
        public string Employee_Surname { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Длинна имени не должна привышать 25 символов")]
        public string Employee_Name { get; set; }
        [StringLength(25, ErrorMessage = "Длинна отчества не должна привышать 25 символов")]
        public string Employee_Patronymic { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Длинна почты не должна привышать 50 символов")]
        public string Employee_Email { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"((?=.*[a-z]+)(?=.*[A-Z]+)(?=.*[0-9]+)(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-]))")]
        public string Password { get; set; }
        [Required]
        public Post Post { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
