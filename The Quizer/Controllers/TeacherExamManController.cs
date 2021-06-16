using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using The_Quizer.Models;
using The_Quizer.ViewModels;

namespace The_Quizer.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherExamManController : Controller
    {
        private readonly IExamQuestionStore examQuestionStore;
        private readonly IExamStore examStore;
        private readonly IUserExamStore userExamStore;

        public TeacherExamManController(IExamStore _examStore,
                                        IExamQuestionStore _examQuestionStore,
                                        IUserExamStore userExamStore)
        {
            examStore = _examStore;
            examQuestionStore = _examQuestionStore;
            this.userExamStore = userExamStore;
        }

        public async Task<IActionResult> AddRemoveStudents(string id)
        {
            var model = new AddRemoveStudentsViewModel()
            {
                examId = id,
                Assigned = (from user in await userExamStore.UsersInExamAsync(id)
                            select new SelcteStu { isSelected = true, student = user, id = user.Id }).ToList(),
                notAssigned = (from user in await userExamStore.UsersNotInExamAsync(id)
                               select new SelcteStu { isSelected = false, student = user, id = user.Id }).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRemoveStudents(AddRemoveStudentsViewModel model)
        {
            if (await examStore.FindByIdAsync(model.examId) != null)
            {
                if (model.Assigned!=null)
                {

                    foreach (var item in model.Assigned)
                    {
                        if (item.isSelected == false)
                        {
                            var userExam = await userExamStore.GetUserExamRecordAsync(userId: item.id, examId: model.examId);
                            if (userExam != null)
                                await userExamStore.RemoveUserFromExamAsync(userExam);
                        }
                    } 
                }
                if (model.notAssigned!=null)
                {
                    foreach (var item in model.notAssigned)
                    {
                        if (item.isSelected == true)
                        {
                            var userExam = await userExamStore.GetUserExamRecordAsync(userId: item.id, examId: model.examId);
                            if (userExam == null)
                                userExam = new()
                                {
                                    User_id = item.id,
                                    Exam_id = model.examId
                                };
                            await userExamStore.AssingUserToExamAsync(userExam);
                        }
                    } 
                }
                return RedirectToAction(nameof(AddRemoveStudents), new { id = model.examId });
            }
            return NotFound();
        }

        // GET: TeacherExamMan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherExamMan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await examStore.CreateAsync(exam, userId);
                return RedirectToAction(nameof(Index));
            }
            return View(exam);
        }

        // GET: TeacherExamMan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await examStore.FindByIdAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: TeacherExamMan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var exam = await examStore.FindByIdAsync(id);
            if (exam != null)
            {
                await examStore.DeleteAsync(exam);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        // GET: TeacherExamMan/Details/5
        public async Task<IActionResult> Details(string id, string quesId = null)
        {
            if (id == null)
            {
                return NotFound();
            }
            ExamDetailViewModel viewModel = new()
            {
                Exam = await examStore.FindByIdWithQueAnsAsync(id)
            };
            viewModel.ExamQuestions = viewModel.Exam.ExamQuestions;
            if (viewModel.Exam == null)
            {
                return NotFound();
            }
            if (quesId != null)
            {
                ViewBag.QuesId = quesId;
                viewModel.QuestionAnswers = viewModel.Exam.ExamQuestions.Where(a => a.ID == quesId).Single().QuestionAnswers;
            }
            return View(viewModel);
        }

        // GET: TeacherExamMan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await examStore.FindByIdAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }

        // POST: TeacherExamMan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Status")] Exam exam)
        {
            if (id != exam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await examStore.UpdateAsync(exam);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ExamExists(exam.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(exam);
        }

        public async Task<IActionResult> ExamResults(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var examRes = await userExamStore.GetExamResultsAsync(id);
            return View(examRes);
        }

        public async Task<IActionResult> ExamReTest(string examId, string userId)
        {
            var userExam = await userExamStore.GetUserExamRecordAsync(userId, examId);
            await userExamStore.SetUserRetestAsync(userExam);
            return RedirectToAction("ExamResults", new { id = examId });
        }

        // GET: TeacherExamMan
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exams = await examStore.GetAllForUserAsync(userId);
            //var exams = await examStore.GetAllAsync();
            return View(exams);
        }

        private async Task<bool> ExamExists(string id)
        {
            return (await examStore.FindByIdAsync(id)) == null;
        }
    }
}