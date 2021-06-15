using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Data;

namespace The_Quizer.Models
{
    public class SQLQuestionAnswerStore : IQuestionAnswerStore
    {
        //IQuestionAnswerStore
        public SQLQuestionAnswerStore(AppDBContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
            AutoSaveChanges = true;
        }

        public AppDBContext Context { get; private set; }
        public bool AutoSaveChanges { get; set; }

        public async Task<string> CreateAsync(QuestionAnswer questionAnswer)
        {
            if (questionAnswer == null)
            {
                throw new ArgumentNullException("exam");
            }
            else if (await Context.ExamQuestions.AnyAsync(a => a.ID == questionAnswer.Ques_ID))
            {
                await Context.AddAsync<QuestionAnswer>(questionAnswer);
            }
            await SaveChanges();
            return questionAnswer.ID;
        }

        public async Task DeleteAsync(QuestionAnswer questionAnswer)
        {
            Context.Remove(questionAnswer);
            await SaveChanges();
        }

        public async Task<QuestionAnswer> FindByIdAsync(string quesAnsId)
        {
            var ans = await Context.QuestionAnswers
                .FirstOrDefaultAsync(m => m.ID == quesAnsId);
            return ans;
        }

        public Task<QuestionAnswer> FindByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<List<QuestionAnswer>> GetAllAsync()
        {
            var anss = from ans in Context.QuestionAnswers
                       select ans;
            return await anss.ToListAsync();
        }

        public async Task<List<QuestionAnswer>> GetAllForQuestionAsync(string quesId)
        {
            if (string.IsNullOrWhiteSpace(quesId))
            {
                throw new ArgumentNullException("quesId");
            }
            var anss = from ans in Context.QuestionAnswers
                       where ans.Ques_ID == quesId
                       select ans;
            return await anss.ToListAsync();
        }

        public async Task UpdateAsync(QuestionAnswer questionAnswer)
        {
            Context.Update(questionAnswer);
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