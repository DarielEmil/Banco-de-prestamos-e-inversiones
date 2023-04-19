using CoopDEJC.Models;
using CoopDEJC.Models.CoopDBModels;
using Cliente = CoopDEJC.Models.CoopDBModels.Cliente;

namespace CoopDEJC.Controllers.Funciones
{
    public class IndexFunciones
    {
        public static IndexModel LlenadoIndex(Cliente cliente, CoopContext _context)
        {

            IndexModel imodel = new IndexModel();
            int deuda = 0, invertido = 0;
            double rentabilidad = 0;

            //Listado de Prestamos 
            var prestamos = (from d in _context.Prestamos
                             where d.Usuario == cliente
                             select d).ToList();

            if(prestamos != null && prestamos.Count > 0)
            {
                foreach (var prestamo in prestamos)
                {
                    imodel.Prestamos.Add(prestamo);
                    deuda += prestamo.Monto;
                    Console.WriteLine(deuda);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No hay Prestamos o error");
            }

            //Listado de Inversiones 
            var inversiones = (from d in _context.Inversiones
                             where d.Usuario == cliente
                             select d).ToList();

            if (inversiones != null && inversiones.Count > 0)
            {
                foreach (var inversion in inversiones)
                {
                    imodel.Inversiones.Add(inversion);
                    rentabilidad += inversion.Monto * inversion.Interes;
                    invertido += inversion.Monto;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No hay Inversiones o error");
            }

            imodel.Debts = deuda;
            imodel.Inverted = invertido;
            imodel.Investment = rentabilidad;

            return imodel;

        }
    }
}
