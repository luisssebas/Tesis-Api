using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppMovil.Models.Entidades
{
    public class TipoReferencia
    {
        [Key]
        public int TipoReferenciaId { get; set; }
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
