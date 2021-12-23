using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOnlineShop.DataAccess.Migrations
{
    public partial class addDiscountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discount",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountId",
                table: "Orders",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Discount_DiscountId",
                table: "Orders",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Discount_DiscountId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DiscountId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "discount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
