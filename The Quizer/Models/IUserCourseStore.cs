using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IUserCourseStore
    {
        Task AddUserToCourseAsync(UserCourse userCourse);
        Task RemoveUserFromCourseAsync(UserCourse userCourse);
        Task<Course> GetCourseResultsAsync(string CourseId);
        Task<UserCourse> GetUserCourseResultsAsync(string userId, string courseId);
        Task<List<ApplicationUser>> UsersInExamAsync(string courseId);
        Task<List<ApplicationUser>> UsersNotInExamAsync(string courseId);
    }
}
