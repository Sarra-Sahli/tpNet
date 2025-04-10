using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class api : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "myPlanes",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneCapacity = table.Column<int>(type: "int", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "date", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myPlanes", x => x.PlaneId);
                });

            migrationBuilder.CreateTable(
                name: "passanger",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassFirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PassLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passanger", x => x.PassportNumber);
                });

            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveArrival = table.Column<DateTime>(type: "date", nullable: false),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: false),
                    FlightDate = table.Column<DateTime>(type: "date", nullable: false),
                    AirlineLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaneFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_flights_myPlanes_PlaneFK",
                        column: x => x.PlaneFK,
                        principalTable: "myPlanes",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    EmployementDate = table.Column<DateTime>(type: "date", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_Staff_passanger_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "passanger",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Traveller",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    HealthInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traveller", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_Traveller_passanger_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "passanger",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightPassenger",
                columns: table => new
                {
                    FlightsFlightId = table.Column<int>(type: "int", nullable: false),
                    PassengersPassportNumber = table.Column<string>(type: "nvarchar(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPassenger", x => new { x.FlightsFlightId, x.PassengersPassportNumber });
                    table.ForeignKey(
                        name: "FK_FlightPassenger_flights_FlightsFlightId",
                        column: x => x.FlightsFlightId,
                        principalTable: "flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightPassenger_passanger_PassengersPassportNumber",
                        column: x => x.PassengersPassportNumber,
                        principalTable: "passanger",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_PassengersPassportNumber",
                table: "FlightPassenger",
                column: "PassengersPassportNumber");

            migrationBuilder.CreateIndex(
                name: "IX_flights_PlaneFK",
                table: "flights",
                column: "PlaneFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightPassenger");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Traveller");

            migrationBuilder.DropTable(
                name: "flights");

            migrationBuilder.DropTable(
                name: "passanger");

            migrationBuilder.DropTable(
                name: "myPlanes");
        }
    }
}
