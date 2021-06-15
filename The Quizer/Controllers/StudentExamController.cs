using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using The_Quizer.Models;
using The_Quizer.Utilities;
using The_Quizer.ViewModels;

namespace The_Quizer.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentExamController : Controller
    {
        private readonly IUserExamStore userExamStore;
        private readonly IExamStore examStore;
        private readonly IExamQuestionStore examQuestionStore;

        public StudentExamController(IUserExamStore userExamStore, IExamStore examStore, IExamQuestionStore examQuestionStore)
        {
            this.userExamStore = userExamStore;
            this.examStore = examStore;
            this.examQuestionStore = examQuestionStore;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await userExamStore.GetUserExamsAsync(userId);

            ViewData["Title"] = "Student Home";
            return View(model.OrderByDescending(a => a.Status).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GiveExam(string id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await userExamStore.GetUserExamRecordAsync(userId, id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TakeExam(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userExam = await userExamStore.GetUserExamRecordAsync(userId, id);
            await userExamStore.SetUserExamStartAsync(userExam);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckAns(TakeExamViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            float Score = 0;
            var userExam = await userExamStore.GetUserExamRecordAsync(userId, model.examId);
            if (userExam.Status == UserExamStatus.On_Going)
            {
                foreach (var ques in model.Questions)
                {
                    var dbQues = await examQuestionStore.FindByIdWithAnsAsync(ques.quesId);
                    if (ques.quesType == QuestionType.Single_Choice)
                    {
                        foreach (var item in ques.Answers)
                        {
                            if (dbQues.QuestionAnswers.SingleOrDefault(a => a.ID == item.ansId && a.isCorrect) != null)
                            {
                                Score += dbQues.points;
                            }
                        }
                    }
                    else if (ques.quesType == QuestionType.Multiple_Choice)
                    {
                        ques.Answers = ques.Answers.Where(a => a.isSelected).ToList();
                        var ansScore = dbQues.points / dbQues.QuestionAnswers.Where(a => a.isCorrect).Count();
                        foreach (var item in ques.Answers)
                        {
                            if (dbQues.QuestionAnswers.SingleOrDefault(a => a.ID == ques.Answers[0].ansId && a.isCorrect) != null)
                            {
                                Score += ansScore;
                            }
                        }
                    }
                    else if (ques.quesType == QuestionType.Text)
                    {
                        var ansScore = dbQues.points / dbQues.QuestionAnswers.Count;
                        foreach (var txtAns in ques.Answers)
                        {
                            foreach (var item in dbQues.QuestionAnswers)
                            {
                                if (txtAns.ans.ToLower().Contains(item.Answer.ToLower()))
                                {
                                    Score += ansScore;
                                }
                            }
                        }
                    }
                }
                userExam.Score = Score;
                userExam.Status = UserExamStatus.Given;
                //await userExamStore.AddUserExamScoreAsync(userExam);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}