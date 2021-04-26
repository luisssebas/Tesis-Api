using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppMovil.Models.EntidadesEmpresa
{
    [Table("EstadoCivil", Schema = "Empresa")]
    public class EstadoCivil
    {
        [Key]
        public int Secuencial { get; set; }
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
