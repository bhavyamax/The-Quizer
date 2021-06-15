using System.ComponentModel.DataAnnotations;

namespace The_Quizer.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password does not match password.")]
        public string ConfirmPassword { get; set; }
    }
}