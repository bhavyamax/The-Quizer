using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IQuestionAnswerStore
    {
        /// <summary>
        ///     Adds a ExamQuestion to a role
        /// </summary>
        /// <param name="examQuestion"></param>
        /// <param name="QuestionID"></param>
        /// <returns></returns>
        Task AddToRoleAsync(ExamQuestion examQuestion, string QuestionID);

        /// <summary>
        ///     Removes the role for the ExamQuestion
        /// </summary>
        /// <param name="examQuestion"></param>
        /// <param name="QuestionID"></param>
        /// <returns></returns>
        Task RemoveFromRoleAsync(ExamQuestion examQuestion, string QuestionID);

        /// <summary>
        ///     Returns the roles for this ExamQuestion
        /// </summary>
        /// <param name="examQuestion"></param>
        /// <returns></returns>
        Task<IList<string>> GetRolesAsync(ExamQuestion examQuestion);

        /// <summary>
        ///     Returns true if a ExamQuestion is in the role
        /// </summary>
        /// <param name="examQuestion"></param>
        /// <param name="QuestionID"></param>
        /// <returns></returns>
        Task<bool> IsInRoleAsync(ExamQuestion examQuestion, string QuestionID);


    }
}
