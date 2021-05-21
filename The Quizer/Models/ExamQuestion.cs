using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace The_Quizer.Models
{
    public class ExamQuestion
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public int Exam_id { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public float points { get; set; }
    }
}
