using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppMovil.Models.Entidades
{
    public class Servicio
    {
        [Key]
        public int ServicioId { get; set; }
        public string Nombre { get; set; }
        public int LongitudReferencia { get; set; }
        public bool ComisionRubro { get; set; }
        public bool EstaActivo { get; set; }
        public string ServicioConsulta { get; set; }
        public string ServicioPago { get; set; }

        public TipoServicio TipoServicio { get; set; }
        public TipoReferencia TipoReferencia { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}
