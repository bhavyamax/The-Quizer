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
        Task<string> CreateAsync(Exam exam,string userId);

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
        Task<Exam> FindByIdAsync(string examId);
        /// <summary>
        ///     Find a examQuestion by id
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        Task<Exam> FindByIdWithQueAnsAsync(string examId);
        /// <summary>
        ///     List of all Exams for user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<Exam>> GetAllForUserAsync(string userId);
        /// <summary>
        ///     List of all Exams for user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<Exam>> GetAllAsync();

        /// <summary>
        ///     Find a exam by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<Exam> FindByTitleAsync(string title);
    }
}
