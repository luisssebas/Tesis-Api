using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMovil.Migrations
{
    public partial class MigracionCorreccion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicioUsuario");

            migrationBuilder.DropTable(
                name: "Rubro",
                schema: "Empresa");

            migrationBuilder.DropTable(
                name: "InformacionPago",
                schema: "Empresa");

            migrationBuilder.DropTable(
                name: "Empresa",
                schema: "Empresa");

            migrationBuilder.DropTable(
                name: "Persona",
                schema: "Empresa");

            migrationBuilder.DropTable(
                name: "DivisionPolitica",
                schema: "Empresa");

            migrationBuilder.DropTable(
                name: "EstadoCivil",
                schema: "Empresa");

            migrationBuilder.DropTable(
                name: "TipoIdentificacion",
                schema: "Empresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Empresa");

            migrationBuilder.CreateTable(
                name: "ServicioUsuario",
                columns: table => new
                {
                    ServicioUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrapartida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioUsuario", x => x.ServicioUsuarioId);
                    table.ForeignKey(
                        name: "FK_ServicioUsuario_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicioUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DivisionPolitica",
                schema: "Empresa",
                columns: table => new
                {
                    Secuencial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecuencialPadre = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionPolitica", x => x.Secuencial);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                schema: "Empresa",
                columns: table => new
                {
                    Secuencial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RUC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Siglas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Secuencial);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                schema: "Empresa",
                columns: table => new
                {
                    Secuencial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.Secuencial);
                });

            migrationBuilder.CreateTable(
                name: "TipoIdentificacion",
                schema: "Empresa",
                columns: table => new
                {
                    Secuencial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacion", x => x.Secuencial);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                schema: "Empresa",
                columns: table => new
                {
                    Secuencial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisionPoliticaSecuencial = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    EstadoCivilSecuencial = table.Column<int>(type: "int", nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoConvencional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoIdentificacionSecuencial = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Secuencial);
                    table.ForeignKey(
                        name: "FK_Persona_DivisionPolitica_DivisionPoliticaSecuencial",
                        column: x => x.DivisionPoliticaSecuencial,
                        principalSchema: "Empresa",
                        principalTable: "DivisionPolitica",
                        principalColumn: "Secuencial",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_EstadoCivil_EstadoCivilSecuencial",
                        column: x => x.EstadoCivilSecuencial,
                        principalSchema: "Empresa",
                        principalTable: "EstadoCivil",
                        principalColumn: "Secuencial",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_TipoIdentificacion_TipoIdentificacionSecuencial",
                        column: x => x.TipoIdentificacionSecuencial,
                        principalSchema: "Empresa",
                        principalTable: "TipoIdentificacion",
                        principalColumn: "Secuencial",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InformacionPago",
                schema: "Empresa",
                columns: table => new
                {
                    Secuencial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaSecuencial = table.Column<int>(type: "int", nullable: true),
                    FechaFactura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pendiente = table.Column<bool>(type: "bit", nullable: false),
                    PeriodoFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonaSecuencial = table.Column<int>(type: "int", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorFactura = table.Column<double>(type: "float", nullable: false),
                    ValorPendiente = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionPago", x => x.Secuencial);
                    table.ForeignKey(
                        name: "FK_InformacionPago_Empresa_EmpresaSecuencial",
                        column: x => x.EmpresaSecuencial,
                        principalSchema: "Empresa",
                        principalTable: "Empresa",
                        principalColumn: "Secuencial",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InformacionPago_Persona_PersonaSecuencial",
                        column: x => x.PersonaSecuencial,
                        principalSchema: "Empresa",
                        principalTable: "Persona",
                        principalColumn: "Secuencial",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rubro",
                schema: "Empresa",
                columns: table => new
                {
                    Secuencial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InformacionPagoSecuencial = table.Column<int>(type: "int", nullable: true),
                    Periodo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    ValorAPagar = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubro", x => x.Secuencial);
                    table.ForeignKey(
                        name: "FK_Rubro_InformacionPago_InformacionPagoSecuencial",
                        column: x => x.InformacionPagoSecuencial,
                        principalSchema: "Empresa",
                        principalTable: "InformacionPago",
                        principalColumn: "Secuencial",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicioUsuario_ServicioId",
                table: "ServicioUsuario",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioUsuario_UsuarioId",
                table: "ServicioUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionPago_EmpresaSecuencial",
                schema: "Empresa",
                table: "InformacionPago",
                column: "EmpresaSecuencial");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionPago_PersonaSecuencial",
                schema: "Empresa",
                table: "InformacionPago",
                column: "PersonaSecuencial");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_DivisionPoliticaSecuencial",
                schema: "Empresa",
                table: "Persona",
                column: "DivisionPoliticaSecuencial");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_EstadoCivilSecuencial",
                schema: "Empresa",
                table: "Persona",
                column: "EstadoCivilSecuencial");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_TipoIdentificacionSecuencial",
                schema: "Empresa",
                table: "Persona",
                column: "TipoIdentificacionSecuencial");

            migrationBuilder.CreateIndex(
                name: "IX_Rubro_InformacionPagoSecuencial",
                schema: "Empresa",
                table: "Rubro",
                column: "InformacionPagoSecuencial");
        }
    }
}
