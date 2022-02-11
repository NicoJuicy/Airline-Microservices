using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Reservation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Journey_FlightId = table.Column<long>(type: "bigint", nullable: true),
                    Journey_DepartureAirportId = table.Column<long>(type: "bigint", nullable: true),
                    Journey_DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Journey_ArriveAirportId = table.Column<long>(type: "bigint", nullable: true),
                    Journey_ArriveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Journey_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassengerInfo_PassengerId = table.Column<long>(type: "bigint", nullable: true),
                    PassengerInfo_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation",
                schema: "dbo");
        }
    }
}
