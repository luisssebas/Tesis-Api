using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppMovil.Models.Entidades
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }
        public string Documento { get; set; }
        public double ValorPagado { get; set; }
        public string IdPasarelaPago { get; set; }
        public DateTime FechaPago { get; set; }

        public Servicio Servicio { get; set; }
        public Consulta Consulta { get; set; }
        public Usuario Usuario { get; set; }
    }
}
