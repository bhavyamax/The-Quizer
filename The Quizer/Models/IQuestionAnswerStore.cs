using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IQuestionAnswerStore
    {
        /// <summary>
        ///     Adds a exam to a role
        /// </summary>
        /// <param name="exam"></param>
        /// <param name="QuestionID"></param>
        /// <returns></returns>
        Task AddToRoleAsync(Exam exam, string QuestionID);

        /// <summary>
        ///     Removes the role for the exam
        /// </summary>
        /// <param name="exam"></param>
        /// <param name="QuestionID"></param>
        /// <returns></returns>
        Task RemoveFromRoleAsync(Exam exam, string QuestionID);

        /// <summary>
        ///     Returns the roles for this exam
        /// </summary>
        /// <param name="exam"></param>
        /// <returns></returns>
        Task<IList<string>> GetRolesAsync(Exam exam);

        /// <summary>
        ///     Returns true if a exam is in the role
        /// </summary>
        /// <param name="exam"></param>
        /// <param name="QuestionID"></param>
        /// <returns></returns>
        Task<bool> IsInRoleAsync(Exam exam, string QuestionID);


    }
}
