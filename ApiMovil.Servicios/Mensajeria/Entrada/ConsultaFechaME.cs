using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Entrada
{
    public class ConsultaFechaME
    {
        public int UsuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
