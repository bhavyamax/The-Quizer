using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Models;

namespace The_Quizer.ViewModels
{
    public class TakeExamViewModel
    {
        public string examId { get; set; }
        public string Title { get; set; }
        public List<TakeExamQuesViewModel> Questions
        {
            get; set;
        }

        public class TakeExamQuesViewModel
        {
            public string quesId { get; set; }
            public string question { get; set; }
            public QuestionType quesType { get; set; }
            public List<TakeExamAnsViewModel> Answers { get; set; }
        }
        public class TakeExamAnsViewModel
        {
            public string ansId { get; set; }
            public string ans { get; set; }
            public bool isSelected { get; set; }
        }
    }
}
