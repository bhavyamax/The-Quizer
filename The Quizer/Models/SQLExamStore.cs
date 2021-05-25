using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public class SQLExamStore : IExamStore
    {
        public Exam CreateExam(Exam exam)
        {
            throw new NotImplementedException();
        }

        public List<Exam> GetAllUserExams(int userid)
        {
            throw new NotImplementedException();
        }

        public Exam GetUserExam(int userid)
        {
            throw new NotImplementedException();
        }
    }
}
