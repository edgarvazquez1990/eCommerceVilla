using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.DataAccess.Migrations
{
    public partial class indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_usuario_Id",
                table: "usuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_address_Id",
                table: "address",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_usuario_Id",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_address_Id",
                table: "address");
        }
    }
}
