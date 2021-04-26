using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMovil.Migrations
{
    public partial class Migracion20202405 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PuertoCorreo",
                table: "Parametrizacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpCorreo",
                table: "Parametrizacion",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PuertoCorreo",
                table: "Parametrizacion");

            migrationBuilder.DropColumn(
                name: "SmtpCorreo",
                table: "Parametrizacion");
        }
    }
}
