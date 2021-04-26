using ApiMovil.Services.Mensajeria.Salida;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Entrada
{
    public class PagoServicioME
    {
        public string Contrapartida { get; set; }
        public List<RubrosMS> Rubros { get; set; }
    }
}
