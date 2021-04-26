using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMovil.Migrations
{
    public partial class MigracionPrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Servicio_ServicioId",
                table: "Producto");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioId",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Servicio_ServicioId",
                table: "Producto",
                column: "ServicioId",
                principalTable: "Servicio",
                principalColumn: "ServicioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Servicio_ServicioId",
                table: "Producto");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioId",
                table: "Producto",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Servicio_ServicioId",
                table: "Producto",
                column: "ServicioId",
                principalTable: "Servicio",
                principalColumn: "ServicioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
