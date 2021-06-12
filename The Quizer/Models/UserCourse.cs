using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class UserCourse
    {
        [Required]
        [ForeignKey("ApplicationUser")]
        public string User_id { get; set; }
        [Required]
        [ForeignKey("Course")]
        public string Course_id { get; set; }

        [Required]
        public UserExamStatus Type { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Course Course { get; set; }
    }
    public enum UserCourseType
    {
        Teacher,
        Student
    }
}
