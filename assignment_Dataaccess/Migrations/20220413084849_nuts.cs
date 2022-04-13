using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment_Dataaccess.Migrations
{
    public partial class nuts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
