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
    public class ParametrizacionController : Controller
    {
        private readonly IPagoServicios _pagoServicios;

        public ParametrizacionController(IPagoServicios pagoServicios)
        {
            _pagoServicios = pagoServicios;
        }

        [HttpGet]
        [Route("ListaParametrizacion")]
        public List<ParametrizacionMS> ListaParametrizacion()
        {
            return _pagoServicios.ListaParametrizacion();
        }

        [HttpPost]
        [Route("GuardarParametrizacion")]
        public bool GuardarParametrizacion([FromBody]ParametrizacionME parametrizacion)
        {
            return _pagoServicios.GuardarParametrizacion(parametrizacion);
        }

        [HttpPost]
        [Route("ActualizarParametrizacion")]
        public bool ActualizarParametrizacion([FromBody]ParametrizacionME parametrizacion)
        {
            return _pagoServicios.ActualizarParametrizacion(parametrizacion);
        }
    }
}