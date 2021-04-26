using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppMovil.Models.EntidadesEmpresa
{
    [Table("TipoIdentificacion", Schema = "Empresa")]
    public class TipoIdentificacion
    {
        [Key]
        public int Secuencial { get; set; }
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
