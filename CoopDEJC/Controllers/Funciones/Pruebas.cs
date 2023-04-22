using CoopDEJC.Models.CoopDBModels;
using Microsoft.EntityFrameworkCore;

namespace CoopDEJC.Controllers.Funciones
{
    public class Pruebas
    {
        public static void CreacionPrestamos(CoopContext _context)
        {

            var cliente = _context.Clientes.FirstOrDefault(c => c.Cedula == "123456789");

            if (cliente != null)
            {
                // Crear una nueva garantía
                var garantia = new Garantia
                {
                    Tipo = "Vehículo"
                };

                // Crear el préstamo y agregar la garantía
                var prestamo = new Prestamo
                {
                    Monto = 10000,
                    FechaInicio = DateTime.Now,
                    Interes = 0.05,
                    ValorGarantias = 5000,
                    Garantias = new List<Garantia> { garantia }
                };

                // Asignar el cliente existente al préstamo
                prestamo.Usuario = cliente;

                // Agregar el préstamo a la base de datos
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
            }
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

            //var usuario = (from d in _context.Clientes
            //               where d.Cedula == "123456789"
            //               select new Cliente
            //               {
            //                   Cedula = d.Cedula,
            //                   Nombre = d.Nombre,
            //                   Apellido = d.Apellido,
            //                   Direccion = d.Direccion,
            //                   Telefono = d.Telefono,
            //                   Correo = d.Correo,
            //                   Clave = d.Clave,
            //                   Token = d.Token
            //               }).FirstOrDefault();

            //Prestamo prestamo = new Prestamo
            //{
            //    Monto = 10000,
            //    FechaInicio = DateTime.Now,
            //    Interes = 0.05,
            //    u
            //    ValorGarantias = 5000,
            //    Garantias = new List<Garantia> { new Garantia { Tipo = "Propiedad" }, new Garantia { Tipo = "Vehículo" } },
            //    Cuotas = new List<CuotaPrestamo> { new CuotaPrestamo { Monto = 1000, FechaPlanificado = DateTime.Now.AddDays(30) } }
            //};


        }
    }
}
