using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Salida
{
    public class TipoPagoMS
    {
        public int TipoPagoId { get; set; }
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
