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
        public int User_id { get; set; }
        public int Exam_id { get; set; }
        public float? Score { get; set; }
    }
}
