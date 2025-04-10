using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    FlightFK = table.Column<int>(type: "int", nullable: false),
                    PassengerFK = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    Siege = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.FlightFK, x.PassengerFK });
                    table.ForeignKey(
                        name: "FK_Tickets_flights_FlightFK",
                        column: x => x.FlightFK,
                        principalTable: "flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_passanger_PassengerFK",
                        column: x => x.PassengerFK,
                        principalTable: "passanger",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerFK",
                table: "Tickets",
                column: "PassengerFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
