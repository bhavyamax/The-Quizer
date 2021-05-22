using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Conform Password")]
        [Compare("Password",ErrorMessage ="Confirm Password does not match password.")]
        public string ConfirmPassword { get; set; }
    }
}
