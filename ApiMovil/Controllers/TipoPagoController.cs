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
    public class TipoPagoController : Controller
    {
        private readonly IPagoServicios _pagoServicios;

        public TipoPagoController(IPagoServicios pagoServicios)
        {
            _pagoServicios = pagoServicios;
        }

        [HttpGet]
        [Route("ListaTipoPagos")]
        public List<TipoPagoMS> ListaTipoPagos()
        {
            return _pagoServicios.ListaTipoPagos();
        }

        [HttpPost]
        [Route("GuardarTipoPago")]
        public bool GuardarServicio([FromBody]TipoPagoEditarME tipoPago)
        {
            return _pagoServicios.GuardarTipoPago(tipoPago);
        }

        [HttpPost]
        [Route("ActualizarTipoPago")]
        public bool ActualizarServicio([FromBody]TipoPagoEditarME tipoPago)
        {
            return _pagoServicios.ActualizarTipoPago(tipoPago);
        }

        [HttpGet]
        [Route("EliminarTipoPago/{tipoPagoId}")]
        public bool EliminarServicio(int tipoPagoId)
        {
            return _pagoServicios.EliminarTipoPago(tipoPagoId);
        }
    }
}