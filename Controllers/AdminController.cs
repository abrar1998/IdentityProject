using FullIdentity_Project8._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullIdentity_Project8._0.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles =RolesClass.Admin)]
        public IActionResult AdminDashBoard()
        {
            return View();
        }
    }
}
