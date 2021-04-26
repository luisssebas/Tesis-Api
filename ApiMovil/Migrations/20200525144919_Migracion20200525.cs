using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMovil.Migrations
{
    public partial class Migracion20200525 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OTPDato",
                columns: table => new
                {
                    OtpDatoId = table.Column<string>(nullable: false),
                    Dato = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTPDato", x => x.OtpDatoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OTPDato");
        }
    }
}
