using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _07_EF_example.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "MaxPassangers", "Model" },
                values: new object[] { 1, 1200, "Antonov 125" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "MaxPassangers", "Model" },
                values: new object[] { 2, 1300, "Boeing 747" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Number", "AirplaneId", "ArrivalCity", "ArrivalTime", "DepartureCity", "DepartureTime", "Rating" },
                values: new object[] { 1, 1, "Lviv", new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyiv", new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Number", "AirplaneId", "ArrivalCity", "ArrivalTime", "DepartureCity", "DepartureTime", "Rating" },
                values: new object[] { 2, 2, "Lviv", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warsaw", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Number",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Number",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
