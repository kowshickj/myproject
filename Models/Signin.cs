using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplication13.Models
{
    public class Signin
    {
        [Required(ErrorMessage = "Enter Your Username")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter the Password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}