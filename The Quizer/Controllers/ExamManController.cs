using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Controllers
{
    public class ExamManController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
