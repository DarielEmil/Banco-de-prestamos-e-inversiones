﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoopDEJC.Models.CoopDBModels
{
    public class Inversion
    {
        //Campos de la tabla Inversiones
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InversionID { get; set; }
        public int Monto { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime FechaFin { get; set; } = new DateTime();
        public int Interes { get; set; }

        //Union con la tabla clientes para el usuario
        [ForeignKey("CedulaCliente")]
        public string CedulaCliente { get; set; } = string.Empty;
        public Cliente Usuario { get; set; } = new Cliente();

        //Union con la tabla Cuotas
        [ForeignKey("CuotaId")]
        public int CuotaID { get; set; }
        public List<CuotaInversion> Cuotas { get; set; } = new List<CuotaInversion>();
        
        //Union con la tabla cuentas
        [ForeignKey("CuentaID")]
        public int CuentaID { get; set; }
        public CuentaBanco Cuenta { get; set; } = new CuentaBanco();
    }

    public class CuotaInversion
    {
        //Campos de la tabla CuotasInversiones
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CuotaInversionID { get; set; }
        public int Monto { get; set; }
        public DateTime FechaPlanificado { get; set; } = new DateTime();
        public DateTime FechaRealizado { get; set; } = DateTime.Now;
        public string Tipo { get; set; } = string.Empty;
        public Guid Codigo { get; set; } = new Guid();

        //Union con la tabla cuentas
        [ForeignKey("CuentaID")]
        public int CuentaID { get; set; }
        public CuentaBanco Cuenta {get; set;} = new CuentaBanco();

    }
}