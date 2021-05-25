using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IExamStore
    {
        List<Exam> GetAllUserExams(int userid);
        Exam GetUserExam(int userid);
        Exam CreateExam(Exam exam);
    }
}
