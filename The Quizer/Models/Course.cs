using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class Course
    {
        public Course()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.UtcNow.Date;
        }
        [Key]
        [StringLength(450)]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public CourseStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<UserCourse> UserCourses { get; set; }
        public virtual ICollection<Exam> Exams{ get; set; }

    }
    public enum CourseStatus
    {
        Active,
        Completed,
        On_Going
    }
}
