using CoopDEJC.Models.CoopDBModels;

namespace CoopDEJC.Models
{
    public class IndexModel
    {
        public string Name { get; set; }
        public Double Investment { get; set; }
        public int Debts { get; set; }
        public int Inverted { get ; set; }
        public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public List<Inversion> Inversiones { get; set; } = new List<Inversion>();
    }
}
