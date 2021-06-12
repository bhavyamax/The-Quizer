using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IUserExamStore
    {
        Task AddUserExamScoreAsync(UserExam userExam);
        Task<UserExam> GetUserExamRecordAsync(string userId, string examId);
        Task<Exam> GetExamResultsAsync(string examId);
        Task<UserExam> GetUserResultsAsync(string userId);
        Task<UserExam> SetUserRetestAsync(UserExam userExam);
        Task<UserExam> AssingUserToExamAsync(UserExam userExam);
        Task RemoveUserFromExamAsync(UserExam userExam);
    }
}