using System.ComponentModel.DataAnnotations;

namespace The_Quizer.ViewModels
{
    public class CreateQuestionAnsViewModel
    {
        [Required]
        public string Answer { get; set; }
        [Required]
        public bool isCorrect { get; set; }
    }

}
