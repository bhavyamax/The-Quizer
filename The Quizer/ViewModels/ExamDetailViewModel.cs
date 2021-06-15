using System.Collections.Generic;
using The_Quizer.Models;

namespace The_Quizer.ViewModels
{
    public class ExamDetailViewModel
    {
        public Exam Exam { get; set; }
        public IEnumerable<ExamQuestion> ExamQuestions { get; set; }
        public IEnumerable<QuestionAnswer> QuestionAnswers { get; set; }
    }
}