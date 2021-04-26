using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppMovil.Models.EntidadesEmpresa
{
    [Table("Persona", Schema = "Empresa")]
    public class Persona
    {
        [Key]
        public int Secuencial { get; set; }
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string TelefonoConvencional { get; set; }
        public string TelefonoCelular { get; set; }
        public bool EstaActivo { get; set; }

        public TipoIdentificacion TipoIdentificacion { get; set; }
        public DivisionPolitica DivisionPolitica { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
    }
}
