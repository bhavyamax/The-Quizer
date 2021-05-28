using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IExamStore
    {
        /// <summary>
        ///     Create a new examQuestion
        /// </summary>
        /// <param name="exam"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task CreateAsync(Exam exam,string userId);

        /// <summary>
        ///     Update a examQuestion
        /// </summary>
        /// <param name="exam"></param>
        /// <returns></returns>
        Task UpdateAsync(Exam exam);

        /// <summary>
        ///     Delete a examQuestion
        /// </summary>
        /// <param name="exam"></param>
        /// <returns></returns>
        Task DeleteAsync(Exam exam);

        /// <summary>
        ///     Find a examQuestion by id
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        Task<ExamQuestion> FindByIdAsync(string examId);

        /// <summary>
        ///     Find a examQuestion by name
        /// </summary>
        /// <param name="examName"></param>
        /// <returns></returns>
        Task<ExamQuestion> FindByNameAsync(string examName);
    }
}
