using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentViewTemplatesDemoCRUD.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Country Name!")]
        public string Country {  get; set; }
        [Required(ErrorMessage = "Enter City Name!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter State Name!")]
        public string State {  get; set; }
    }
}