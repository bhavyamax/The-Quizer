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
        public ExamQuestion()
        {
            ID = Guid.NewGuid().ToString();
        }
        [Required]
        [Key]
        [StringLength(450)]
        public string ID { get; set; }
        [ForeignKey("Exam")]
        public string Exam_id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public QuestionType Type { get; set; }
        public float points { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }

    public enum QuestionType
    {
        Single,
        Multi,
        Text
    }
}
