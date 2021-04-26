using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMovil.Services.Interfaces;
using ApiMovil.Services.Mensajeria.Entrada;
using ApiMovil.Services.Mensajeria.Salida;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovil.Controllers
{
    [Route("api/[controller]")]
    public class ConsultaController : Controller
    {
        private readonly IPagoServicios _pagoServicios;

        public ConsultaController(IPagoServicios pagoServicios)
        {
            _pagoServicios = pagoServicios;
        }

        [HttpGet]
        [Route("ListaConsultas")]
        public List<ConsultaMS> ListaConsultas()
        {
            return _pagoServicios.ListaConsultas();
        }

        [HttpPost]
        [Route("ListaConsultasPorFecha")]
        public List<ConsultaMS> ListaConsultasPorFecha([FromBody]ConsultaFechaME mensajeEntrada)
        {
            return _pagoServicios.ListaConsultasPorFecha(mensajeEntrada);
        }

        [HttpPost]
        [Route("RealizarConsulta")]
        public Task<ConsultaMS> RealizarConsulta([FromBody]ConsultaME consulta)
        {
            return _pagoServicios.RealizarConsulta(consulta);
        }
    }
}