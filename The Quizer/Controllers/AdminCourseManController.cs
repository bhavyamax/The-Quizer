﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Quizer.Data;
using The_Quizer.Models;
using The_Quizer.ViewModels;

namespace The_Quizer.Controllers
{
    public class AdminCourseManController : Controller
    {
        private readonly AppDBContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICourseStore courseStore;

        public AdminCourseManController(AppDBContext context,
                                        UserManager<ApplicationUser> userManager,
                                        ICourseStore courseStore)
        {
            _context = context;
            this.userManager = userManager;
            this.courseStore = courseStore;
        }

        // GET: AdminCourseMan
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }

        // GET: AdminCourseMan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: AdminCourseMan/Create
        public async Task<IActionResult> Create()
        {
            await PopulateTeacherList();
            return View();
        }

        // POST: AdminCourseMan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                Course course1 = new()
                {
                    Status = course.Status,
                    Title = course.Title
                };
                await courseStore.CreateAsync(course1, course.TeacherId);
                return RedirectToAction(nameof(Index));
            }
            await PopulateTeacherList();
            return View(course);
        }

        private async Task PopulateTeacherList()
        {
            var selList = from user in (await userManager.GetUsersInRoleAsync("Teacher"))
                          select new SelectListItem(user.Name + " : " + user.Email, user.Id);
            ViewBag.TeacherList = selList;
        }

        // GET: AdminCourseMan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: AdminCourseMan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Status")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            return View(course);
        }

        // GET: AdminCourseMan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: AdminCourseMan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(string id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}