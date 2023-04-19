using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public double Interes { get; set; }

        //Union con la tabla clientes para el usuario
        [ForeignKey("ClienteCedula")]
        public Cliente Usuario { get; set; } = new Cliente();

        //Union con la tabla clientes para el fiador
        [ForeignKey("FiadorCedula")]
        public Cliente? Fiador { get; set; } = new Cliente();

        public int ValorGarantias { get; set; }
        public List<Garantia> Garantias { get; set; } = new List<Garantia>();

        public int CuotasPagadas { get; set; } = 0;
        public List<CuotaPrestamo> Cuotas { get; set; } = new List<CuotaPrestamo>();
    }

    public class Garantia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GarntiaID { get; set; }
        public string Tipo { get; set; } = string.Empty;

        //Union con la tabla Garantias
        [ForeignKey("PrestamoId")]
        public Prestamo Prestamo { get; set; } = new Prestamo();
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

        //Union con la tabla Prestamos
        [ForeignKey("PrestamoId")]
        public int PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; } = new Prestamo();

    }
}