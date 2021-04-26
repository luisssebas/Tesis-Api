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
    public class UsuarioController : Controller
    {
        private readonly IPagoServicios _pagoServicios;

        public UsuarioController(IPagoServicios pagoServicios)
        {
            _pagoServicios = pagoServicios;
        }

        [HttpGet]
        [Route("ListaUsuarios")]
        public List<UsuarioMS> ListaUsuarios()
        {
            return _pagoServicios.ListaUsuarios();
        }

        [HttpPost]
        [Route("GuardarUsuario")]
        public bool GuardarServicio([FromBody]UsuarioEditarME usuario)
        {
            return _pagoServicios.GuardarUsuario(usuario);
        }

        [HttpPost]
        [Route("ActualizarUsuario")]
        public bool ActualizarUsuario([FromBody]UsuarioEditarME usuario)
        {
            return _pagoServicios.ActualizarUsuario(usuario);
        }

        [HttpGet]
        [Route("EliminarUsuario/{usuarioId}")]
        public bool EliminarUsuario(int usuarioId)
        {
            return _pagoServicios.EliminarUsuario(usuarioId);
        }

        [HttpPost]
        [Route("ActualizarContraseniaUsuario")]
        public bool ActualizarContraseniaUsuario([FromBody]UsuarioEditarME usuario)
        {
            return _pagoServicios.ActualizarContraseniaUsuario(usuario);
        }

        [HttpPost]
        [Route("LoginUsuario")]
        public LoginMS LoginUsuario([FromBody]LoginME login)
        {
            return _pagoServicios.LoginUsuario(login);
        }

        [HttpGet]
        [Route("EnviarOTP")]
        public bool EnviarOTP(string username)
        {
            return _pagoServicios.EnviarOTP(username);
        }

        [HttpPost]
        [Route("ValidaOTP")]
        public bool ValidaOTP([FromBody]OTPME mensajeEntrada)
        {
            return _pagoServicios.ValidaOTP(mensajeEntrada);
        }
    }
}