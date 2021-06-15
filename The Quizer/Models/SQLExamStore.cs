using Microsoft.EntityFrameworkCore;
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
            Context = context ?? throw new ArgumentNullException(nameof(context));
            AutoSaveChanges = true;
        }

        public bool AutoSaveChanges { get; set; }
        public AppDBContext Context { get; private set; }

        public async Task<string> CreateAsync(Exam exam, string userId)
        {
            if (exam == null)
            {
                throw new ArgumentNullException(nameof(exam));
            }
            else if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }
            else if (await Context.Users.AnyAsync(a => a.Id == userId))
            {
                exam.Status = ExamStatus.Unpublished;
                await Context.AddAsync<Exam>(exam);
                await Context.AddAsync<UserExam>(new UserExam
                {
                    Exam_id = exam.Id,
                    User_id = userId,
                    Status = UserExamStatus.Creator
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

        public async Task<Exam> FindByIdWithQueAnsAsync(string examId)
        {
            var exam = await Context.Exams.Include(e => e.ExamQuestions)
                                            .ThenInclude(q => q.QuestionAnswers)
                                            .SingleOrDefaultAsync(a => a.Id == examId);
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
                throw new ArgumentNullException(nameof(userId));
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