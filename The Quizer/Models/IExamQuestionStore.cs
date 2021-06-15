using System.Collections.Generic;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IExamQuestionStore
    {
        Task<string> CreateAsync(ExamQuestion examQuestion);

        Task DeleteAsync(ExamQuestion examQuestion);

        Task<ExamQuestion> FindByIdAsync(string examQuestionId);

        Task<ExamQuestion> FindByIdWithAnsAsync(string examQuestionId);

        Task<ExamQuestion> FindByTitleAsync(string title);

        Task<List<ExamQuestion>> GetAllAsync();

        Task<List<ExamQuestion>> GetAllForExamAsync(string examId);

        Task UpdateAsync(ExamQuestion examQuestion);
    }
}