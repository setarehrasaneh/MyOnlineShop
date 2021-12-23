using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOnlineShop.DataAccess.Migrations
{
    public partial class AddDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "discount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discount",
                table: "Orders");
        }
    }
}
