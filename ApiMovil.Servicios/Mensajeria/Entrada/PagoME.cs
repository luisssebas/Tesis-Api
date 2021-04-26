using ApiMovil.Services.Mensajeria.Salida;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Entrada
{
    public class PagoME
    {
        public int PagoId { get; set; }
        public int ServicioId { get; set; }
        public int ConsultaId { get; set; }
        public int UsuarioId { get; set; }
        public double ValorPagado { get; set; }
        public string IdPasarelaPago { get; set; }
        public List<RubrosMS> Rubros { get; set; }
    }
}
