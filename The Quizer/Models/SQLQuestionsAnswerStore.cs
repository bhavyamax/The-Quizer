using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class SQLQuestionsAnswerStore : IQuestionAnswerStore
    {
        public Task AddToRoleAsync(ExamQuestion examQuestion, string QuestionID)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(ExamQuestion examQuestion)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(ExamQuestion examQuestion, string QuestionID)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(ExamQuestion examQuestion, string QuestionID)
        {
            throw new NotImplementedException();
        }
    }
}
