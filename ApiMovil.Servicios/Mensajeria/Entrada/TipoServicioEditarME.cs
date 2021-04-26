using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Entrada
{
    public class TipoServicioEditarME
    {
        public int TipoServicioId { get; set; }
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
