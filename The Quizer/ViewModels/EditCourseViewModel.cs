using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.ViewModels
{
    public class EditCourseViewModel
    {
        public string id { get; set; }

        [Required(ErrorMessage ="Course Title is Required")]
        [Display(Name ="Course Title")]
        public string CourseTitle { get; set; }

        public List<string> Students { get; set; }
    }
}
