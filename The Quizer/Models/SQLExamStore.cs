using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Data;

namespace The_Quizer.Models
{
    public class SQLExamStore : IExamStore
    {
        public SQLExamStore(AppDBContext context)
        {
            Context = context;
        }

        public AppDBContext Context { get; private set; }
        public bool AutoSaveChanges { get;  set; }

        public virtual async Task CreateAsync(Exam exam, string userId)
        {
            if (exam==null)
            {
                throw new ArgumentNullException("exam");
            }else if (string.IsNullOrWhiteSpace(userId))
            {

            }
            Context.Set<Exam>().Add(exam);

        }

        public Task DeleteAsync(Exam exam)
        {
            throw new NotImplementedException();
        }

        public Task<ExamQuestion> FindByIdAsync(string examId)
        {
            throw new NotImplementedException();
        }

        public Task<ExamQuestion> FindByNameAsync(string examName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Exam exam)
        {
            throw new NotImplementedException();
        }

        private async Task SaveChanges()
        {
            if (AutoSaveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }
    }
}
