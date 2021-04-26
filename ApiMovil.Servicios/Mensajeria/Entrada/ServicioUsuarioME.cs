using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Entrada
{
    public class ServicioUsuarioME
    {
        public int ServicioUsuarioId { get; set; }
        public int ServicioId { get; set; }
        public int UsuarioId { get; set; }
        public string Contrapartida { get; set; }
        public bool EstaActivo { get; set; }
    }
}
