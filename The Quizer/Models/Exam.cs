using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Status { get; set; }

        public virtual List<UserExam> UserExams { get; set; }
        public virtual List<ExamQuestion> ExamQuestions { get; set; }


    }
}
