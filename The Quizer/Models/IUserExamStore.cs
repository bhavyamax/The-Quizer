using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    /// <summary>
    ///     Interface that maps users to exams
    /// </summary>
    interface IUserExamStore
    {

        /// <summary>
        ///     Adds a user to a Exam
        /// </summary>
        /// <param name="user"></param>
        /// <param name="examId"></param>
        /// <returns></returns>
        Task AssignExamAsync(ApplicationUser user, string examId);

        /// <summary>
        ///     Removes the Exam for the user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="examId"></param>
        /// <returns></returns>
        Task UnAssignExamAsync(ApplicationUser user, string examId);

        /// <summary>
        ///     Removes the role for the user
        /// </summary>
        /// <param name="userExam"></param>
        /// <returns></returns>
        Task UpdateExamScoreAsync(UserExam userExam);

        /// <summary>
        ///     Returns the exams for this user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task GetExamsAsync(ApplicationUser user);

        /// <summary>
        ///     Returns true if a user is enrolled in the exam
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<bool> IsINExamAsync(ApplicationUser user, string roleId);
    }
}
