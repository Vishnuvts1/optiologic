using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Optiologicsample.Models
{
    public class employee
    {
        public int empid { get; set; }
        [Required]
        [Display(Name ="FirstName")]
        public string empfirstname { get; set; }
        [Required]
        [Display(Name = "LaststName")]
        public string emplastname { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",ErrorMessage =    "Enter mail correct format")]
        public string empemail { get; set; }
        [Display(Name = "DOB")]
        [Required]
        [Range(18,56,ErrorMessage ="Age must be between 18 to 56")]
        public string empdob { get; set; }
        [Display(Name = "Gender")]
        [Required]
        public string Gender { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,15}$", ErrorMessage ="The password must have one upparcase one lowercase latter and one digit one special character minimum 8 character")]
        public string emppassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required]
        public string empconfirmpassword { get; set; }
        
    }
}