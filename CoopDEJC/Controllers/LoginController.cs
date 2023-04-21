using Microsoft.AspNetCore.Mvc;
using CoopDEJC.Models;
namespace CoopDEJC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            return RedirectToAction("Login", "Login");
        }
    }
}
