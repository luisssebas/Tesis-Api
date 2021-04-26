﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Salida
{
    public class ConsultaMS
    {
        public int ConsultaId { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Descripcion { get; set; }
        public string Referencia { get; set; }
        public int UsuarioId { get; set; }
        public int ServicioId { get; set; }
        public string NumeroFactura { get; set; }
        public string Empresa { get; set; }
        public string PeriodoFactura { get; set; }
        public List<RubrosMS> Rubros { get; set; }
    }
}