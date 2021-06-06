using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Quizer.Data;
using The_Quizer.Models;

namespace The_Quizer.Controllers
{
    public class TeacherQuestionsManController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IExamQuestionStore examQuestionStore;

        public TeacherQuestionsManController(AppDBContext context,IExamQuestionStore examQuestionStore)
        {
            _context = context;
            this.examQuestionStore = examQuestionStore;
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
        public IActionResult Create()
        {
            ViewData["Exam_id"] = new SelectList(_context.Exams, "Id", "Title");
            return View();
        }

        // POST: TeacherQuestionsMan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Exam_id,Question,Type,points")] ExamQuestion examQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Exam_id"] = new SelectList(_context.Exams, "Id", "Id", examQuestion.Exam_id);
            return View(examQuestion);
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
