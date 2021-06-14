using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using The_Quizer.Models;

namespace The_Quizer.Controllers
{
    public class StudentExamController : Controller
    {
        private readonly IUserExamStore userExamStore;

        public StudentExamController(IUserExamStore userExamStore)
        {
            this.userExamStore = userExamStore;
        }
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model =await userExamStore.GetUserExamsAsync(userId);
            ViewData["Title"] = "Student Home";
            return View(model);
        }
    }
}
