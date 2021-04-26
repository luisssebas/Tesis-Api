using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Entrada
{
    public class UsuarioEditarME
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool EsAdmin { get; set; }
        public bool EstaActivo { get; set; }
    }
}
