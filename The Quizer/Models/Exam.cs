using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace The_Quizer.Models
{
    public class Exam
    {
        public Exam()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [StringLength(450)]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public ExamStatus Status { get; set; }

        public virtual ICollection<UserExam> UserExams { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    }

    public enum ExamStatus
    {
        Unpublished,
        Open,
        Closed
    }
}