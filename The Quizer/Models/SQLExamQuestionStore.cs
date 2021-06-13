using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Data;

namespace The_Quizer.Models
{
    public class SQLExamQuestionStore : IExamQuestionStore
    {
        //IExamQuestionStore

        public SQLExamQuestionStore(AppDBContext context)
        {
            Context = context;
            AutoSaveChanges = true;
        }

        public bool AutoSaveChanges { get; set; }
        public AppDBContext Context { get; private set; }
        public async Task<string> CreateAsync(ExamQuestion examQuestion)
        {
            if (examQuestion == null)
            {
                throw new ArgumentNullException("examQuestion");
            }
            else if (await Context.Exams.AnyAsync(a => a.Id == examQuestion.Exam_id))
            {
                await Context.AddAsync<ExamQuestion>(examQuestion);
            }
            await SaveChanges();
            return examQuestion.ID;
        }

        public async Task DeleteAsync(ExamQuestion examQuestion)
        {
            Context.Remove(examQuestion);
            await SaveChanges();
        }

        public async Task<ExamQuestion> FindByIdAsync(string examQuestionId)
        {
            var examQues = await Context.ExamQuestions
                .FirstOrDefaultAsync(m => m.ID == examQuestionId);
            return examQues;
        }

        public async Task<ExamQuestion> FindByIdWithAnsAsync(string examQuestionId)
        {
            var examQues = await Context.ExamQuestions.Include(q=>q.QuestionAnswers)
                .SingleOrDefaultAsync(q=>q.ID==examQuestionId);
            return examQues;
        }

        public Task<ExamQuestion> FindByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExamQuestion>> GetAllAsync()
        {
            var examQuess = from ques in Context.ExamQuestions
                            select ques;
            return await examQuess.ToListAsync();
        }

        public async Task<List<ExamQuestion>> GetAllForExamAsync(string examId)
        {
            if (string.IsNullOrWhiteSpace(examId))
            {
                throw new ArgumentNullException("examId");
            }
            var examQuess = from ques in Context.ExamQuestions
                            where ques.Exam_id == examId
                            select ques;
            return await examQuess.ToListAsync();
        }

        public async Task UpdateAsync(ExamQuestion examQuestion)
        {
            Context.Update(examQuestion);
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
