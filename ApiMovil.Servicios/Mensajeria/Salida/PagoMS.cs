using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Salida
{
    public class PagoMS
    {
        public int ServicioId { get; set; }
        public int ConsultaId { get; set; }
        public string Documento { get; set; }
        public string IdPasarelaPago { get; set; }
        public double ValorPagado { get; set; }
        public DateTime FechaPago { get; set; }
        public List<RubrosMS> Rubros { get; set; }
    }
}
