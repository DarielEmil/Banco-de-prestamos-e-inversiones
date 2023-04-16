


namespace CoopDEJC.Login
{
    public class User
    {
        public string Correo { get; set; } = string.Empty;

        public string Clave { get; set; } = string.Empty;

        public Guid Token { get; set; } = new Guid();


    }
}
