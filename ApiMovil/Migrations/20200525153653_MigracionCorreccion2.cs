using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMovil.Migrations
{
    public partial class MigracionCorreccion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OTPDato",
                table: "OTPDato");

            migrationBuilder.DropColumn(
                name: "secuencial",
                table: "OTPDato");

            migrationBuilder.AddColumn<int>(
                name: "OtpDatoId",
                table: "OTPDato",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OTPDato",
                table: "OTPDato",
                column: "OtpDatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OTPDato",
                table: "OTPDato");

            migrationBuilder.DropColumn(
                name: "OtpDatoId",
                table: "OTPDato");

            migrationBuilder.AddColumn<int>(
                name: "secuencial",
                table: "OTPDato",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OTPDato",
                table: "OTPDato",
                column: "secuencial");
        }
    }
}
