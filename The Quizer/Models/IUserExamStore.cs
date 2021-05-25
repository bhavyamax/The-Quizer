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
    /// <typeparam name="TUser"></typeparam>
    interface IUserExamStore<TUser> : IUserStore<TUser> where TUser : ApplicationUser
    {

        /// <summary>
        ///     Adds a user to a Exam
        /// </summary>
        /// <param name="user"></param>
        /// <param name="examId"></param>
        /// <returns></returns>
        Task AssignExamAsync(TUser user, string examId);
        
        /// <summary>
        ///     Removes the Exam for the user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="examId"></param>
        /// <returns></returns>
        Task UnAssignExamAsync(TUser user, string examId);

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
        Task GetExamsAsync(TUser user);

        /// <summary>
        ///     Returns true if a user is enrolled in the exam
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<bool> IsINExamAsync(TUser user, string roleId);
    }
}
