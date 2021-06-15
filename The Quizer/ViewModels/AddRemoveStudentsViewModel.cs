using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using The_Quizer.Models;

namespace The_Quizer.ViewModels
{
    public class AddRemoveStudentsViewModel
    {
        public string examId { get; set; }
        public List<SelcteStu> Assigned { get; set; }
        public List<SelcteStu> notAssigned { get; set; }
    }

    public class SelcteStu
    {
        [Display(Name = "In Exam")]
        public bool isSelected { get; set; }

        public string id { get; set; }
        public ApplicationUser student { get; set; }
    }
}