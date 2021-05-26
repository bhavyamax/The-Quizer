using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class SQLUserExamStore : IUserExamStore
    {
        public Task AssignExamAsync(ApplicationUser user, string examId)
        {
            throw new NotImplementedException();
        }

        public Task GetExamsAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsINExamAsync(ApplicationUser user, string roleId)
        {
            throw new NotImplementedException();
        }

        public Task UnAssignExamAsync(ApplicationUser user, string examId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExamScoreAsync(UserExam userExam)
        {
            throw new NotImplementedException();
        }
    }
}
