using CoopDEJC.Models.CoopDBModels;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public ActionResult CreacionCuenta(string email, string fname, string lname, string id, string phone, string location, string password, string cpassword, string securityq)
        {
            Cliente cliente = new Cliente();
            if (password == cpassword)
            {
                cliente.Cedula = id;
                cliente.Nombre = fname;
                cliente.Apellido = lname;
                cliente.Telefono = phone;
                cliente.Direccion = location;
                cliente.Correo = email;
                cliente.Clave = password;
                cliente.PreguntaSeguridad = cpassword;
                cliente.Token = Guid.NewGuid();
                try
                {
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error al guardar: "+ ex);
                }
            }
            else
            {
            //Aqui va el aviso de que las contraseñas no coinciden   
            }
            return View("Register");
        }


        //Autenticador ya conectado a la base de datos
        public IActionResult Prueba (string email, string password)
        {
            var cliente = (from d in _context.Clientes
                           where d.Correo == email && d.Clave == password
                           select new Models.Cliente
                           {
                               Cedula = d.Cedula,
                               Correo = d.Correo,
                               Clave = d.Clave
                           }).FirstOrDefault();
            if (cliente?.Correo != null && cliente?.Clave != null)
            {
                return RedirectToAction("Usuario", "Home", cliente);
            } else
            {
            //Aqui necesito retornar una alerta,dariel o cesar no quise investigar mucho porque hay que bregar con un poco de frontend
                return Content("<h3>Here's a custom content header</h3>", "text/html");
            }
            
           
        }

        public IActionResult SignOut()
        {
            return RedirectToAction("Login", "Login");
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
