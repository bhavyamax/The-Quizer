using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Quizer.Data;
using The_Quizer.Models;
using The_Quizer.ViewModels;

namespace The_Quizer.Controllers
{
    public class TeacherQuestionsManController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IExamQuestionStore examQuestionStore;
        private readonly IExamStore examStore;
        private readonly IQuestionAnswerStore questionAnswerStore;

        public TeacherQuestionsManController(AppDBContext context,
                                             IExamQuestionStore examQuestionStore,
                                             IExamStore examStore,
                                             IQuestionAnswerStore questionAnswerStore)
        {
            _context = context;
            this.examQuestionStore = examQuestionStore;
            this.examStore = examStore;
            this.questionAnswerStore = questionAnswerStore;
        }

        // GET: TeacherQuestionsMan
        public async Task<IActionResult> Index()
        {
            return View(await examQuestionStore.GetAllAsync());
        }

        // GET: TeacherQuestionsMan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var examQuestion=await examQuestionStore.FindByIdAsync(id);
            if (examQuestion == null)
            {
                return NotFound();
            }

            return View(examQuestion);
        }

        // GET: TeacherQuestionsMan/Create
        public async Task<IActionResult> Create(string examid= "d9ad4c4f-53d0-4f15-9c25-55bc28e50260")
        {
            if (string.IsNullOrEmpty(examid))
            {
                NotFound();
            }
            ViewBag.exam = await examStore.FindByIdWithQueAnsAsync(examid);

            if (ViewBag.exam==null)
            {
                NotFound();
            }
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateQuestionViewModel createQuestionViewModel)
        {
            if (createQuestionViewModel.questionAnswers.Count > 0 && string.IsNullOrEmpty(createQuestionViewModel.questionAnswers[0].Answer))
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

            var examQuestion = await _context.ExamQuestions.FindAsync(id);
            if (examQuestion == null)
            {
                return NotFound();
            }
            ViewData["Exam_id"] = new SelectList(_context.Exams, "Id", "Id", examQuestion.Exam_id);
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
                    _context.Update(examQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamQuestionExists(examQuestion.ID))
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
            ViewData["Exam_id"] = new SelectList(_context.Exams, "Id", "Id", examQuestion.Exam_id);
            return View(examQuestion);
        }

        // GET: TeacherQuestionsMan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examQuestion = await _context.ExamQuestions
                .Include(e => e.Exam)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (examQuestion == null)
            {
                return NotFound();
            }

            return View(examQuestion);
        }

        // POST: TeacherQuestionsMan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var examQuestion = await _context.ExamQuestions.FindAsync(id);
            _context.ExamQuestions.Remove(examQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamQuestionExists(string id)
        {
            return _context.ExamQuestions.Any(e => e.ID == id);
        }
    }
}
