using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Salida
{
    public class TipoServicioMS
    {
        public int TipoServicioId { get; set; }
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
