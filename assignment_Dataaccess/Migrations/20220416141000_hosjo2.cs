using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment_Dataaccess.Migrations
{
    public partial class hosjo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductsId",
                table: "OrderItems",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductsId",
                table: "OrderItems",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductsId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductsId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "OrderItems",
                type: "int",
                nullable: true);
        }
    }
}
