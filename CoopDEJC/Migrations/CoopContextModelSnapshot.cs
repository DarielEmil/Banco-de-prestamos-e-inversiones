﻿// <auto-generated />
using System;
using CoopDEJC.Models.CoopDBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoopDEJC.Migrations
{
    [DbContext(typeof(CoopContext))]
    partial class CoopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.Cliente", b =>
                {
                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreguntaSeguridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Cedula");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.CuentaBanco", b =>
                {
                    b.Property<string>("NumeroCuenta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreBanco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NumeroCuenta");

                    b.HasIndex("Cedula");

                    b.ToTable("CuentasBanco");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.CuotaInversion", b =>
                {
                    b.Property<int>("CuotaInversionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuotaInversionID"));

                    b.Property<Guid>("Codigo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CuentaID")
                        .HasColumnType("int");

                    b.Property<string>("CuentaNumeroCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaPlanificado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRealizado")
                        .HasColumnType("datetime2");

                    b.Property<int>("InversionID")
                        .HasColumnType("int");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CuotaInversionID");

                    b.HasIndex("CuentaNumeroCuenta");

                    b.HasIndex("InversionID");

                    b.ToTable("CuotasInversiones");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.CuotaPrestamo", b =>
                {
                    b.Property<int>("CuotaPrestamoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuotaPrestamoID"));

                    b.Property<Guid>("Codigo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaPlanificado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRealizado")
                        .HasColumnType("datetime2");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CuotaPrestamoID");

                    b.HasIndex("PrestamoId");

                    b.ToTable("CuotasPrestamos");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.Garantia", b =>
                {
                    b.Property<int>("GarntiaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GarntiaID"));

                    b.Property<int>("PrestamoId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GarntiaID");

                    b.HasIndex("PrestamoId");

                    b.ToTable("Garantias");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.Inversion", b =>
                {
                    b.Property<int>("InversionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InversionID"));

                    b.Property<string>("CedulaCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CuentaID")
                        .HasColumnType("int");

                    b.Property<string>("CuentaNumeroCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Interes")
                        .HasColumnType("int");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioCedula")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("InversionID");

                    b.HasIndex("CuentaNumeroCuenta");

                    b.HasIndex("UsuarioCedula");

                    b.ToTable("Inversiones");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.Prestamo", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrestamoId"));

                    b.Property<string>("ClienteCedula")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CuotasPagadas")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("FiadorCedula")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Interes")
                        .HasColumnType("int");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.Property<int>("ValorGarantias")
                        .HasColumnType("int");

                    b.HasKey("PrestamoId");

                    b.HasIndex("ClienteCedula");

                    b.HasIndex("FiadorCedula");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.CuentaBanco", b =>
                {
                    b.HasOne("CoopDEJC.Models.CoopDBModels.Cliente", "Usuario")
                        .WithMany("Cuentas")
                        .HasForeignKey("Cedula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.CuotaInversion", b =>
                {
                    b.HasOne("CoopDEJC.Models.CoopDBModels.CuentaBanco", "Cuenta")
                        .WithMany()
                        .HasForeignKey("CuentaNumeroCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoopDEJC.Models.CoopDBModels.Inversion", "Inversion")
                        .WithMany("Cuotas")
                        .HasForeignKey("InversionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cuenta");

                    b.Navigation("Inversion");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.CuotaPrestamo", b =>
                {
                    b.HasOne("CoopDEJC.Models.CoopDBModels.Prestamo", "Prestamo")
                        .WithMany("Cuotas")
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.Garantia", b =>
                {
                    b.HasOne("CoopDEJC.Models.CoopDBModels.Prestamo", "Prestamo")
                        .WithMany("Garantias")
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.Inversion", b =>
                {
                    b.HasOne("CoopDEJC.Models.CoopDBModels.CuentaBanco", "Cuenta")
                        .WithMany()
                        .HasForeignKey("CuentaNumeroCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoopDEJC.Models.CoopDBModels.Cliente", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioCedula");

                    b.Navigation("Cuenta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.Prestamo", b =>
                {
                    b.HasOne("CoopDEJC.Models.CoopDBModels.Cliente", "Usuario")
                        .WithMany()
                        .HasForeignKey("ClienteCedula");

                    b.HasOne("CoopDEJC.Models.CoopDBModels.Cliente", "Fiador")
                        .WithMany()
                        .HasForeignKey("FiadorCedula");

                    b.Navigation("Fiador");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.Cliente", b =>
                {
                    b.Navigation("Cuentas");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.Inversion", b =>
                {
                    b.Navigation("Cuotas");
                });

            modelBuilder.Entity("CoopDEJC.Models.CoopDBModels.Prestamo", b =>
                {
                    b.Navigation("Cuotas");

                    b.Navigation("Garantias");
                });
#pragma warning restore 612, 618
        }
    }
}
