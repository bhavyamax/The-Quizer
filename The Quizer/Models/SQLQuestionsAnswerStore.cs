using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class SQLQuestionsAnswerStore : IQuestionAnswerStore
    {
        public Task AddToRoleAsync(Exam exam, string QuestionID)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(Exam exam)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(Exam exam, string QuestionID)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(Exam exam, string QuestionID)
        {
            throw new NotImplementedException();
        }
    }
}
