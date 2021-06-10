using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Models;

namespace The_Quizer.ViewModels
{
    public class CreateQuestionViewModel
    {
        [Required]
        public string Exam_id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public QuestionType Type { get; set; }
        [Required]
        public int points { get; set; }
        [Required]
        public List<CreateQuestionAnsViewModel> questionAnswers { get; set; }

        public CreateQuestionViewModel()
        {
            questionAnswers = new();
        }
    }

}
