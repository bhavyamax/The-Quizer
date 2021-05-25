using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class SQLExamRepository : IExamRepository
    {
        public Exam CreateExam(Exam exam)
        {
            throw new NotImplementedException();
        }

        public List<Exam> GetAllUserExams(string userid)
        {
            throw new NotImplementedException();
        }

        public Exam GetUserExam(string userid, int examid)
        {
            throw new NotImplementedException();
        }
    }
}
