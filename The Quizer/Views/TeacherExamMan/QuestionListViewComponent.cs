using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Models;

namespace The_Quizer.Views.TeacherExamMan
{
    public class QuestionListViewComponent:ViewComponent
    {
        private readonly IExamQuestionStore examQuestionStore;

        public QuestionListViewComponent(IExamQuestionStore examQuestionStore)
        {
            this.examQuestionStore = examQuestionStore;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }
        private Task<List<ExamQuestion>> GetItemsAsync()
        {
            return examQuestionStore.GetAllAsync();
        }
    }
}
