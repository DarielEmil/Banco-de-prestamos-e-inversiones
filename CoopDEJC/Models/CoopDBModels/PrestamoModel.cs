using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoopDEJC.Models.CoopDBModels
{
    public class Prestamo
    {
        //Campos de la tabla Prestamos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrestamoId { get; set; }
        public int Monto { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime FechaFin { get; set; } = new DateTime();
        public int Interes { get; set; }

        //Union con la tabla clientes para el usuario
        [ForeignKey("CedulaCliente")]
        public string CedulaCliente { get; set; } = string.Empty;
        public Cliente Usuario { get; set; } = new Cliente();

        //Union con la tabla clientes para el fiador
        [ForeignKey("CedulaFiador")]
        public string? CedulaFiador { get; set; } = string.Empty;
        public Cliente Fiador { get; set; } = new Cliente();

        //Union con la tabla Garantias
        [ForeignKey("GarantiaID")]
        public int GarantiaID { get; set; }
        public Garantia Garantia { get; set; } = new Garantia();

        //Union con la tabla CuotasPrestamos
        [ForeignKey("CuotaPrestamoID")]
        public int CuotaPrestamoID { get; set; }
        public List<CuotaPrestamo> Cuotas { get; set; } = new List<CuotaPrestamo>();

    }

    public class Garantia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GarntiaID { get; set; }
        public string Tipo { get; set; } = string.Empty;

    }
    public class CuotaPrestamo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CuotaPrestamoID { get; set; }
        public int Monto { get; set; }
        public DateTime FechaPlanificado { get; set; } = new DateTime();
        public DateTime FechaRealizado { get; set; } = DateTime.Now;
        public string Tipo { get; set; } = string.Empty;
        public Guid Codigo { get; set; } = new Guid();
    }
}
