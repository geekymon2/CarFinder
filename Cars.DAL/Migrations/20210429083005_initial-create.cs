using Microsoft.EntityFrameworkCore.Migrations;

namespace Geekymon2.CarsApi.Cars.DAL.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NoOfCylinders = table.Column<int>(type: "int", nullable: false),
                    EngineSizeCC = table.Column<int>(type: "int", nullable: false),
                    PowerKW = table.Column<int>(type: "int", nullable: false),
                    CylinderConfig = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    DriveType = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    FuelEconomy = table.Column<double>(type: "float", nullable: false),
                    PowerToWeight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Gears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Make = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Doors = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Odometer = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineID = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    TransmissionID = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cars_Engine_EngineID",
                        column: x => x.EngineID,
                        principalTable: "Engine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Transmission_TransmissionID",
                        column: x => x.TransmissionID,
                        principalTable: "Transmission",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarID = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Feature_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineID",
                table: "Cars",
                column: "EngineID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionID",
                table: "Cars",
                column: "TransmissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Feature_CarID",
                table: "Feature",
                column: "CarID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "Transmission");
        }
    }
}
