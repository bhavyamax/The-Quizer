using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using The_Quizer.Models;
using The_Quizer.ViewModels;

namespace The_Quizer.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherQuestionsManController : Controller
    {
        private readonly IExamQuestionStore examQuestionStore;
        private readonly IExamStore examStore;
        private readonly IQuestionAnswerStore questionAnswerStore;

        public TeacherQuestionsManController(IExamQuestionStore examQuestionStore,
                                             IExamStore examStore,
                                             IQuestionAnswerStore questionAnswerStore)
        {
            this.examQuestionStore = examQuestionStore;
            this.examStore = examStore;
            this.questionAnswerStore = questionAnswerStore;
        }


        // GET: TeacherQuestionsMan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var examQuestion = await examQuestionStore.FindByIdWithAnsAsync(id);
            if (examQuestion == null)
            {
                return NotFound();
            }

            return View(examQuestion);
        }

        // GET: TeacherQuestionsMan/Create
        public async Task<IActionResult> Create(string examId)
        {
            if (string.IsNullOrEmpty(examId))
            {
                NotFound();
            }
            ViewBag.exam = await examStore.FindByIdWithQueAnsAsync(examId);

            if (ViewBag.exam == null)
            {
                NotFound();
            }
            var model = new CreateQuestionViewModel { Exam_id = examId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateQuestionViewModel createQuestionViewModel)
        {
            if (createQuestionViewModel.questionAnswers.Count > 0)
            {
                ExamQuestion Question = new()
                {
                    Exam_id = createQuestionViewModel.Exam_id,
                    Question = createQuestionViewModel.Question,
                    Type = createQuestionViewModel.Type,
                    points = createQuestionViewModel.points
                };
                await examQuestionStore.CreateAsync(Question);
                foreach (var item in createQuestionViewModel.questionAnswers)
                {
                    QuestionAnswer answer = new()
                    {
                        Answer = item.Answer,
                        Ques_ID = Question.ID,
                        isCorrect = item.isCorrect
                    };
                    await questionAnswerStore.CreateAsync(answer);
                }
                return RedirectToAction("Details", "TeacherExamMan", new { id = Question.Exam_id });
            }

            ModelState.AddModelError("", "Atleast One Answer is needed");
            ViewBag.exam = await examStore.FindByIdWithQueAnsAsync(createQuestionViewModel.Exam_id);

            if (ViewBag.exam == null)
            {
                NotFound();
            }
            return View(createQuestionViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddQuestion(CreateQuestionViewModel createQuestionViewModel)
        {
            createQuestionViewModel.questionAnswers.Add(new CreateQuestionAnsViewModel());
            return PartialView("CreateQuestionAns", createQuestionViewModel);
        }

        // GET: TeacherQuestionsMan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examQuestion = await examQuestionStore.FindByIdAsync(id);
            if (examQuestion == null)
            {
                return NotFound();
            }
            return View(examQuestion);
        }

        // POST: TeacherQuestionsMan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Exam_id,Question,Type,points")] ExamQuestion examQuestion)
        {
            if (id != examQuestion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await examQuestionStore.UpdateAsync(examQuestion);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await ExamQuestionExists(examQuestion.ID)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "TeacherExamMan", new { id = examQuestion.Exam_id });
            }
            return View(examQuestion);
        }

        // GET: TeacherQuestionsMan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examQuestion = await examQuestionStore.FindByIdAsync(id);
            if (examQuestion == null)
            {
                return NotFound();
            }

            return View(examQuestion);
        }

        // POST: TeacherQuestionsMan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, string examId)
        {
            var examQuestion = await examQuestionStore.FindByIdAsync(id);
            await examQuestionStore.DeleteAsync(examQuestion);
            return RedirectToAction("Details", "TeacherExamMan", new { id = examId });
        }

        private async Task<bool> ExamQuestionExists(string id)
        {
            return (await examQuestionStore.FindByIdAsync(id)) == null;
        }
    }
}