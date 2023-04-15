using Microsoft.AspNetCore.Mvc;
using CoopDEJC.Models;
using CoopDEJC.Models.CoopDBModels;
using Microsoft.EntityFrameworkCore;

namespace CoopDEJC.Controllers
{
    public class LoginController : Controller
    {
        private readonly CoopContext _context;

        public LoginController(CoopContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Prueba (string email, string password)
        {
            var cliente = from d in _context.Clientes
                          where d.Correo==email && d.Clave==password
                            select new Models.Cliente
                            {
                            Cedula= d.Cedula,
                            Correo= d.Correo,
                            Clave= d.Clave
                            };
             return View(cliente);
        }

        public IActionResult Register()
        {
            return View();
        }




        //[HttpPost]
        //public IActionResult Register(User _user)
        //{
        //    if (_user.Clave == Viewbag.Cclave)
        //    {
        //        //Encriptar _user.clave (si es que se va a hacer)
        //    }
        //    else
        //    {
        //        ViewBag.msg = "Las contraseñas no coinciden";
        //        return View();
        //    }
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Login(User _user)
        //{
        //    //Encriptar _user.clave
        //    return View();
        //}
    }
}
