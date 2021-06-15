using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_Quizer.Models
{
    public class QuestionAnswer
    {
        public QuestionAnswer()
        {
            ID = Guid.NewGuid().ToString();
        }

        [Key]
        [StringLength(450)]
        public string ID { get; set; }

        [Required]
        [ForeignKey("ExamQuestion")]
        public string Ques_ID { get; set; }

        [Required]
        public string Answer { get; set; }

        public bool isCorrect { get; set; }

        public virtual ExamQuestion ExamQuestion { get; set; }
    }
}