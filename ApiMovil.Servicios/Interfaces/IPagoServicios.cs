using ApiMovil.Services.Mensajeria.Entrada;
using ApiMovil.Services.Mensajeria.Salida;
using AppMovil.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiMovil.Services.Interfaces
{
    public interface IPagoServicios
    {
        #region TipoServicio
        List<TipoServicioMS> ListaTipoServicios();
        bool GuardarTipoServicio(TipoServicioEditarME servicioME);
        bool ActualizarTipoServicio(TipoServicioEditarME servicioME);
        bool EliminarTipoServicio(int servicioId);
        #endregion

        #region Servicio
        List<ServicioMS> ListaServicios();
        bool GuardarServicio(ServicioEditarME servicioEditarME);
        bool ActualizarServicio(ServicioEditarME servicioEditarME);
        bool EliminarServicio(int servicioId);
        #endregion

        #region TipoReferencia
        List<TipoReferenciaMS> ListaTipoReferencias();
        bool GuardarTipoReferencia(TipoReferenciaEditarME tipoReferenciaME);
        bool ActualizarTipoReferencia(TipoReferenciaEditarME tipoReferenciaME);
        bool EliminarTipoReferencia(int tipoReferenciaId);
        #endregion

        #region TipoPago
        List<TipoPagoMS> ListaTipoPagos();
        bool GuardarTipoPago(TipoPagoEditarME tipoPagoME);
        bool ActualizarTipoPago(TipoPagoEditarME tipoPagoEditarME);
        bool EliminarTipoPago(int tipoPagoId);
        #endregion

        #region Usuario
        List<UsuarioMS> ListaUsuarios();
        bool GuardarUsuario(UsuarioEditarME usuarioEditarME);
        bool ActualizarUsuario(UsuarioEditarME usuarioEditarME);
        bool EliminarUsuario(int usuarioId);
        bool ActualizarContraseniaUsuario(UsuarioEditarME usuarioEditarME);
        LoginMS LoginUsuario(LoginME loginME);
        #endregion

        #region Parametrizacion
        List<ParametrizacionMS> ListaParametrizacion();
        bool GuardarParametrizacion(ParametrizacionME usuarioEditarME);
        bool ActualizarParametrizacion(ParametrizacionME usuarioEditarME);
        #endregion

        #region Consulta
        List<ConsultaMS> ListaConsultas();
        bool GuardarConsulta(ConsultaME consultaME);
        Task<ConsultaMS> RealizarConsulta(ConsultaME consultaME);
        List<ConsultaMS> ListaConsultasPorFecha(ConsultaFechaME mensajeEntrada);
        #endregion

        #region ServicioUsuario
        List<ServicioUsuarioMS> ListaServiciosUsuarios(int usuarioId);
        bool GuardarServicioUsuario(ServicioUsuarioME servicioUsuarioME);
        bool ActualizarServicioUsuario(ServicioUsuarioME servicioUsuarioME);
        bool EliminarServicioUsuario(int servicioUsuarioId);
        #endregion

        #region Email
        bool EnviaEmail(EmailME mensajeEntrada);
        #endregion

        #region OTP
        bool EnviarOTP(string username);
        bool ValidaOTP(OTPME mensajeEntrada);
        #endregion

        #region Pago
        List<PagoMS> ListaPagoFechas(ConsultaFechaME mensajeEntrada);
        List<PagoMS> ListaPago();
        Task<PagoMS> RealizarPago(PagoME mensajeEntrada);
        #endregion
    }
}
