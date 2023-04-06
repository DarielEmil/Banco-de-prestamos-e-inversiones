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
        [HttpPost]
        public IActionResult Register(User _user)
        {
            if (_user.Clave == _user.ConfirmarClave)
            {
                //Encriptar _user.clave (si es que se va a hacer)
            }
            else
            {
                ViewBag.msg = "Las contraseñas no coinciden";
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(User _user)
        {
            return View();
        }
    }
}
