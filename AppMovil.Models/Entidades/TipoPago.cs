using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppMovil.Models.Entidades
{
    public class TipoPago
    {
        [Key]
        public int TipoPagoId { get; set; }
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
