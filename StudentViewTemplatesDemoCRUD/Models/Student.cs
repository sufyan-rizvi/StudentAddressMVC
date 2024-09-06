using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace StudentViewTemplatesDemoCRUD.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Age!")]
        [Range(18,28)]
        public int Age { get; set; }
        public Address Address { get; set; }
    }
}