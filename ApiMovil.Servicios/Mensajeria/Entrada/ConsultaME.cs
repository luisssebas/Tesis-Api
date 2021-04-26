﻿using ApiMovil.Services.Mensajeria.Salida;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMovil.Services.Mensajeria.Entrada
{
    public class ConsultaME
    {
        public int ConsultaId { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Descripcion { get; set; }
        public string Referencia { get; set; }
        public int UsuarioId { get; set; }
        public int ServicioId { get; set; }
    }
}
