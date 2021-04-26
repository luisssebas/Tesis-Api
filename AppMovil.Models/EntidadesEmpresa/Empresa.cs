using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppMovil.Models.EntidadesEmpresa
{
    [Table("Empresa", Schema = "Empresa")]
    public class Empresa
    {
        [Key]
        public int Secuencial { get; set; }
        public string RUC { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }
        public string Alias { get; set; }
        public string Direccion { get; set; }
        public bool EstaActivo { get; set; }
    }
}
