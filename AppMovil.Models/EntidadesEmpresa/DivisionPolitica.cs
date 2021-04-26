using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppMovil.Models.EntidadesEmpresa
{
    [Table("DivisionPolitica", Schema = "Empresa")]
    public class DivisionPolitica
    {
        [Key]
        public int Secuencial { get; set; }
        public int SecuencialPadre { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
