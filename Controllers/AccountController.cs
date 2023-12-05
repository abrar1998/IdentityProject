using FullIdentity_Project8._0.AccountRepository;
using FullIdentity_Project8._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FullIdentity_Project8._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepo repo;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(IAccountRepo repo, RoleManager<IdentityRole> roleManager)
        {
            this.repo = repo;
            this.roleManager = roleManager;
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignUpModel signup)
        {
            if(ModelState.IsValid)
            {
                var res = await repo.SignUp(signup);
                if(!res.Succeeded)
                {
                    foreach (var item in res.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                else
                {
                    return RedirectToAction("Signin", "Account");
                }
            }
            else
            {
                ModelState.Clear();
            }
            return View();
        }


        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(SignInModel signin)
        {
            if (ModelState.IsValid)
            {
                var result = await repo.SignIn(signin);
                if(result.Succeeded)
                {
                    if(User.IsInRole(RolesClass.Admin))
                    {
                        return RedirectToAction("AdminDashBoard", "Admin");
                    }
                    else if(User.IsInRole(RolesClass.Teachers))
                    {
                        return RedirectToAction("TeacherDashBoard", "Teacher");
                    }
                    else if(User.IsInRole(RolesClass.Students))
                    {
                        return RedirectToAction("StudentDashBoard", "Students");
                    }
                    else
                    {
                        return RedirectToAction("Privacy", "Home");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            else
            {
                return View(signin);
            }
            return View();
        }

        public async Task<IActionResult> Signout()
        {
            await repo.SignOut();
            return RedirectToAction("Signin", "Account");
        }

        //Adding roles 
        /*public string AddRoles()
        {
            roleManager.CreateAsync(new IdentityRole(RolesClass.Admin)).GetAwaiter().GetResult();
            roleManager.CreateAsync(new IdentityRole(RolesClass.Students)).GetAwaiter().GetResult();
            roleManager.CreateAsync(new IdentityRole(RolesClass.Teachers)).GetAwaiter().GetResult();
            return "Roles Added Successfully";
        }*/


    }
}
