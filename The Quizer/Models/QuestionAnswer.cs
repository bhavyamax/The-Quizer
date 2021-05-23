using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class QuestionAnswer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [ForeignKey("ExamQuestion")]
        public int Ques_ID { get; set; }
        [Required]
        public string Answer { get; set; }
        public bool isCorrect { get; set; }

        public virtual ExamQuestion ExamQuestion { get; set; }
    }
}
