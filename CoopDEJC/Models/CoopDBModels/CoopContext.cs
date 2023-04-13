using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace CoopDEJC.Models.CoopDBModels
{
    public class CoopContext : DbContext
    {
        public CoopContext(DbContextOptions<CoopContext> options)
        : base(options)
        {

        }

        //Tablas
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CuentaBanco> CuentasBanco { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Garantia> Garantias { get; set; }
        public DbSet<CuotaPrestamo> CuotasPrestamos { get; set; }
        public DbSet<Inversion> Inversiones { get; set; }
        public DbSet<CuotaInversion> CuotasInversiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inversion>()
                .HasMany(c => c.Cuotas)
                .WithOne(e => e.Inversion)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
