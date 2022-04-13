using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment_Dataaccess.Migrations
{
    public partial class nutsmixer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderEntityId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomersId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PriceLists_PriceId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Vendors_VendorsId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Products_PriceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_VendorsId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderItemsEntity");

            migrationBuilder.RenameColumn(
                name: "VendorsId",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomersId",
                table: "OrderItemsEntity",
                newName: "IX_OrderItemsEntity_CustomersId");

            migrationBuilder.AddColumn<string>(
                name: "Vendor",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Vendor",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "OrderItemsEntity",
                newName: "Orders");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "VendorsId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemsEntity_CustomersId",
                table: "Orders",
                newName: "IX_Orders_CustomersId");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "char(3)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PriceId",
                table: "Products",
                column: "PriceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendorsId",
                table: "Products",
                column: "VendorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Name",
                table: "Vendors",
                column: "Name",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PriceLists_PriceId",
                table: "Products",
                column: "PriceId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Vendors_VendorsId",
                table: "Products",
                column: "VendorsId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
