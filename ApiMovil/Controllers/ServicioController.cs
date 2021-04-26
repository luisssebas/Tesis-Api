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
    public class ServicioController : Controller
    {
        private readonly IPagoServicios _pagoServicios;

        public ServicioController(IPagoServicios pagoServicios)
        {
            _pagoServicios = pagoServicios;
        }

        [HttpGet]
        [Route("ListaServicios")]
        public List<ServicioMS> ListaServicios()
        {
            return _pagoServicios.ListaServicios();
        }

        [HttpPost]
        [Route("GuardarServicio")]
        public bool GuardarServicio([FromBody]ServicioEditarME servicio)
        {
            return _pagoServicios.GuardarServicio(servicio);
        }

        [HttpPost]
        [Route("ActualizarServicio")]
        public bool ActualizarServicio([FromBody]ServicioEditarME servicio)
        {
            return _pagoServicios.ActualizarServicio(servicio);
        }

        [HttpGet]
        [Route("EliminarServicio/{servicioId}")]
        public bool EliminarServicio(int servicioId)
        {
            return _pagoServicios.EliminarServicio(servicioId);
        }
    }
}