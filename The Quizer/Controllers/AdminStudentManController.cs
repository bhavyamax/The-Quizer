using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Models;
using The_Quizer.ViewModels;

namespace The_Quizer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminStudentManController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminStudentManController(UserManager<ApplicationUser> userManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [Route("[Controller]/")]
        [Route("[Controller]/ListUsers")]
        [Route("[Controller]/Index")]
        public async Task<IActionResult> ListUsers()
        {
            var users = await userManager.GetUsersInRoleAsync("Student");
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AdminRegisterViewModel adminRegisterViewModel = new()
            {
                Password = "Student@1",
                UserRole = roleManager.Roles.Select(a => a.Name),
                SelectedRole = "Student"
            };
            return View(adminRegisterViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Fname = model.Fname,
                    Lname = model.Lname
                };
                if (string.IsNullOrEmpty(model.Password))
                {
                    model.Password = "Student@1";
                }
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, model.SelectedRole);
                    return RedirectToActionPermanent(nameof(ListUsers));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            model.UserRole = roleManager.Roles.Select(a => a.Name);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"No User With ID = {id} found.";
                return View("NotFound");
            }
            AdminEditViewModel adminEditViewModel = new()
            {
                ID = id,
                Fname = user.Fname,
                Lname = user.Lname,
                Email = user.Email,
                SelectedRole = userManager.GetRolesAsync(user).Result.First(),
                UserRole = roleManager.Roles.Select(a => a.Name)
            };
            return View(adminEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminEditViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.ID);
            if (user == null)
            {
                ViewBag.ErrorMeassage = $"No User With ID = {model.ID} found.";
                return View("NotFound");
            }
            if (ModelState.IsValid)
            {
                user.UserName = user.Email = model.Email;
                user.Fname = model.Fname;
                user.Lname = model.Lname;
                var userResult = await userManager.UpdateAsync(user);
                if (model.Password != null)
                {
                    await userManager.RemovePasswordAsync(user);
                    await userManager.AddPasswordAsync(user, model.Password);
                }
                if (userResult.Succeeded)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    var result = await userManager.RemoveFromRolesAsync(user, roles);
                    //user = await userManager.FindByIdAsync(model.ID);
                    if (result.Succeeded)
                    {
                        result = await userManager.AddToRoleAsync(user, model.SelectedRole);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("index");
                        }
                    }
                    ModelState.AddModelError("", "Cannot Update User Role.");
                    return View(model);
                }
                foreach (var error in userResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"No User With ID = {id} found.";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View("ListUsers");
            }
        }
    }
}