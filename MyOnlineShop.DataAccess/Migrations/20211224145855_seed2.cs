using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOnlineShop.DataAccess.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price", "ProductType", "Profit" },
                values: new object[] { 6, "دمپایی پلاستیکی", "دمپایی", 30000.00m, 1, 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);
        }
    }
}
