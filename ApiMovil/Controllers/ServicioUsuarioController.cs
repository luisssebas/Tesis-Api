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
    public class ServicioUsuarioController : Controller
    {
        private readonly IPagoServicios _pagoServicios;

        public ServicioUsuarioController(IPagoServicios pagoServicios)
        {
            _pagoServicios = pagoServicios;
        }

        [HttpGet]
        [Route("ListaServicioUsuario/{servicioUsuarioId}")]
        public List<ServicioUsuarioMS> ListaConsultas(int servicioUsuarioId)
        {
            return _pagoServicios.ListaServiciosUsuarios(servicioUsuarioId);
        }

        [HttpPost]
        [Route("GuardarServicioUsuario")]
        public bool GuardarServicioUsuario([FromBody]ServicioUsuarioME mensajeEntrada)
        {
            return _pagoServicios.GuardarServicioUsuario(mensajeEntrada);
        }

        [HttpPost]
        [Route("ActualizarServicioUsuario")]
        public bool ActualizarServicioUsuario([FromBody]ServicioUsuarioME mensajeEntrada)
        {
            return _pagoServicios.ActualizarServicioUsuario(mensajeEntrada);
        }

        [HttpGet]
        [Route("EliminarServicioUsuario/{servicioUsuarioId}")]
        public bool EliminarServicioUsuario(int servicioUsuarioId)
        {
            return _pagoServicios.EliminarServicioUsuario(servicioUsuarioId);
        }
    }
}