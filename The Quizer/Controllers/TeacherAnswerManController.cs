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
    public class TeacherAnswerManController : Controller
    {
        private readonly IQuestionAnswerStore questionAnswerStore;

        public TeacherAnswerManController(IQuestionAnswerStore questionAnswerStore)
        {
            this.questionAnswerStore = questionAnswerStore;
        }

        //// GET: TeacherAnswerMan
        //public async Task<IActionResult> Index()
        //{
        //    var appDBContext = _context.QuestionAnswers.Include(q => q.ExamQuestion);
        //    return View(await appDBContext.ToListAsync());
        //}

        //// GET: TeacherAnswerMan/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var questionAnswer = await _context.QuestionAnswers
        //        .Include(q => q.ExamQuestion)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (questionAnswer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(questionAnswer);
        //}

        // GET: TeacherAnswerMan/Create
        public IActionResult Create(string quesId)
        {
            var model = new QuestionAnswer { Ques_ID = quesId };
            return View(model);
        }

        // POST: TeacherAnswerMan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ques_ID,Answer,isCorrect")] QuestionAnswer questionAnswer)
        {
            if (ModelState.IsValid)
            {
                await questionAnswerStore.CreateAsync(questionAnswer);
                return RedirectToAction("Details","TeacherQuestionsMan",new { id = questionAnswer.Ques_ID});
            }
            return View(questionAnswer);
        }

        // GET: TeacherAnswerMan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionAnswer = await questionAnswerStore.FindByIdAsync(id);
            if (questionAnswer == null)
            {
                return NotFound();
            }
            return View(questionAnswer);
        }

        // POST: TeacherAnswerMan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Ques_ID,Answer,isCorrect")] QuestionAnswer questionAnswer)
        {
            if (id != questionAnswer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await questionAnswerStore.UpdateAsync(questionAnswer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await QuestionAnswerExists(questionAnswer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details","TeacherQuestionsMan",new { id = questionAnswer.Ques_ID});
            }
            return View(questionAnswer);
        }

        //    // GET: TeacherAnswerMan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionAnswer = await questionAnswerStore.FindByIdAsync(id);
            if (questionAnswer == null)
            {
                return NotFound();
            }

            return View(questionAnswer);
        }

        // POST: TeacherAnswerMan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id,string Ques_ID)
        {
            var questionAnswer = await questionAnswerStore.FindByIdAsync(id);
            await questionAnswerStore.DeleteAsync(questionAnswer);
            return RedirectToAction("Details","TeacherQuestionsMan",new { id = Ques_ID});
        }

        private async Task<bool> QuestionAnswerExists(string id)
        {
            return await  questionAnswerStore.FindByIdAsync(id)!=null;
        }
    }
}
