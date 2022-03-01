﻿using System;
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
        [Key]
        public int ID_Type_Of_Call_And_Message { get; set; }

        [Required]
        [StringLength(40)]
        public string Type_Name { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}