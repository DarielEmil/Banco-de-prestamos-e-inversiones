using Microsoft.AspNetCore.Mvc;
using CoopDEJC.Models;
using CoopDEJC.Models.CoopDBModels;
using CoopDEJC.Login;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Diagnostics.Eventing.Reader;

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

        //Autenticador
        [HttpPost]
        public IActionResult Login1(string email, string password)
        {

            Cliente objeto = new LO_Usuario().SearchUser(email, password);
          
            if (objeto.Nombre == )
            {
                
                    return RedirectToAction("Index", "Home");
            }
            
            /*
              {
                  using (CoopContext db = new CoopContext()) 

                  {
                      var usuario = from c in db.Clientes 
                                    where c.Correo == email && c.Clave == password 
                                    select c;
                      if (usuario.Count() > 0)
                      {
                          return RedirectToAction("Index", "Home");
                      }else
                    {
                        
                        return Content("Usuario invalido ");                    
                    }
                  }

              }
              catch(Exception ex)
              {

              }*/

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
