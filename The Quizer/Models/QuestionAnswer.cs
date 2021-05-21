using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class QuestionAnswer
    {
        public int ID { get; set; }
        public int Ques_ID { get; set; }
        public string Answer { get; set; }
        public bool isCorrect { get; set; }
    }
}
