using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOnlineShop.DataAccess.Migrations
{
    public partial class seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Code", "DiscountType", "Value" },
                values: new object[,]
                {
                    { 1, "123-abc", 1, 10000m },
                    { 2, "456-def", 2, 50m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price", "ProductType", "Profit" },
                values: new object[,]
                {
                    { 5, "کفش چرم زنانه", "کفش زنانه", 190000.00m, 1, 200000m },
                    { 1, "تیشرت نخی مردانه", "تیشرت مردانه", 70000.00m, 1, 0m },
                    { 2, "گلدان شیشه ای متوسط", "گلدان شیشه ای", 190000.00m, 2, 80000m },
                    { 3, "دستبند زنجیر دار", "دستبند طلا", 8700000.00m, 1, 0m },
                    { 4, "سرویس چای خوری کریستال", "سرویس چای خوری", 500000.00m, 2, 0m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price", "ProductType", "Profit" },
                values: new object[] { 10, "کفش چرم زنانه", "کفش زنانه", 190000.00m, 1, 200000m });
        }
    }
}
