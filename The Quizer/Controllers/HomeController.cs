using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace The_Quizer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Student"))
            {
                return RedirectToAction("Index", "StudentExam");
            }
            else if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("Index", "TeacherExamMan");
            }
            else if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}