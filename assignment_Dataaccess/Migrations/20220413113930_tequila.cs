using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment_Dataaccess.Migrations
{
    public partial class tequila : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "productsId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_productsId",
                table: "Orders",
                column: "productsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_Id",
                table: "OrderItems",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_productsId",
                table: "Orders",
                column: "productsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_Id",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_productsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_productsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "productsId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

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
    }
}
