using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class SQLQuestionsAnswerStore : IQuestionAnswerStore
    {
        public Task<string> CreateAsync(Exam exam, string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Exam exam)
        {
            throw new NotImplementedException();
        }

        public Task<Exam> FindByIdAsync(string examId)
        {
            throw new NotImplementedException();
        }

        public Task<Exam> FindByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task<List<Exam>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Exam>> GetAllForUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}
