using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using The_Quizer.Models;
using The_Quizer.Utilities;
using The_Quizer.ViewModels;

namespace The_Quizer.Controllers
{
    public class StudentExamController : Controller
    {
        private readonly IUserExamStore userExamStore;
        private readonly IExamStore examStore;

        public StudentExamController(IUserExamStore userExamStore, IExamStore examStore)
        {
            this.userExamStore = userExamStore;
            this.examStore = examStore;
        }
        public async Task<IActionResult> Index()
        {
            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            string userId = "b1f0fde6-4a28-4630-89c2-250d8f326b4f";

            var model = await userExamStore.GetUserExamsAsync(userId);


            ViewData["Title"] = "Student Home";
            return View(model.OrderByDescending(a => a.Status).ToList());
        }

        public async Task<IActionResult> GiveExam(string id)
        {
            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userId = "b1f0fde6-4a28-4630-89c2-250d8f326b4f";

            var model = await userExamStore.GetUserExamRecordAsync(userId, id);
            return View(model);
        }

        public async Task<IActionResult> TakeExam(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var exam = await examStore.FindByIdWithQueAnsAsync(id);
            if (exam == null || exam.Status == ExamStatus.Closed)
            {
                return RedirectToAction("Error");
            }
            TakeExamViewModel model = new()
            {
                examId = exam.Id,
                Title = exam.Title
            };


            foreach (var Ques in exam.ExamQuestions)
            {
                TakeExamQuesViewModel quesViewModel = new();
                quesViewModel.quesId = Ques.ID;
                quesViewModel.question = Ques.Question;
                quesViewModel.points = (int)Ques.points;
                quesViewModel.quesType = Ques.Type;
                foreach (var ans in Ques.QuestionAnswers)
                {
                    TakeExamAnsViewModel ansViewModel = new();
                    ansViewModel.ansId = ans.ID;
                    ansViewModel.ans = ans.Answer;
                    quesViewModel.Answers.Add(ansViewModel);
                }
                quesViewModel.Answers.Shuffle();
                model.Questions.Add(quesViewModel);
            }
            model.Questions.Shuffle();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> TakeExam(TakeExamViewModel model)
        {
            return NotFound();
        }

    }
}
