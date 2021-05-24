using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(length: 30, ErrorMessage = "First name cannot have more than 30 characters.")]
        [Display(Name ="First Name")]
        public string Fname { get; set; }
        [Required]
        [MaxLength(length: 30, ErrorMessage = "Last name cannot have more than 30 characters.")]
        [Display(Name ="Last Name")]
        public string Lname { get; set; }

        public virtual List<UserExam> UserExams { get; set; }
        [Display(Name ="Full Name")]
        [NotMapped]
        public String Name { get { return Fname + " " + Lname; } }

    }
}
