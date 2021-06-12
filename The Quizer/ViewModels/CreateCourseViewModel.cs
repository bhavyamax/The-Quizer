using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Models;

namespace The_Quizer.ViewModels
{
    public class CreateCourseViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public CourseStatus Status { get; set; }
        [Required]
        [Display(Name ="Teacher")]
        public string TeacherId{ get; set; }
    }
}
