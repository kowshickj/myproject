using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplication13.Models
{
    public class Signup
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter Your First name")]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Enter Your Last name")]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Enter Your Username")]
        [Display(Name = "Username")]
        public string Username { get; set; }
        public string Registernumber { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Your DOB.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter Your EmailID")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]

        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter the Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]

        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Address { get; set; }
        public string State { get; set; }
        public string District { get; set; }
    }
}