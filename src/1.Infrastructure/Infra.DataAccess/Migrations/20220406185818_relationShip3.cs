using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.DataAccess.Migrations
{
    public partial class relationShip3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_product_order_OrderId",
            //    table: "product");

            //migrationBuilder.DropIndex(
            //    name: "IX_product_OrderId",
            //    table: "product");

            //migrationBuilder.DropColumn(
            //    name: "OrderId",
            //    table: "product");

            migrationBuilder.CreateTable(
                name: "product_order",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_order", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_product_order_order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_product_order_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_product_order_OrderId",
                table: "product_order",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_OrderId",
                table: "product",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_order_OrderId",
                table: "product",
                column: "OrderId",
                principalTable: "order",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
