using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class SQLExamStore : IExamStore
    {
        public Task CreateAsync(ExamQuestion examQuestion)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ExamQuestion examQuestion)
        {
            throw new NotImplementedException();
        }

        public Task<ExamQuestion> FindByIdAsync(string examQuestionId)
        {
            throw new NotImplementedException();
        }

        public Task<ExamQuestion> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ExamQuestion examQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
