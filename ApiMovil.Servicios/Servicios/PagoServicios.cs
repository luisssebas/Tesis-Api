using ApiMovil.Services.Interfaces;
using ApiMovil.Services.Mensajeria.Entrada;
using ApiMovil.Services.Mensajeria.Salida;
using AppMovil.Models.Context;
using AppMovil.Models.Entidades;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using MimeKit;
using MailKit.Net.Smtp;
using OtpNet;
using BCrypt.Net;

namespace ApiMovil.Services.Servicios
{
    public class PagoServicios : IPagoServicios
    {
        private readonly ServicioContext _context;

        private List<Totp> listaOtp { get; set; }

        public PagoServicios(ServicioContext context)
        {
            _context = context;

            listaOtp = new List<Totp>();
        }

        #region TipoServicio
        public List<TipoServicioMS> ListaTipoServicios()
        {
            try
            {
                var servicio = _context.TipoServicio.ToList();

                List<TipoServicioMS> tipoServicios = new List<TipoServicioMS>();

                foreach (var item in servicio)
                {
                    TipoServicioMS Dato = new TipoServicioMS()
                    {
                        TipoServicioId = item.TipoServicioId,
                        Nombre = item.Nombre,
                        EstaActivo = item.EstaActivo
                    };

                    tipoServicios.Add(Dato);
                }

                return tipoServicios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardarTipoServicio(TipoServicioEditarME tipoServicioME)
        {
            try
            {
                TipoServicio tipoServicio = new TipoServicio()
                {
                    Nombre = tipoServicioME.Nombre,
                    EstaActivo = tipoServicioME.EstaActivo,
                };

                this._context.TipoServicio.Add(tipoServicio);
                this._context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool ActualizarTipoServicio(TipoServicioEditarME tipoServicioME)
        {
            try
            {
                var tipoServicio = this._context.TipoServicio.Find(tipoServicioME.TipoServicioId);

                tipoServicio.EstaActivo = tipoServicioME.EstaActivo;
                tipoServicio.Nombre = tipoServicioME.Nombre;

                this._context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool EliminarTipoServicio(int tipoServicioId)
        {
            try
            {
                var TipoServicio = this._context.TipoServicio.Find(tipoServicioId);

                TipoServicio.EstaActivo = false;

                this._context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        #endregion

        #region Servicio
        public List<ServicioMS> ListaServicios()
        {
            try
            {
                var servicio = (from serv in _context.Servicio
                                join tpp in _context.TipoPago on serv.TipoPago.TipoPagoId equals tpp.TipoPagoId
                                join tpr in _context.TipoReferencia on serv.TipoReferencia.TipoReferenciaId equals tpr.TipoReferenciaId
                                join tps in _context.TipoServicio on serv.TipoServicio.TipoServicioId equals tps.TipoServicioId
                                select new 
                                {
                                    serv.ServicioId,
                                    tpr.TipoReferenciaId,
                                    tpp.TipoPagoId,
                                    tps.TipoServicioId,
                                    serv.Nombre,
                                    serv.LongitudReferencia,
                                    serv.ComisionRubro,
                                    serv.EstaActivo,
                                    serv.ServicioConsulta,
                                    serv.ServicioPago
                                }).ToList();

                List<ServicioMS> servicios = new List<ServicioMS>();

                foreach (var item in servicio)
                {
                    ServicioMS Dato = new ServicioMS()
                    {
                        ServicioId = item.ServicioId,
                        Nombre = item.Nombre,
                        ComisionRubro = item.ComisionRubro,
                        TipoReferenciaId = item.TipoReferenciaId,
                        EstaActivo = item.EstaActivo,
                        LongitudReferencia = item.LongitudReferencia,
                        TipoPagoId = item.TipoPagoId,
                        TipoServicioId = item.TipoServicioId,
                        ServicioPago = item.ServicioPago,
                        ServicioConsulta = item.ServicioConsulta
                    };

                    servicios.Add(Dato);
                }

                return servicios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardarServicio(ServicioEditarME servicioEditarME)
        {
            try
            {
                var tipoServicio = _context.TipoServicio.Find(servicioEditarME.TipoServicioId);
                var tipoReferencia = _context.TipoReferencia.Find(servicioEditarME.TipoReferenciaId);
                var tipoPago = _context.TipoPago.Find(servicioEditarME.TipoPagoId);

                Servicio servicio = new Servicio()
                {
                    ComisionRubro = servicioEditarME.ComisionRubro,
                    EstaActivo = servicioEditarME.EstaActivo,
                    LongitudReferencia = servicioEditarME.LongitudReferencia,
                    Nombre = servicioEditarME.Nombre,
                    TipoReferencia = tipoReferencia,
                    TipoPago = tipoPago,
                    TipoServicio = tipoServicio,
                    ServicioConsulta = servicioEditarME.ServicioConsulta,
                    ServicioPago = servicioEditarME.ServicioPago
                };

                _context.Servicio.Add(servicio);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool ActualizarServicio(ServicioEditarME servicioEditarME)
        {
            try
            {
                var servicio = _context.Servicio.Find(servicioEditarME.ServicioId);
                var tipoServicio = _context.TipoServicio.Find(servicioEditarME.TipoServicioId);
                var tipoReferencia = _context.TipoReferencia.Find(servicioEditarME.TipoReferenciaId);
                var tipoPago = _context.TipoPago.Find(servicioEditarME.TipoPagoId);

                servicio.ComisionRubro = servicioEditarME.ComisionRubro;
                servicio.EstaActivo = servicioEditarME.EstaActivo;
                servicio.LongitudReferencia = servicioEditarME.LongitudReferencia;
                servicio.Nombre = servicioEditarME.Nombre;
                servicio.TipoReferencia = tipoReferencia;
                servicio.TipoPago = tipoPago;
                servicio.TipoServicio = tipoServicio;
                servicio.ServicioConsulta = servicioEditarME.ServicioConsulta;
                servicio.ServicioPago = servicioEditarME.ServicioPago;

                this._context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool EliminarServicio(int servicioId)
        {
            try
            {
                var servicio = _context.Servicio.Find(servicioId);

                servicio.EstaActivo = false;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        #endregion

        #region TipoReferencia
        public List<TipoReferenciaMS> ListaTipoReferencias()
        {
            try
            {
                var referencias = _context.TipoReferencia.ToList();

                List<TipoReferenciaMS> tiporeferencias = new List<TipoReferenciaMS>();

                foreach (var item in referencias)
                {
                    TipoReferenciaMS Dato = new TipoReferenciaMS()
                    {
                        TipoReferenciaId = item.TipoReferenciaId,
                        Nombre = item.Nombre,
                        EstaActivo = item.EstaActivo
                    };

                    tiporeferencias.Add(Dato);
                }

                return tiporeferencias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardarTipoReferencia(TipoReferenciaEditarME tipoReferenciaME)
        {
            try
            {
                TipoReferencia tipoReferencia = new TipoReferencia()
                {
                    Nombre = tipoReferenciaME.Nombre,
                    EstaActivo = tipoReferenciaME.EstaActivo,
                };

                _context.TipoReferencia.Add(tipoReferencia);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool ActualizarTipoReferencia(TipoReferenciaEditarME tipoReferenciaME)
        {
            try
            {
                var tipoReferencia = _context.TipoServicio.Find(tipoReferenciaME.TipoReferenciaId);

                tipoReferencia.EstaActivo = tipoReferenciaME.EstaActivo;
                tipoReferencia.Nombre = tipoReferenciaME.Nombre;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool EliminarTipoReferencia(int tipoReferenciaId)
        {
            try
            {
                var tipoReferencia = _context.TipoReferencia.Find(tipoReferenciaId);

                tipoReferencia.EstaActivo = false;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        #endregion

        #region TipoPago
        public List<TipoPagoMS> ListaTipoPagos()
        {
            try
            {
                var pagos = _context.TipoPago.ToList();

                List<TipoPagoMS> tipoPagos = new List<TipoPagoMS>();

                foreach (var item in pagos)
                {
                    TipoPagoMS Dato = new TipoPagoMS()
                    {
                        TipoPagoId = item.TipoPagoId,
                        Nombre = item.Nombre,
                        EstaActivo = item.EstaActivo
                    };

                    tipoPagos.Add(Dato);
                }

                return tipoPagos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardarTipoPago(TipoPagoEditarME tipoPagoME)
        {
            try
            {
                TipoPago tipoPago = new TipoPago()
                {
                    Nombre = tipoPagoME.Nombre,
                    EstaActivo = tipoPagoME.EstaActivo,
                };

                _context.TipoPago.Add(tipoPago);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool ActualizarTipoPago(TipoPagoEditarME tipoPagoEditarME)
        {
            try
            {
                var tipoPago = _context.TipoPago.Find(tipoPagoEditarME.TipoPagoId);

                tipoPago.EstaActivo = tipoPagoEditarME.EstaActivo;
                tipoPago.Nombre = tipoPagoEditarME.Nombre;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool EliminarTipoPago(int tipoPagoId)
        {
            try
            {
                var tipoPago = _context.TipoReferencia.Find(tipoPagoId);

                tipoPago.EstaActivo = false;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        #endregion

        #region Usuario
        public List<UsuarioMS> ListaUsuarios()
        {
            try
            {
                var usuario = _context.Usuario.ToList();

                List<UsuarioMS> usuarios = new List<UsuarioMS>();

                foreach (var item in usuario)
                {
                    UsuarioMS Dato = new UsuarioMS()
                    {
                        Bloqueado = item.Bloqueado,
                        Contrasenia = item.Contrasenia,
                        Correo = item.Correo,
                        FechaActualizacion = item.FechaActualizacion,
                        FechaCreacion = item.FechaCreacion,
                        Username = item.Username,
                        UsuarioId = item.UsuarioId,
                        EstaActivo = item.EstaActivo,
                        Nombre = item.Nombre,
                        EsAdmin = item.EsAdmin
                    };

                    usuarios.Add(Dato);
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardarUsuario(UsuarioEditarME usuarioEditarME)
        {
            try
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                string pass = BCrypt.Net.BCrypt.HashPassword(usuarioEditarME.Contrasenia, salt);

                var parametrizacion = _context.Parametrizacion.FirstOrDefault();

                var usuarioExistente = (from us in _context.Usuario
                               where us.Username == usuarioEditarME.Username
                               select us).FirstOrDefault();

                if(usuarioExistente == null)
                {
                    Usuario usuario = new Usuario()
                    {
                        Bloqueado = usuarioEditarME.Bloqueado,
                        Contrasenia = pass,
                        Correo = usuarioEditarME.Correo,
                        FechaActualizacion = usuarioEditarME.FechaActualizacion,
                        FechaCreacion = usuarioEditarME.FechaCreacion,
                        Username = usuarioEditarME.Username,
                        EstaActivo = usuarioEditarME.EstaActivo,
                        Nombre = usuarioEditarME.Nombre,
                        Identificacion = usuarioEditarME.Identificacion,
                        EsAdmin = usuarioEditarME.EsAdmin
                    };

                    _context.Usuario.Add(usuario);
                    _context.SaveChanges();

                    EmailME email = new EmailME()
                    {
                        Asunto = "Bienvenido a One Pay",
                        Email = usuarioEditarME.Correo,
                        Mensaje = parametrizacion.MensajeNuevaCuenta + " " + usuarioEditarME.Nombre + ". Tu usuario es: " + usuarioEditarME.Username + " ya puedes iniciar sesión"
                    };

                    EnviaEmail(email);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool ActualizarUsuario(UsuarioEditarME usuarioEditarME)
        {
            try
            {
                var usuario = _context.Usuario.Find(usuarioEditarME.UsuarioId);

                usuario.Bloqueado = usuarioEditarME.Bloqueado;
                usuario.Contrasenia = usuarioEditarME.Contrasenia;
                usuario.Correo = usuarioEditarME.Correo;
                usuario.FechaActualizacion = usuarioEditarME.FechaActualizacion;
                usuario.Username = usuarioEditarME.Username;
                usuario.EstaActivo = usuarioEditarME.EstaActivo;
                usuario.Nombre = usuarioEditarME.Nombre;
                usuario.Identificacion = usuarioEditarME.Identificacion;
                usuario.EsAdmin = usuarioEditarME.EsAdmin;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool EliminarUsuario(int usuarioId)
        {
            try
            {
                var usuario = _context.Usuario.Find(usuarioId);

                usuario.EstaActivo = false;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool ActualizarContraseniaUsuario(UsuarioEditarME usuarioEditarME)
        {
            try
            {
                var usuario = _context.Usuario.Find(usuarioEditarME.UsuarioId);

                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                string pass = BCrypt.Net.BCrypt.HashPassword(usuarioEditarME.Contrasenia, salt);

                usuario.Contrasenia = pass;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public LoginMS LoginUsuario(LoginME loginME)
        {
            try
            {
                var usuario = (from us in _context.Usuario
                               where us.Username == loginME.Usuario
                               select us).FirstOrDefault();
                
                LoginMS loginMS = new LoginMS();

                if (usuario != null)
                {
                    if(usuario.Bloqueado == false && usuario.EstaActivo == true)
                    {
                        if (BCrypt.Net.BCrypt.Verify(loginME.Contrasenia, usuario.Contrasenia))
                        {
                            loginMS = new LoginMS()
                            { 
                                UsuarioId = usuario.UsuarioId,
                                Bloqueado = usuario.Bloqueado,
                                Correo = usuario.Correo,
                                FechaActualizacion = usuario.FechaActualizacion,
                                FechaCreacion = usuario.FechaCreacion,
                                Username = usuario.Username,
                                EstaActivo = usuario.EstaActivo,
                                Nombre = usuario.Nombre,
                                Mensaje = "Ok",
                                EsAdmin = usuario.EsAdmin,
                                Identificacion = usuario.Identificacion
                            };
                            return loginMS;
                        }
                        else
                        {
                            loginMS.Mensaje = "Usuario o contraseña no existe";
                            return loginMS;
                        }
                    }
                    else
                    {
                        loginMS.Mensaje = "Usuario o contraseña no existe";
                        return loginMS;
                    }
                }
                else
                {
                    loginMS.Mensaje = "Usuario o contraseña no existe";
                    return loginMS;
                }
            }
            catch (Exception ex)
            {
                LoginMS loginMS = new LoginMS
                {
                    Mensaje = "Usuario o contraseña no existe"
                };
                return loginMS;
                throw ex;
            }
        }
        #endregion

        #region Parametrizacion
        public List<ParametrizacionMS> ListaParametrizacion()
        {
            try
            {
                var parametrizacion = (from para in _context.Parametrizacion
                                select para).ToList();

                List<ParametrizacionMS> parametrizaciones = new List<ParametrizacionMS>();

                foreach (var item in parametrizacion)
                {
                    ParametrizacionMS Dato = new ParametrizacionMS()
                    {
                        Comision = item.Comision,
                        ContraseniaCorreo = item.ContraseniaCorreo,
                        Correo = item.Correo,
                        MaxIntentosLogin = item.MaxIntentosLogin,
                        MensajeNuevaCuenta = item.MensajeNuevaCuenta,
                        MensajePagoServicio = item.MensajePagoServicio,
                        MensajeRecuperacionContrasenia = item.MensajeRecuperacionContrasenia,
                        ParametrizacionId = item.ParametrizacionId,
                        PuertoCorreo = item.PuertoCorreo,
                        SmtpCorreo = item.SmtpCorreo
                    };

                    parametrizaciones.Add(Dato);
                }

                return parametrizaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardarParametrizacion(ParametrizacionME parametrizacionME)
        {
            try
            {
                Parametrizacion parametrizacion = new Parametrizacion()
                {
                    Comision = parametrizacionME.Comision,
                    ContraseniaCorreo = parametrizacionME.ContraseniaCorreo,
                    Correo = parametrizacionME.Correo,
                    MaxIntentosLogin = parametrizacionME.MaxIntentosLogin,
                    MensajeNuevaCuenta = parametrizacionME.MensajeNuevaCuenta,
                    MensajePagoServicio = parametrizacionME.MensajePagoServicio,
                    MensajeRecuperacionContrasenia = parametrizacionME.MensajeRecuperacionContrasenia,
                    SmtpCorreo = parametrizacionME.SmtpCorreo,
                    PuertoCorreo = parametrizacionME.PuertoCorreo,
                };

                _context.Parametrizacion.Add(parametrizacion);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool ActualizarParametrizacion(ParametrizacionME parametrizacionME)
        {
            try
            {
                var parametrizacion = _context.Parametrizacion.Find(parametrizacionME.ParametrizacionId);

                parametrizacion.Comision = parametrizacionME.Comision;
                parametrizacion.ContraseniaCorreo = parametrizacionME.ContraseniaCorreo;
                parametrizacion.Correo = parametrizacionME.Correo;
                parametrizacion.MaxIntentosLogin = parametrizacionME.MaxIntentosLogin;
                parametrizacion.MensajeNuevaCuenta = parametrizacionME.MensajeNuevaCuenta;
                parametrizacion.MensajePagoServicio = parametrizacionME.MensajePagoServicio;
                parametrizacion.MensajeRecuperacionContrasenia = parametrizacionME.MensajeRecuperacionContrasenia;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        #endregion

        #region Consulta
        public List<ConsultaMS> ListaConsultas()
        {
            try
            {
                var consulta = (from con in _context.Consulta
                                join us in _context.Usuario on con.Usuario.UsuarioId equals us.UsuarioId
                                join serv in _context.Servicio on con.Servicio.ServicioId equals serv.ServicioId
                                select new
                                {
                                    con.ConsultaId,
                                    con.FechaConsulta,
                                    con.Referencia,
                                    con.Descripcion,
                                    us.UsuarioId,
                                    us.Nombre,
                                    serv.ServicioId
                                }).ToList();

                if(consulta != null)
                {
                    List<ConsultaMS> consultas = new List<ConsultaMS>();

                    foreach (var item in consulta)
                    {
                        ConsultaMS Dato = new ConsultaMS()
                        {
                            ConsultaId = item.ConsultaId,
                            FechaConsulta = item.FechaConsulta,
                            Referencia = item.Referencia,
                            Descripcion = item.Descripcion,
                            UsuarioId = item.UsuarioId,
                            ServicioId = item.ServicioId,
                            Nombre = item.Nombre,
                        };

                        consultas.Add(Dato);
                    }
                    return consultas;
                }
                else
                {
                    return new List<ConsultaMS>();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ConsultaMS> ListaConsultasPorFecha(ConsultaFechaME mensajeEntrada)
        {
            try
            {
                var consulta = (from con in _context.Consulta
                                join us in _context.Usuario on con.Usuario.UsuarioId equals us.UsuarioId
                                join serv in _context.Servicio on con.Servicio.ServicioId equals serv.ServicioId
                                where con.FechaConsulta.Date >= mensajeEntrada.FechaInicio.Date && con.FechaConsulta.Date <= mensajeEntrada.FechaFin.Date
                                select new
                                {
                                    con.ConsultaId,
                                    con.FechaConsulta,
                                    con.Referencia,
                                    con.Descripcion,
                                    us.UsuarioId,
                                    us.Nombre,
                                    serv.ServicioId
                                }).ToList();

                if(consulta != null)
                {
                    List<ConsultaMS> consultas = new List<ConsultaMS>();

                    foreach (var item in consulta)
                    {
                        ConsultaMS Dato = new ConsultaMS()
                        {
                            ConsultaId = item.ConsultaId,
                            FechaConsulta = item.FechaConsulta,
                            Referencia = item.Referencia,
                            Descripcion = item.Descripcion,
                            UsuarioId = item.UsuarioId,
                            ServicioId = item.ServicioId,
                            Nombre = item.Nombre,
                        };

                        consultas.Add(Dato);
                    }

                    return consultas;
                }
                else
                {
                    return new List<ConsultaMS>();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardarConsulta(ConsultaME consultaME)
        {
            try
            {
                var usuario = _context.Usuario.Find(consultaME.UsuarioId);
                var servicio = _context.Servicio.Find(consultaME.ServicioId);

                Consulta consulta = new Consulta()
                {
                    Descripcion = consultaME.Descripcion,
                    Referencia = consultaME.Referencia,
                    FechaConsulta = consultaME.FechaConsulta,
                    Servicio = servicio,
                    Usuario = usuario
                };

                _context.Consulta.Add(consulta);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public async Task<ConsultaMS> RealizarConsulta(ConsultaME consultaME)
        {
            try
            {
                ConsultaMS mensajeSalida = new ConsultaMS();
                var webService = _context.Servicio.Find(consultaME.ServicioId).ServicioConsulta;

                HttpClient client = new HttpClient();

                var json = JsonConvert.SerializeObject(consultaME);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string uri = webService;
                HttpResponseMessage response = await client.PostAsync(uri, content);
                var responseString = await response.Content.ReadAsStringAsync();

                mensajeSalida = JsonConvert.DeserializeObject<ConsultaMS>(responseString);

                if (response.IsSuccessStatusCode)
                {
                    mensajeSalida = JsonConvert.DeserializeObject<ConsultaMS>(responseString);

                    ConsultaME consulta = new ConsultaME()
                    {
                        Descripcion = consultaME.Descripcion,
                        Referencia = consultaME.Referencia,
                        FechaConsulta = consultaME.FechaConsulta,
                        ServicioId = consultaME.ServicioId,
                        UsuarioId = consultaME.UsuarioId
                    };

                    GuardarConsulta(consulta);

                    var consultaDato = (from con in _context.Consulta
                                    orderby con.ConsultaId descending
                                    select con).FirstOrDefault();

                    mensajeSalida.Descripcion = consultaME.Descripcion;
                    mensajeSalida.ServicioId = consultaME.ServicioId;
                    mensajeSalida.UsuarioId = consultaME.UsuarioId;
                    mensajeSalida.ConsultaId = consultaDato.ConsultaId;

                    return mensajeSalida;
                }
                else
                {
                    return new ConsultaMS();
                }
            }
            catch (Exception ex)
            {
                return new ConsultaMS();
                throw ex;
            }
        }

        #endregion
         
        #region ServicioUsuario
        public List<ServicioUsuarioMS> ListaServiciosUsuarios(int usuarioId)
        {
            try
            {
                var serviciosUsuarios = (from servuser in _context.ServicioUsuario
                                         join serv in _context.Servicio on servuser.Servicio.ServicioId equals serv.ServicioId
                                         join tps in _context.TipoServicio on serv.TipoServicio.TipoServicioId equals tps.TipoServicioId
                                         join user in _context.Usuario on servuser.Usuario.UsuarioId equals user.UsuarioId
                                         where user.UsuarioId == usuarioId
                                         select new ServicioUsuarioMS()
                                         {
                                             ServicioUsuarioId = servuser.ServicioUsuarioId,
                                             ServicioId = serv.ServicioId,
                                             UsuarioId = user.UsuarioId,
                                             NombreServicio = serv.Nombre,
                                             TipoServicio = tps.Nombre,
                                             Contrapartida = servuser.Contrapartida
                                         }).ToList();

                return serviciosUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardarServicioUsuario(ServicioUsuarioME servicioUsuarioME)
        {
            try
            {
                var servicio = _context.Servicio.Find(servicioUsuarioME.ServicioId);
                var usuario = _context.Usuario.Find(servicioUsuarioME.UsuarioId);

                ServicioUsuario servicioUsuario = new ServicioUsuario()
                {
                    Usuario = usuario,
                    Servicio = servicio,
                    Contrapartida = servicioUsuarioME.Contrapartida,
                    EstaActivo = servicioUsuarioME.EstaActivo,
                };

                _context.ServicioUsuario.Add(servicioUsuario);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool ActualizarServicioUsuario(ServicioUsuarioME servicioUsuarioME)
        {
            try
            {
                var servicioUsuario = _context.ServicioUsuario.Find(servicioUsuarioME.ServicioUsuarioId);

                servicioUsuario.EstaActivo = servicioUsuarioME.EstaActivo;
                servicioUsuario.Contrapartida = servicioUsuarioME.Contrapartida;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool EliminarServicioUsuario(int servicioUsuarioId)
        {
            try
            {
                var servicioUsuario = _context.ServicioUsuario.Find(servicioUsuarioId);

                servicioUsuario.EstaActivo = false;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        #endregion

        #region Emails
        public bool EnviaEmail(EmailME mensajeEntrada)
        {
            try
            {
                var paramentrizacion = _context.Parametrizacion.ToList();
                var usuario = (from user in _context.Usuario
                               where user.Correo == mensajeEntrada.Email
                               select user).FirstOrDefault();

                MimeMessage message = new MimeMessage();

                MailboxAddress from = new MailboxAddress("One Pay",
                paramentrizacion.FirstOrDefault().Correo);
                message.From.Add(from);

                MailboxAddress to = new MailboxAddress(usuario.Nombre,
                mensajeEntrada.Email);
                message.To.Add(to);

                message.Subject = mensajeEntrada.Asunto;

                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<h1>" + mensajeEntrada.Mensaje + "</h1>";
                bodyBuilder.TextBody = mensajeEntrada.Mensaje;

                message.Body = bodyBuilder.ToMessageBody();

                SmtpClient client = new SmtpClient();
                client.Connect(paramentrizacion.FirstOrDefault().SmtpCorreo, 587, false);
                client.Authenticate(paramentrizacion.FirstOrDefault().Correo, paramentrizacion.FirstOrDefault().ContraseniaCorreo);

                client.Send(message);
                client.Disconnect(true);
                client.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        #endregion

        #region Otp
        public bool EnviarOTP(string username)
        {
            try
            {
                var usuario = (from user in _context.Usuario
                               where user.Username == username
                               select user).FirstOrDefault();

                var secretKey = Encoding.UTF8.GetBytes(username + "LlaveSecreta");

                var totp = new Totp(secretKey, totpSize: 6);

                listaOtp.Add(totp);
                
                string numero = totp.ComputeTotp();

                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                string otpEncrypt = BCrypt.Net.BCrypt.HashPassword(numero, salt);

                OTPDato dato = new OTPDato()
                {
                    Usuario = username,
                    Dato = otpEncrypt,
                };

                _context.OTPDato.Add(dato);
                _context.SaveChanges();

                EmailME mensajeEmail = new EmailME()
                {
                    Asunto = "OTP Acceso",
                    Email = usuario.Correo,
                    Mensaje = "Su clave otp es: " + totp.ComputeTotp()
                };

                EnviaEmail(mensajeEmail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool ValidaOTP(OTPME mensajeEntrada)
        {
            try
            {
                var otp = (from otpD in _context.OTPDato
                           where otpD.Usuario == mensajeEntrada.Username
                           orderby otpD.OtpDatoId descending
                           select otpD).FirstOrDefault();

                if (BCrypt.Net.BCrypt.Verify(mensajeEntrada.OTP, otp.Dato))
                {
                    _context.OTPDato.Remove(otp);
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        #endregion

        #region PagoServicio
        public List<PagoMS> ListaPagoFechas(ConsultaFechaME mensajeEntrada)
        {
            try
            {
                if(mensajeEntrada.UsuarioId == 0)
                {
                    var pago = (from pg in _context.Pago
                                join con in _context.Consulta on pg.Consulta.ConsultaId equals con.ConsultaId
                                join serv in _context.Servicio on pg.Consulta.Servicio.ServicioId equals serv.ServicioId
                                join user in _context.Usuario on con.Usuario.UsuarioId equals user.UsuarioId
                                where pg.FechaPago >= mensajeEntrada.FechaInicio.Date && pg.FechaPago.Date <= mensajeEntrada.FechaFin.Date
                                select new { pg, con, serv }).ToList();

                    if (pago != null)
                    {
                        List<PagoMS> pagos = new List<PagoMS>();
                        List<RubrosMS> rubros = new List<RubrosMS>();

                        foreach (var item in pago)
                        {
                            var rubro = (from rb in _context.RubrosPagados
                                         join pg in _context.Pago on rb.Pago.PagoId equals pg.PagoId
                                         where rb.Pago.PagoId == item.pg.PagoId
                                         select rb).ToList();

                            rubros = new List<RubrosMS>();

                            foreach (var item2 in rubro)
                            {
                                RubrosMS dato = new RubrosMS()
                                {
                                    Periodo = item2.Periodo,
                                    Prioridad = item2.Prioridad,
                                    ValorAPagar = item2.ValorAPagar,
                                    Descripcion = item2.Descripcion
                                };

                                rubros.Add(dato);
                            }

                            PagoMS Dato = new PagoMS()
                            {
                                ServicioId = item.serv.ServicioId,
                                ConsultaId = item.con.ConsultaId,
                                Documento = item.pg.Documento,
                                FechaPago = item.pg.FechaPago,
                                ValorPagado = item.pg.ValorPagado,
                                IdPasarelaPago = item.pg.IdPasarelaPago,
                                Rubros = rubros
                            };

                            pagos.Add(Dato);
                        }

                        return pagos;
                    }
                    else
                    {
                        return new List<PagoMS>();
                    }
                }
                else
                {
                    var pago = (from pg in _context.Pago
                                join con in _context.Consulta on pg.Consulta.ConsultaId equals con.ConsultaId
                                join serv in _context.Servicio on pg.Consulta.Servicio.ServicioId equals serv.ServicioId
                                join user in _context.Usuario on con.Usuario.UsuarioId equals user.UsuarioId
                                where pg.FechaPago >= mensajeEntrada.FechaInicio.Date && pg.FechaPago.Date <= mensajeEntrada.FechaFin.Date
                                && user.UsuarioId == mensajeEntrada.UsuarioId
                                select new { pg, con, serv}).ToList();

                    if (pago != null)
                    {
                        List<PagoMS> pagos = new List<PagoMS>();
                        List<RubrosMS> rubros = new List<RubrosMS>();

                        foreach (var item in pago)
                        {
                            var rubro = (from rb in _context.RubrosPagados
                                         join pg in _context.Pago on rb.Pago.PagoId equals pg.PagoId
                                         where rb.Pago.PagoId == item.pg.PagoId
                                         select rb).ToList();
                            
                            rubros = new List<RubrosMS>();

                            foreach (var item2 in rubro)
                            {
                                RubrosMS dato = new RubrosMS()
                                {
                                    Periodo = item2.Periodo,
                                    Prioridad = item2.Prioridad,
                                    ValorAPagar = item2.ValorAPagar,
                                    Descripcion = item2.Descripcion
                                };

                                rubros.Add(dato);
                            }

                            PagoMS Dato = new PagoMS()
                            {
                                ServicioId = item.serv.ServicioId,
                                ConsultaId = item.con.ConsultaId,
                                Documento = item.pg.Documento,
                                FechaPago = item.pg.FechaPago,
                                ValorPagado = item.pg.ValorPagado,
                                IdPasarelaPago = item.pg.IdPasarelaPago,
                                Rubros = rubros
                            };

                            pagos.Add(Dato);
                        }

                        return pagos;
                    }
                    else
                    {
                        return new List<PagoMS>();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PagoMS> ListaPago()
        {
            try
            {
                var pago = (from pg in _context.Pago
                            join con in _context.Consulta on pg.Consulta.ConsultaId equals con.ConsultaId
                            join serv in _context.Servicio on pg.Consulta.Servicio.ServicioId equals serv.ServicioId
                            select new { pg, con, serv }).ToList();

                if(pago!= null)
                {
                    List<PagoMS> pagos = new List<PagoMS>();
                    List<RubrosMS> rubros = new List<RubrosMS>();

                    foreach (var item in pago)
                    {
                        var rubro = (from rb in _context.RubrosPagados
                                     where rb.Pago.PagoId == item.pg.PagoId
                                     select rb).ToList();

                        foreach (var item2 in rubro)
                        {
                            RubrosMS dato = new RubrosMS()
                            {
                                Periodo = item2.Periodo,
                                Prioridad = item2.Prioridad,
                                ValorAPagar = item2.ValorAPagar,
                                Descripcion = item2.Descripcion
                            };

                            rubros.Add(dato);
                        }

                        PagoMS Dato = new PagoMS()
                        {
                            ServicioId = item.serv.ServicioId,
                            ConsultaId = item.con.ConsultaId,
                            Documento = item.pg.Documento,
                            FechaPago = item.pg.FechaPago,
                            ValorPagado = item.pg.ValorPagado,
                            IdPasarelaPago = item.pg.IdPasarelaPago,
                            Rubros = rubros
                        };

                        pagos.Add(Dato);
                    }

                    return pagos;
                }
                else
                {
                    return new List<PagoMS>();
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PagoMS> RealizarPago(PagoME mensajeEntrada)
        {
            try
            {
                var servicio = (from serv in _context.Servicio
                                where serv.ServicioId == mensajeEntrada.ServicioId
                                select serv).FirstOrDefault();

                var usuario = (from us in _context.Usuario
                               where us.UsuarioId == mensajeEntrada.UsuarioId
                               select us).FirstOrDefault();

                var consulta = (from con in _context.Consulta
                                where con.ConsultaId == mensajeEntrada.ConsultaId
                                select con).FirstOrDefault();

                var webService = _context.Servicio.Find(mensajeEntrada.ServicioId).ServicioPago;

                HttpClient client = new HttpClient();

                PagoServicioME mensajeServicio = new PagoServicioME()
                {
                    Contrapartida = consulta.Referencia,
                    Rubros = mensajeEntrada.Rubros
                };

                var json = JsonConvert.SerializeObject(mensajeServicio);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string uri = webService;
                HttpResponseMessage response = await client.PostAsync(uri, content);
                var responseString = await response.Content.ReadAsStringAsync();

                bool mensajeSalidaServicio = JsonConvert.DeserializeObject<bool>(responseString);

                if (response.IsSuccessStatusCode && mensajeSalidaServicio)
                {
                    var parametrizacion = _context.Parametrizacion.FirstOrDefault();

                    var pagos = _context.Pago.ToList().Count() + 1;

                    Pago pago = new Pago()
                    {
                        Consulta = consulta,
                        Usuario = usuario,
                        Documento = pagos.ToString("00000000"),
                        FechaPago = DateTime.Now,
                        Servicio = servicio,
                        IdPasarelaPago = mensajeEntrada.IdPasarelaPago,
                        ValorPagado = mensajeEntrada.ValorPagado
                    };

                    _context.Pago.Add(pago);
                    _context.SaveChanges();

                    var pagoNuevo = _context.Pago.OrderByDescending(u => u.PagoId).FirstOrDefault();

                    foreach (var item in mensajeEntrada.Rubros)
                    {
                        RubrosPagados dato = new RubrosPagados()
                        {
                            Pago = pagoNuevo,
                            Periodo = item.Periodo,
                            Prioridad = item.Prioridad,
                            ValorAPagar = item.ValorAPagar,
                            Descripcion = item.Descripcion
                        };

                        _context.RubrosPagados.Add(dato);
                        _context.SaveChanges();
                    }

                    EmailME mensajeEmail = new EmailME()
                    {
                        Asunto = "Pago Realizado",
                        Email = usuario.Correo,
                        Mensaje = parametrizacion.MensajePagoServicio + ". Con el valor de " + pago.ValorPagado + " con número de documento: " + pago.Documento
                    };

                    EnviaEmail(mensajeEmail);

                    PagoMS pagoMS = new PagoMS()
                    {
                        Documento = pago.Documento,
                        FechaPago = pago.FechaPago,
                        ValorPagado = pago.ValorPagado,
                        IdPasarelaPago = pago.IdPasarelaPago,
                        ConsultaId = mensajeEntrada.ConsultaId,
                        Rubros = mensajeEntrada.Rubros,
                        ServicioId = mensajeEntrada.ServicioId
                    };

                    return pagoMS;
                }
                else
                {
                    return new PagoMS();
                }
            }
            catch (Exception ex)
            {
                return new PagoMS();
                throw;
            }
        }
        #endregion
    }
}
