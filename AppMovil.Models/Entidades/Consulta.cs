using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppMovil.Models.Entidades
{
    public class Consulta
    {
        [Key]
        public int ConsultaId { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Descripcion { get; set; }
        public string Referencia { get; set; }

        public Usuario Usuario { get; set; }
        public Servicio Servicio { get; set; }
    }
}
