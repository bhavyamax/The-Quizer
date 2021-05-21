using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IQuestionAnswerRepository
    {
        List<QuestionAnswer> GetquestionAnswers();
        bool CreateQuestionAnswer(QuestionAnswer questionAnswer);
        
        
    }
}
