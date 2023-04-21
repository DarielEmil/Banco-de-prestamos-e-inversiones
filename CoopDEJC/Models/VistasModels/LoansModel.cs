using CoopDEJC.Models.CoopDBModels;

namespace CoopDEJC.Models.VistasModels
{
    public class LoansModel
    {
       public string Name { get; set; }
       public int TotalLoads { get; set; } 
       public int Paid { get; set; }
       public int Pending { get; set; }
       public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}
