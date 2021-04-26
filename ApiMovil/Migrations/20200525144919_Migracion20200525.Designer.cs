﻿// <auto-generated />
using System;
using AppMovil.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiMovil.Migrations
{
    [DbContext(typeof(ServicioContext))]
    [Migration("20200525144919_Migracion20200525")]
    partial class Migracion20200525
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppMovil.Models.Entidades.Consulta", b =>
                {
                    b.Property<int>("ConsultaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaConsulta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServicioId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ConsultaId");

                    b.HasIndex("ServicioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.OTPDato", b =>
                {
                    b.Property<string>("OtpDatoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Dato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OtpDatoId");

                    b.ToTable("OTPDato");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.Pago", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConsultaId")
                        .HasColumnType("int");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensaje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServicioId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<double>("ValorPagado")
                        .HasColumnType("float");

                    b.HasKey("PagoId");

                    b.HasIndex("ConsultaId");

                    b.HasIndex("ServicioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pago");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.Parametrizacion", b =>
                {
                    b.Property<int>("ParametrizacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Comision")
                        .HasColumnType("float");

                    b.Property<string>("ContraseniaCorreo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxIntentosLogin")
                        .HasColumnType("int");

                    b.Property<string>("MensajeNuevaCuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MensajePagoServicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MensajeRecuperacionContrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PuertoCorreo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmtpCorreo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParametrizacionId");

                    b.ToTable("Parametrizacion");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.Servicio", b =>
                {
                    b.Property<int>("ServicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ComisionRubro")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<int>("LongitudReferencia")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServicioHttp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoPagoId")
                        .HasColumnType("int");

                    b.Property<int?>("TipoReferenciaId")
                        .HasColumnType("int");

                    b.Property<int?>("TipoServicioId")
                        .HasColumnType("int");

                    b.HasKey("ServicioId");

                    b.HasIndex("TipoPagoId");

                    b.HasIndex("TipoReferenciaId");

                    b.HasIndex("TipoServicioId");

                    b.ToTable("Servicio");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.ServicioUsuario", b =>
                {
                    b.Property<int>("ServicioUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contrapartida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<int?>("ServicioId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ServicioUsuarioId");

                    b.HasIndex("ServicioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ServicioUsuario");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.TipoPago", b =>
                {
                    b.Property<int>("TipoPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoPagoId");

                    b.ToTable("TipoPago");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.TipoReferencia", b =>
                {
                    b.Property<int>("TipoReferenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoReferenciaId");

                    b.ToTable("TipoReferencia");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.TipoServicio", b =>
                {
                    b.Property<int>("TipoServicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoServicioId");

                    b.ToTable("TipoServicio");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bloqueado")
                        .HasColumnType("bit");

                    b.Property<string>("Contrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("AppMovil.Models.EntidadesEmpresa.DivisionPolitica", b =>
                {
                    b.Property<int>("Secuencial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecuencialPadre")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Secuencial");

                    b.ToTable("DivisionPolitica","Empresa");
                });

            modelBuilder.Entity("AppMovil.Models.EntidadesEmpresa.Empresa", b =>
                {
                    b.Property<int>("Secuencial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RUC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Siglas")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Secuencial");

                    b.ToTable("Empresa","Empresa");
                });

            modelBuilder.Entity("AppMovil.Models.EntidadesEmpresa.EstadoCivil", b =>
                {
                    b.Property<int>("Secuencial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Secuencial");

                    b.ToTable("EstadoCivil","Empresa");
                });

            modelBuilder.Entity("AppMovil.Models.EntidadesEmpresa.InformacionPago", b =>
                {
                    b.Property<int>("Secuencial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmpresaSecuencial")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFactura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroFactura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Pendiente")
                        .HasColumnType("bit");

                    b.Property<string>("PeriodoFactura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonaSecuencial")
                        .HasColumnType("int");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValorFactura")
                        .HasColumnType("float");

                    b.Property<double>("ValorPendiente")
                        .HasColumnType("float");

                    b.HasKey("Secuencial");

                    b.HasIndex("EmpresaSecuencial");

                    b.HasIndex("PersonaSecuencial");

                    b.ToTable("InformacionPago","Empresa");
                });

            modelBuilder.Entity("AppMovil.Models.EntidadesEmpresa.Persona", b =>
                {
                    b.Property<int>("Secuencial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DivisionPoliticaSecuencial")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<int?>("EstadoCivilSecuencial")
                        .HasColumnType("int");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoCelular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoConvencional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoIdentificacionSecuencial")
                        .HasColumnType("int");

                    b.HasKey("Secuencial");

                    b.HasIndex("DivisionPoliticaSecuencial");

                    b.HasIndex("EstadoCivilSecuencial");

                    b.HasIndex("TipoIdentificacionSecuencial");

                    b.ToTable("Persona","Empresa");
                });

            modelBuilder.Entity("AppMovil.Models.EntidadesEmpresa.Rubros", b =>
                {
                    b.Property<int>("Secuencial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InformacionPagoSecuencial")
                        .HasColumnType("int");

                    b.Property<string>("Periodo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prioridad")
                        .HasColumnType("int");

                    b.Property<double>("ValorAPagar")
                        .HasColumnType("float");

                    b.HasKey("Secuencial");

                    b.HasIndex("InformacionPagoSecuencial");

                    b.ToTable("Rubro","Empresa");
                });

            modelBuilder.Entity("AppMovil.Models.EntidadesEmpresa.TipoIdentificacion", b =>
                {
                    b.Property<int>("Secuencial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Secuencial");

                    b.ToTable("TipoIdentificacion","Empresa");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.Consulta", b =>
                {
                    b.HasOne("AppMovil.Models.Entidades.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId");

                    b.HasOne("AppMovil.Models.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.Pago", b =>
                {
                    b.HasOne("AppMovil.Models.Entidades.Consulta", "Consulta")
                        .WithMany()
                        .HasForeignKey("ConsultaId");

                    b.HasOne("AppMovil.Models.Entidades.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId");

                    b.HasOne("AppMovil.Models.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.Servicio", b =>
                {
                    b.HasOne("AppMovil.Models.Entidades.TipoPago", "TipoPago")
                        .WithMany()
                        .HasForeignKey("TipoPagoId");

                    b.HasOne("AppMovil.Models.Entidades.TipoReferencia", "TipoReferencia")
                        .WithMany()
                        .HasForeignKey("TipoReferenciaId");

                    b.HasOne("AppMovil.Models.Entidades.TipoServicio", "TipoServicio")
                        .WithMany()
                        .HasForeignKey("TipoServicioId");
                });

            modelBuilder.Entity("AppMovil.Models.Entidades.ServicioUsuario", b =>
                {
                    b.HasOne("AppMovil.Models.Entidades.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId");

                    b.HasOne("AppMovil.Models.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("AppMovil.Models.EntidadesEmpresa.InformacionPago", b =>
                {
                    b.HasOne("AppMovil.Models.EntidadesEmpresa.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaSecuencial");

                    b.HasOne("AppMovil.Models.EntidadesEmpresa.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaSecuencial");
                });

            modelBuilder.Entity("AppMovil.Models.EntidadesEmpresa.Persona", b =>
                {
                    b.HasOne("AppMovil.Models.EntidadesEmpresa.DivisionPolitica", "DivisionPolitica")
                        .WithMany()
                        .HasForeignKey("DivisionPoliticaSecuencial");

                    b.HasOne("AppMovil.Models.EntidadesEmpresa.EstadoCivil", "EstadoCivil")
                        .WithMany()
                        .HasForeignKey("EstadoCivilSecuencial");

                    b.HasOne("AppMovil.Models.EntidadesEmpresa.TipoIdentificacion", "TipoIdentificacion")
                        .WithMany()
                        .HasForeignKey("TipoIdentificacionSecuencial");
                });

            modelBuilder.Entity("AppMovil.Models.EntidadesEmpresa.Rubros", b =>
                {
                    b.HasOne("AppMovil.Models.EntidadesEmpresa.InformacionPago", "InformacionPago")
                        .WithMany()
                        .HasForeignKey("InformacionPagoSecuencial");
                });
#pragma warning restore 612, 618
        }
    }
}
