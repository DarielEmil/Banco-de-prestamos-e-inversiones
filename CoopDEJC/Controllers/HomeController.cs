using CoopDEJC.Controllers.Funciones;
using CoopDEJC.Models;
using CoopDEJC.Models.CoopDBModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Cliente = CoopDEJC.Models.CoopDBModels.Cliente;

namespace CoopDEJC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CoopContext _context;

        //Creacion del cliente para todo el sistema
        private static Cliente? cliente;

        public HomeController(ILogger<HomeController> logger, CoopContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {

            IndexModel imodel = IndexFunciones.LlenadoIndex(cliente, _context);
            
            return View(imodel);
        }


        public IActionResult Usuario(Models.Cliente login)
        {

            cliente = (from d in _context.Clientes
                       where d.Cedula == login.Cedula
                       select new Cliente
                       {
                           Cedula = d.Cedula,
                           Nombre = d.Nombre,
                           Apellido = d.Apellido,
                           Direccion = d.Direccion,
                           Telefono = d.Telefono,
                           Correo = d.Correo,
                           Clave = d.Clave,
                           Token = d.Token
                       }).FirstOrDefault();

            if (cliente.Correo != null && cliente?.Clave != null)
            {


                return RedirectToAction("Index");

            }
            else
                return RedirectToAction("Index");
        }

        public IActionResult MyProfile()
        {

            return View(cliente);
        }

        public IActionResult Usertoloans()
        {

            return RedirectToAction("Usuario","Loans",cliente);
        }
        public IActionResult UsertoInvesment()
        {
            return RedirectToAction("Usuario", "Investment", cliente);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}