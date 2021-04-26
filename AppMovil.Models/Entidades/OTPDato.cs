using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppMovil.Models.Entidades
{
    public class OTPDato
    {
        [Key]
        public int OtpDatoId { get; set; }
        public string Dato { get; set; }
        public string Usuario { get; set; }
    }
}
