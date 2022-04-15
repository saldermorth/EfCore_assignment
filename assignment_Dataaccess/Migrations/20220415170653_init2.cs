using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment_Dataaccess.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Order_Items_Order_ItemId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Items",
                table: "Order_Items");

            migrationBuilder.RenameTable(
                name: "Order_Items",
                newName: "OrderItemsConnection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemsConnection",
                table: "OrderItemsConnection",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_OrderItemsConnection_Order_ItemId",
                table: "OrderItems",
                column: "Order_ItemId",
                principalTable: "OrderItemsConnection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_OrderItemsConnection_Order_ItemId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemsConnection",
                table: "OrderItemsConnection");

            migrationBuilder.RenameTable(
                name: "OrderItemsConnection",
                newName: "Order_Items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Items",
                table: "Order_Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Order_Items_Order_ItemId",
                table: "OrderItems",
                column: "Order_ItemId",
                principalTable: "Order_Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
