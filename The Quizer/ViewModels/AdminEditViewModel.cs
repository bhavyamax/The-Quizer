using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The_Quizer.ViewModels
{
    public class AdminEditViewModel
    {
        [Required]
        [Display(Name = "User ID")]
        public string ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<string> UserRole { get; set; }

        [Required]
        [Display(Name = "User Role")]
        public string SelectedRole { get; set; }
    }
}