using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppMovil.Models.EntidadesEmpresa
{
    [Table("Rubro", Schema = "Empresa")]
    public class Rubros
    {
        [Key]
        public int Secuencial { get; set; }
        public int Prioridad { get; set; }
        public double ValorAPagar { get; set; }
        public string Periodo { get; set; }

        public InformacionPago InformacionPago { get; set; }
    }
}
