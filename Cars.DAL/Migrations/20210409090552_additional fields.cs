using Microsoft.EntityFrameworkCore.Migrations;

namespace Geekymon2.CarsApi.Cars.DAL.Migrations
{
    public partial class additionalfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Odometer",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odometer",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");
        }
    }
}
