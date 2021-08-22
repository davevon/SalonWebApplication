using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonWebApplication.Data.Migrations
{
    public partial class ProblemsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Productprice",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Productprice",
                table: "Orders");
        }
    }
}
