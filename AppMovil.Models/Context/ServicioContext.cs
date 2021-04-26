using AppMovil.Models.Entidades;
using AppMovil.Models.EntidadesEmpresa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil.Models.Context
{
    public class ServicioContext : DbContext
    {
        public ServicioContext(DbContextOptions<ServicioContext> options)
            : base(options)
        {
        }

        public DbSet<TipoServicio> TipoServicio { get; set; }
        public DbSet<TipoPago> TipoPago { get; set; }
        public DbSet<TipoReferencia> TipoReferencia { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Parametrizacion> Parametrizacion { get; set; }
        public DbSet<OTPDato> OTPDato { get; set; }
        public DbSet<RubrosPagados> RubrosPagados { get; set; }

        public DbSet<DivisionPolitica> DivisionPolitica { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Rubros> Rubro { get; set; }
        public DbSet<InformacionPago> InformacionPago { get; set; }
        public DbSet<ServicioUsuario> ServicioUsuario { get; set; }
    }
}
