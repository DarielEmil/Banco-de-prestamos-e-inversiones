using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopDEJC.Models
{
    public class DBModel : DbContext
    {
        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<CuentaBanco> CuentasBanco { get; set;}
        public DbSet<Prestamo> Prestamos { get;set;}
        public DbSet<Garantia> Garantias { get; set;}

    }

    public class Cliente
    {
        [Key]
        public string Cedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string PreguntaSeguridad { get; set; } = string.Empty;

        public Guid Token { get; set; } = new Guid();

        public List<CuentaBanco>Cuentas {get; set; } = new List<CuentaBanco>();

    }

    public class CuentaBanco
    {
        [Key]
        public string NumeroCuenta { get; set; } = string.Empty;
        public string NombreBanco { get; set; } = string.Empty;
        public string TipoCuenta { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;

        [ForeignKey("Cedula")]
        public Cliente Usuario { get; set; } = new Cliente();
    }

    public class Prestamo
    {
        //Campos de la tabla Prestamo
        [Key]
        public int PrestamoId { get; set; }
        public int Monto { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime FechaFin { get; set; } = new DateTime();
        public int Interes { get; set; }
        
        //Union con la tabla clientes para el usuario
        public string? CedulaCliente { get; set; } = string.Empty;
        public Cliente Usuario { get; set; } = new Cliente();

        //Union con la tabla clientes para el fiador
        public string? CedulaFiador { get; set; } = string.Empty;
        public Cliente Fiador { get; set; } = new Cliente();

        //Union con la tabla Garantias
        [ForeignKey("GarantiaID")]
        public int GarantiaID { get; set; }
        public Garantia Garantia { get; set; } = new Garantia();
    }

    public class Garantia
    {
        [Key]
        public int GarntiaID { get; set; }
        public string Tipo { get;set; } = string.Empty;

    }


}
