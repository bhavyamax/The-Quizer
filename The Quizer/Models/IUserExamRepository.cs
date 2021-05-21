using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    interface IUserExamRepository
    {
        UserExam AssignExam(int userid, int examD);
        UserExam UpdateExamScore(UserExam userExam);

    }
}
