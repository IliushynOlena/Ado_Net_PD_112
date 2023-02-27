using Microsoft.EntityFrameworkCore.Migrations;

namespace data_access_entity.Migrations
{
    public partial class ChangeManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFlight");

            migrationBuilder.CreateTable(
                name: "ClientFligth",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFligth", x => new { x.FlightId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_ClientFligth_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFligth_Passengers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Passengers",
                        principalColumn: "CredentialsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientFligth",
                columns: new[] { "ClientId", "FlightId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ClientFligth",
                columns: new[] { "ClientId", "FlightId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFligth_ClientId",
                table: "ClientFligth",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFligth");

            migrationBuilder.CreateTable(
                name: "ClientFlight",
                columns: table => new
                {
                    ClientsCredentialsId = table.Column<int>(type: "int", nullable: false),
                    FlightsNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFlight", x => new { x.ClientsCredentialsId, x.FlightsNumber });
                    table.ForeignKey(
                        name: "FK_ClientFlight_Flights_FlightsNumber",
                        column: x => x.FlightsNumber,
                        principalTable: "Flights",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFlight_Passengers_ClientsCredentialsId",
                        column: x => x.ClientsCredentialsId,
                        principalTable: "Passengers",
                        principalColumn: "CredentialsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFlight_FlightsNumber",
                table: "ClientFlight",
                column: "FlightsNumber");
        }
    }
}
