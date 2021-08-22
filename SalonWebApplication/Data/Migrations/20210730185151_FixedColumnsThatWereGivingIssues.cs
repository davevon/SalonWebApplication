using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonWebApplication.Data.Migrations
{
    public partial class FixedColumnsThatWereGivingIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Productprice",
                table: "Orders",
                newName: "ProductPrices");

            migrationBuilder.RenameColumn(
                name: "ProductQuantity",
                table: "Orders",
                newName: "ProductQuantities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductQuantities",
                table: "Orders",
                newName: "ProductQuantity");

            migrationBuilder.RenameColumn(
                name: "ProductPrices",
                table: "Orders",
                newName: "Productprice");
        }
    }
}
