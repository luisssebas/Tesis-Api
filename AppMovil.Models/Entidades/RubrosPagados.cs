using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppMovil.Models.Entidades
{
    public class RubrosPagados
    {
        [Key]
        public int RubrosPagadosId { get; set; }
        public int Prioridad { get; set; }
        public double ValorAPagar { get; set; }
        public string Periodo { get; set; }
        public string Descripcion { get; set; }
        public Pago Pago { get; set; }
    }
}
