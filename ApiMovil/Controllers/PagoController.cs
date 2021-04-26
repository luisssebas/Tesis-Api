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
    public class PagoController : Controller
    {
        private readonly IPagoServicios _pagoServicios;

        public PagoController(IPagoServicios pagoServicios)
        {
            _pagoServicios = pagoServicios;
        }

        [HttpPost]
        [Route("RealizarPago")]
        public async Task<PagoMS> RealizarPago([FromBody]PagoME mensajeEntrada)
        {
            return await _pagoServicios.RealizarPago(mensajeEntrada);
        }
        
        [HttpGet]
        [Route("ListaPago")]
        public List<PagoMS> ListaPago()
        {
            return _pagoServicios.ListaPago();
        }
        
        [HttpPost]
        [Route("ListaPagoFechas")]
        public List<PagoMS> ListaPagoFechas([FromBody]ConsultaFechaME mensajeEntrada)
        {
            return _pagoServicios.ListaPagoFechas(mensajeEntrada);
        }
    }
}