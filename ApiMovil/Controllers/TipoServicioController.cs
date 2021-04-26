using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMovil.Services.Interfaces;
using ApiMovil.Services.Mensajeria.Entrada;
using ApiMovil.Services.Mensajeria.Salida;
using AppMovil.Models.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovil.Controllers
{
    [Route("api/[controller]")]
    public class TipoServicioController : Controller
    {
        private readonly IPagoServicios _pagoServicios;

        public TipoServicioController(IPagoServicios pagoServicios)
        {
            _pagoServicios = pagoServicios;
        }

        [HttpGet]
        [Route("ListaTipoServicios")]
        public List<TipoServicioMS> ListaTipoServicios()
        {
            return _pagoServicios.ListaTipoServicios();
        }

        [HttpPost]
        [Route("GuardarTipoServicio")]
        public bool GuardarTipoServicio([FromBody]TipoServicioEditarME tipoServicio)
        {
            return _pagoServicios.GuardarTipoServicio(tipoServicio);
        }

        [HttpPost]
        [Route("ActualizarTipoServicio")]
        public bool ActualizarTipoServicio([FromBody]TipoServicioEditarME tipoServicio)
        {
            return _pagoServicios.ActualizarTipoServicio(tipoServicio);
        }

        [HttpGet]
        [Route("EliminarTipoServicio/{tipoServicioId}")]
        public bool EliminarTipoServicio(int tipoServicioId)
        {
            return _pagoServicios.EliminarTipoServicio(tipoServicioId);
        }
    }
}