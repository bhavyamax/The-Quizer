using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Quizer.Data;
using The_Quizer.Models;
using AspNetCore;
using The_Quizer.ViewModels.TeacherExamMan;

namespace The_Quizer.Controllers
{
    public class TeacherExamManController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IExamStore examStore;
        private readonly IExamQuestionStore examQuestionStore;

        public TeacherExamManController(AppDBContext context,IExamStore _examStore,IExamQuestionStore _examQuestionStore)

        {
            _context = context;
            examStore = _examStore;
            examQuestionStore = _examQuestionStore;
        }

        // GET: TeacherExamMan
        public async Task<IActionResult> Index()
        {
            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var exams = examStore.GetAllForUserAsync(userId);
            var exams = await examStore.GetAllAsync();
            return View(exams);
        }

        // GET: TeacherExamMan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            ExamDetailsViewModel examDetailsViewModel = new ExamDetailsViewModel();
            if (id == null)
            {
                return NotFound();
            }
            examDetailsViewModel.Exam = await examStore.FindByIdAsync(id);
            examDetailsViewModel.ExamQuestions = examDetailsViewModel.Exam.ExamQuestions;
            if (examDetailsViewModel.Exam == null)
            {
                return NotFound();
            }
            return View(examDetailsViewModel);
        }

        // GET: TeacherExamMan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherExamMan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Status")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await examStore.CreateAsync(exam, userId);
                return RedirectToAction(nameof(Index));
            }
            return View(exam);
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
                    if (!ExamExists(exam.Id))
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
            var exam = await _context.Exams.FindAsync(id);
            if (exam != null)
            {
                await examStore.DeleteAsync(exam);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            
        }

        private bool ExamExists(string id)
        {
            return _context.Exams.Any(e => e.Id == id);
        }
    }
}
