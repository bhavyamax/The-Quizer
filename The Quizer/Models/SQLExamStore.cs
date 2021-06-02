using System;
using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
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
        }

        public AppDBContext Context { get; private set; }
        public bool AutoSaveChanges { get; set; }



        private async Task SaveChanges()
        {
            if (AutoSaveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public async Task<string> CreateAsync(Exam exam, string userId)
        {
            if (exam == null)
            {
                throw new ArgumentNullException("exam");
            }
            else if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException("roleName");
            }
            await SaveChanges();
            return exam.Id;
        }

        public Task UpdateAsync(Exam exam)
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

        public async Task<List<Exam>> GetAllForUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException("roleName");
            }
            var userExams =  await Context.UserExams.Where(i => i.User_id == userId).Select(d=>d.Exam_id).ToListAsync();
            var exams = from exam in Context.Exams
                        where userExams.Contains(exam.Id)
                        select exam;
            return await exams.ToListAsync();
        }

        public Task<List<Exam>> GetAllAsync()
        {
            var data = from a in Context.Exams
                       select a;
            return data.ToListAsync();
        }

        public Task<Exam> FindByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }
    }
}
