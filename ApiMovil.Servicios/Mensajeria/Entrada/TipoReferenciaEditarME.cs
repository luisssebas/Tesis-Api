using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Entrada
{
    public class TipoReferenciaEditarME
    {
        public int TipoReferenciaId { get; set; }
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
