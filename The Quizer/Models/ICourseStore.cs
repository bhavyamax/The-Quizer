using System.Collections.Generic;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface ICourseStore
    {
        Task<string> CreateAsync(Course course, string teacherId);
        Task DeleteAsync(Course course);
        Task<Course> FindByIdAsync(string courseId);
        Task<Course> FindByTitleAsync(string title);
        Task<List<Course>> GetAllAsync();
        Task<List<Course>> GetAllForUserAsync(string userId);
        Task UpdateAsync(Course exam);
    }
}