using Microsoft.EntityFrameworkCore.Migrations;

namespace Geekymon2.CarsApi.Cars.DAL.Migrations
{
    public partial class updatedentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EngineID",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cylinders = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineID",
                table: "Cars",
                column: "EngineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Engine_EngineID",
                table: "Cars",
                column: "EngineID",
                principalTable: "Engine",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Engine_EngineID",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropIndex(
                name: "IX_Cars_EngineID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EngineID",
                table: "Cars");
        }
    }
}
