using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.DataAccess.Migrations
{
    public partial class fecha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_order_order_OrderId",
                table: "product_order");

            migrationBuilder.DropForeignKey(
                name: "FK_product_order_product_ProductId",
                table: "product_order");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "product",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCompra",
                table: "order",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_product_order_order_OrderId",
                table: "product_order",
                column: "OrderId",
                principalTable: "order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_order_product_ProductId",
                table: "product_order",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_order_order_OrderId",
                table: "product_order");

            migrationBuilder.DropForeignKey(
                name: "FK_product_order_product_ProductId",
                table: "product_order");

            migrationBuilder.DropColumn(
                name: "FechaCompra",
                table: "order");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "product",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_product_order_order_OrderId",
                table: "product_order",
                column: "OrderId",
                principalTable: "order",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_product_order_product_ProductId",
                table: "product_order",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
