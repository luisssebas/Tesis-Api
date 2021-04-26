using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMovil.Migrations
{
    public partial class Migracion20200518 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pendiente",
                schema: "Empresa",
                table: "InformacionPago",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pendiente",
                schema: "Empresa",
                table: "InformacionPago");
        }
    }
}
