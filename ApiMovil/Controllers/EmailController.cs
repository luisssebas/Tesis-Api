using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMovil.Services.Interfaces;
using ApiMovil.Services.Mensajeria.Entrada;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovil.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IPagoServicios _pagoServicios;

        public EmailController(IPagoServicios pagoServicios)
        {
            _pagoServicios = pagoServicios;
        }

        [HttpGet]
        [Route("EnviarMail")]
        public bool EnviarMail([FromBody]EmailME mensajeEntrada)
        {
            return _pagoServicios.EnviaEmail(mensajeEntrada);
        }
    }
}