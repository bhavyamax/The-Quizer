using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Data;

namespace The_Quizer.Models
{
    public class SQLExamStore : IExamStore
    {
        private EntityStore<ApplicationUser> _userStore;
        private readonly Microsoft.EntityFrameworkCore.DbSet<UserExam> _userExams;
        private readonly EntityStore<Exam> _ExamStore;
        public SQLExamStore(AppDBContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context; 
            _userStore = new EntityStore<ApplicationUser>(context);
            _ExamStore = new EntityStore<Exam>(context);
            _userExams = Context.Set<UserExam>();
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
                throw new ArgumentNullException("roleName");
            }

            _ExamStore.Create(exam);
            await SaveChanges();

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
