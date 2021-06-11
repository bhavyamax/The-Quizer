using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IUserExamStore
    {
        Task AddUserExamScoreAsync(UserExam userExam);
        Task<Exam> GetExamResultsAsync(string examId);
        Task<UserExam> GetUserResultsAsync(string userId);
    }
}