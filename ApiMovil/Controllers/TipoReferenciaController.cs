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
    public class TipoReferenciaController : Controller
    {
        private readonly IPagoServicios _pagoServicios;

        public TipoReferenciaController(IPagoServicios pagoServicios)
        {
            _pagoServicios = pagoServicios;
        }

        [HttpGet]
        [Route("ListaTipoReferencias")]
        public List<TipoReferenciaMS> ListaTipoReferencias()
        {
            return _pagoServicios.ListaTipoReferencias();
        }

        [HttpPost]
        [Route("GuardarTipoReferencia")]
        public bool GuardarTipoReferencia([FromBody]TipoReferenciaEditarME tipoReferencia)
        {
            return _pagoServicios.GuardarTipoReferencia(tipoReferencia);
        }

        [HttpPost]
        [Route("ActualizarTipoReferencia")]
        public bool ActualizarTipoReferencia([FromBody]TipoReferenciaEditarME tipoReferencia)
        {
            return _pagoServicios.ActualizarTipoReferencia(tipoReferencia);
        }

        [HttpGet]
        [Route("EliminarTipoReferencia/{tipoReferenciaId}")]
        public bool EliminarTipoReferencia(int tipoReferenciaId)
        {
            return _pagoServicios.EliminarTipoReferencia(tipoReferenciaId);
        }
    }
}