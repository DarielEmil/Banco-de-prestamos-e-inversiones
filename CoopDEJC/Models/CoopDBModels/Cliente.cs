using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoopDEJC.Models.CoopDBModels
{
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

        public List<CuentaBanco> Cuentas { get; set; } = new List<CuentaBanco>();

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
}
