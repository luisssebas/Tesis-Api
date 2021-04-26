using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppMovil.Models.EntidadesEmpresa
{
    [Table("InformacionPago", Schema = "Empresa")]
    public class InformacionPago
    {
        [Key]
        public int Secuencial { get; set; }
        public string NumeroFactura { get; set; }
        public string PeriodoFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double ValorFactura { get; set; }
        public double ValorPendiente { get; set; }
        public string Descripcion { get; set; }
        public string Referencia { get; set; }
        public bool Pendiente { get; set; }

        public Empresa Empresa { get; set; }
        public Persona Persona { get; set; }
    }
}
