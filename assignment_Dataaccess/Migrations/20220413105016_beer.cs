using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment_Dataaccess.Migrations
{
    public partial class beer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_OrderItemsEntity_OrderEntityId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemsEntity_Customers_CustomersId",
                table: "OrderItemsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemsEntity",
                table: "OrderItemsEntity");

            migrationBuilder.RenameTable(
                name: "OrderItemsEntity",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemsEntity_CustomersId",
                table: "Orders",
                newName: "IX_Orders_CustomersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderEntityId",
                table: "OrderItems",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomersId",
                table: "Orders",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderEntityId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomersId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderItemsEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomersId",
                table: "OrderItemsEntity",
                newName: "IX_OrderItemsEntity_CustomersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemsEntity",
                table: "OrderItemsEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_OrderItemsEntity_OrderEntityId",
                table: "OrderItems",
                column: "OrderEntityId",
                principalTable: "OrderItemsEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemsEntity_Customers_CustomersId",
                table: "OrderItemsEntity",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
