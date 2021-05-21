using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IExamQuestionRepository
    {
        List<ExamQuestion> GetExamQuestions(int Exam_id);
        bool CreateExamQuestion(ExamQuestion examQuestion);
    }
}
