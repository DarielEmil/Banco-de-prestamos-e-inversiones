using CoopDEJC.Models.CoopDBModels;

namespace CoopDEJC.Models
{
    public class IndexModel
    {
        public Double Investment { get; set; }
        public int Debts { get; set; }
        public int Inverted { get ; set; }
        public List<Prestamo>? Prestamos { get; set; }
        public List<Inversion>? Inveriones { get; set; }
    }
}
