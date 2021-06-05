using System.Collections.Generic;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IQuestionAnswerStore
    {
        Task<string> CreateAsync(QuestionAnswer questionAnswer);
        Task DeleteAsync(QuestionAnswer questionAnswer);
        Task<QuestionAnswer> FindByIdAsync(string quesAnsId);
        Task<QuestionAnswer> FindByTitleAsync(string title);
        Task<List<QuestionAnswer>> GetAllAsync();
        Task<List<QuestionAnswer>> GetAllForQuestionAsync(string quesId);
        Task UpdateAsync(QuestionAnswer questionAnswer);
    }
}