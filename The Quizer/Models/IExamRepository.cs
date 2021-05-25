using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IExamRepository
    {
        List<Exam> GetAllUserExams(string userid);
        Exam GetUserExam(string userid,int examid);
        Exam CreateExam(Exam exam);
    }
}
