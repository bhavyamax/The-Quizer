using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class UserExam
    {
        public UserExam()
        {
            Score = -1;
        }

        
        [Required]
        [ForeignKey("ApplicationUser")]
        public string User_id { get; set; }
        [Required]
        [ForeignKey("Exam")]
        public string Exam_id { get; set; }
        [Range(minimum: 0,maximum: 100)]
        public float? Score { get; set; }

        [Required]
        public UserExamStatus Status { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Exam Exam { get; set; }
    }
    public enum UserExamStatus
    {
        Creator,
        Pending,
        Given,
        On_Going
    }
}
