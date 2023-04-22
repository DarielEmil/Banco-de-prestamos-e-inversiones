using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace CoopDEJC.Models
{
    public class Cliente
    {
        [Key]
        public string Cedula { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
    }
}