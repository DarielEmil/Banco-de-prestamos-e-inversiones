using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoopDEJC.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "CuentasBanco",
                columns: table => new
                {
                    NumeroCuenta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreBanco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasBanco", x => x.NumeroCuenta);
                    table.ForeignKey(
                        name: "FK_CuentasBanco_Clientes_Cedula",
                        column: x => x.Cedula,
                        principalTable: "Clientes",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interes = table.Column<double>(type: "float", nullable: false),
                    ClienteCedula = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FiadorCedula = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ValorGarantias = table.Column<int>(type: "int", nullable: false),
                    CuotasPagadas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Clientes_ClienteCedula",
                        column: x => x.ClienteCedula,
                        principalTable: "Clientes",
                        principalColumn: "Cedula");
                    table.ForeignKey(
                        name: "FK_Prestamos_Clientes_FiadorCedula",
                        column: x => x.FiadorCedula,
                        principalTable: "Clientes",
                        principalColumn: "Cedula");
                });

            migrationBuilder.CreateTable(
                name: "Inversiones",
                columns: table => new
                {
                    InversionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Interes = table.Column<double>(type: "float", nullable: false),
                    CedulaCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCedula = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CuentaID = table.Column<int>(type: "int", nullable: false),
                    CuentaNumeroCuenta = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inversiones", x => x.InversionID);
                    table.ForeignKey(
                        name: "FK_Inversiones_Clientes_UsuarioCedula",
                        column: x => x.UsuarioCedula,
                        principalTable: "Clientes",
                        principalColumn: "Cedula");
                    table.ForeignKey(
                        name: "FK_Inversiones_CuentasBanco_CuentaNumeroCuenta",
                        column: x => x.CuentaNumeroCuenta,
                        principalTable: "CuentasBanco",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuotasPrestamos",
                columns: table => new
                {
                    CuotaPrestamoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    FechaPlanificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRealizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModalidadPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotasPrestamos", x => x.CuotaPrestamoID);
                    table.ForeignKey(
                        name: "FK_CuotasPrestamos_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garantias",
                columns: table => new
                {
                    GarntiaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garantias", x => x.GarntiaID);
                    table.ForeignKey(
                        name: "FK_Garantias_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuotasInversiones",
                columns: table => new
                {
                    CuotaInversionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    FechaPlanificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRealizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InversionID = table.Column<int>(type: "int", nullable: false),
                    CuentaID = table.Column<int>(type: "int", nullable: false),
                    CuentaNumeroCuenta = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotasInversiones", x => x.CuotaInversionID);
                    table.ForeignKey(
                        name: "FK_CuotasInversiones_CuentasBanco_CuentaNumeroCuenta",
                        column: x => x.CuentaNumeroCuenta,
                        principalTable: "CuentasBanco",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuotasInversiones_Inversiones_InversionID",
                        column: x => x.InversionID,
                        principalTable: "Inversiones",
                        principalColumn: "InversionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentasBanco_Cedula",
                table: "CuentasBanco",
                column: "Cedula");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasInversiones_CuentaNumeroCuenta",
                table: "CuotasInversiones",
                column: "CuentaNumeroCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasInversiones_InversionID",
                table: "CuotasInversiones",
                column: "InversionID");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasPrestamos_PrestamoId",
                table: "CuotasPrestamos",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Garantias_PrestamoId",
                table: "Garantias",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inversiones_CuentaNumeroCuenta",
                table: "Inversiones",
                column: "CuentaNumeroCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Inversiones_UsuarioCedula",
                table: "Inversiones",
                column: "UsuarioCedula");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_ClienteCedula",
                table: "Prestamos",
                column: "ClienteCedula");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_FiadorCedula",
                table: "Prestamos",
                column: "FiadorCedula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuotasInversiones");

            migrationBuilder.DropTable(
                name: "CuotasPrestamos");

            migrationBuilder.DropTable(
                name: "Garantias");

            migrationBuilder.DropTable(
                name: "Inversiones");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "CuentasBanco");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
