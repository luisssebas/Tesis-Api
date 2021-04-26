using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppMovil.Models.Entidades
{
    public class ServicioUsuario
    {
        [Key]
        public int ServicioUsuarioId { get; set; }
        public Servicio Servicio { get; set; }
        public Usuario Usuario { get; set; }
        public string Contrapartida { get; set; }
        public bool EstaActivo { get; set; }
    }
}
