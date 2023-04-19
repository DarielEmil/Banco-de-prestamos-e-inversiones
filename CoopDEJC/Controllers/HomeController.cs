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
            return View();
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
                //var prestamos = (from d in _context.Prestamos
                //                 where d.Usuario.Cedula == login.Cedula
                //                 select new Cliente
                //                 {
                //                     Cedula = d.Cedula,
                //                     Nombre = d.Nombre,
                //                     Apellido = d.Apellido,
                //                     Direccion = d.Direccion,
                //                     Telefono = d.Telefono,
                //                     Correo = d.Correo,
                //                     Clave = d.Clave,
                //                     Token = d.Token
                //                 }).FirstOrDefault();

                var usuario  = (from d in _context.Clientes
                                             where d.Cedula == "123456789"
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

                Prestamo prestamo = new Prestamo
                {
                    Monto = 10000,
                    FechaInicio = DateTime.Now,
                    Interes = 0.05,
                    Usuario = usuario,
                    ValorGarantias = 5000,
                    Garantias = new List<Garantia> { new Garantia { Tipo = "Propiedad" }, new Garantia { Tipo = "Vehículo" } },
                    Cuotas = new List<CuotaPrestamo> { new CuotaPrestamo { Monto = 1000, FechaPlanificado = DateTime.Now.AddDays(30) } }
                };

                try
                {
                    _context.Prestamos.Add(prestamo);
                    _context.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("error al guardar: " + ex);
                }
                return RedirectToAction("Index");

            }
            else
                return RedirectToAction("Index");
        }

        public IActionResult MyProfile()
        {

            return View(cliente);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}