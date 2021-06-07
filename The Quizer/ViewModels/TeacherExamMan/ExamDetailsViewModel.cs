using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Models;

namespace The_Quizer.ViewModels.TeacherExamMan
{
    public class ExamDetailsViewModel
    {
        public Exam Exam { get; set; }
        public IEnumerable<ExamQuestion> examQuestions { get; set; }
    }
}
