using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [MaxLength(length:30)]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }

    }
}
