using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Models;
using The_Quizer.ViewModels;

namespace The_Quizer.Controllers
{
    public class AdminManController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminManController(UserManager<ApplicationUser> userManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task< IActionResult> ListUsers()
        {
            var users = await userManager.GetUsersInRoleAsync("Admin");
            return View(users);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            AdminRegisterViewModel adminRegisterViewModel = new AdminRegisterViewModel
            {
                Password = "Admin@1",
                UserRole = roleManager.Roles.Select(a => new { a.Name, isSelected = false }).ToDictionary(a=>a.Name,(a=>a.Name=="Admin"))
            };
            return View();
        }



    }
}
