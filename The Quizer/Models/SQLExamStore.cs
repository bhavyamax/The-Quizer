using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Data;

namespace The_Quizer.Models
{
    public class SQLExamStore : IExamStore
    {
        public SQLExamStore(AppDBContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            AutoSaveChanges = true;
        }

        public bool AutoSaveChanges { get; set; }
        public AppDBContext Context { get; private set; }
        
        
        public async Task<string> CreateAsync(Exam exam, string userId)
        {
            if (exam == null)
            {
                throw new ArgumentNullException("exam");
            }
            else if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException("userId");
            } else if (await Context.Users.AnyAsync(a=>a.Id==userId))
            {
                await Context.AddAsync<Exam>(exam);
                await Context.AddAsync<UserExam>(new UserExam
                {
                    Exam_id = exam.Id,
                    User_id = userId
                });
            }
            await SaveChanges();
            return exam.Id;
        }

        public async Task DeleteAsync(Exam exam)
        {
            Context.Remove(exam);
            await SaveChanges();
        }

        public async Task<Exam> FindByIdAsync(string examId)
        {
            var exam = await Context.Exams
                .FirstOrDefaultAsync(m => m.Id == examId);
            return exam;
        }

        public Task<Exam> FindByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Exam>> GetAllAsync()
        {
            var exams = from exam in Context.Exams
                        select exam;
            return await exams.ToListAsync();
        }

        public async Task<List<Exam>> GetAllForUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException("roleName");
            }
            var userExams = await Context.UserExams.Where(i => i.User_id == userId).Select(d => d.Exam_id).ToListAsync();
            var exams = from exam in Context.Exams
                        where userExams.Contains(exam.Id)
                        select exam;
            return await exams.ToListAsync();
        }

        public async Task UpdateAsync(Exam exam)
        {
            Context.Update(exam);
            await Context.SaveChangesAsync();
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
