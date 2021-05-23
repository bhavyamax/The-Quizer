using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_Quizer.Models
{
    public class ExamQuestion
    {
        [Required]
        [Key]
        public int ID { get; set; }
        [ForeignKey("Exam")]
        public int Exam_id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public QuestionType Type { get; set; }
        public float points { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual List<QuestionAnswer> QuestionAnswers { get; set; }
    }

    public enum QuestionType
    {
        Single,
        Multi,
        Text
    }
}
