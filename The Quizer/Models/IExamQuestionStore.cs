using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IExamQuestionStore
    {
        /// <summary>
        ///     Create a new examQuestion
        /// </summary>
        /// <param name="examQuestion"></param>
        /// <returns></returns>
        Task CreateAsync(ExamQuestion examQuestion);

        /// <summary>
        ///     Update a examQuestion
        /// </summary>
        /// <param name="examQuestion"></param>
        /// <returns></returns>
        Task UpdateAsync(ExamQuestion examQuestion);

        /// <summary>
        ///     Delete a examQuestion
        /// </summary>
        /// <param name="examQuestion"></param>
        /// <returns></returns>
        Task DeleteAsync(ExamQuestion examQuestion);

        /// <summary>
        ///     Find a examQuestion by id
        /// </summary>
        /// <param name="examQuestionId"></param>
        /// <returns></returns>
        Task<ExamQuestion> FindByIdAsync(string examQuestionId);

        /// <summary>
        ///     Find a examQuestion by name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<ExamQuestion> FindByNameAsync(string roleName);
    }
}
