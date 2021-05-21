using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Models;

namespace The_Quizer.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {

        }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
