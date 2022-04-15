using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment_Dataaccess.Migrations
{
    public partial class anyupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductsId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "OrderItems",
                newName: "ProductsListItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductsId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductsListItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductsListItemId",
                table: "OrderItems",
                column: "ProductsListItemId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductsListItemId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "ProductsListItemId",
                table: "OrderItems",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductsListItemId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductsId",
                table: "OrderItems",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
