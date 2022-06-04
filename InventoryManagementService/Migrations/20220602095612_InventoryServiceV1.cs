using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryService.Migrations
{
    public partial class InventoryServiceV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryTbl",
                columns: table => new
                {
                    FlightNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirlineNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduleDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstrumentUsed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessClassSeat = table.Column<int>(type: "int", nullable: true),
                    NonBusinessClassSeat = table.Column<int>(type: "int", nullable: true),
                    TicketCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NoOfRows = table.Column<int>(type: "int", nullable: true),
                    Meal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTbl", x => x.FlightNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryTbl");
        }
    }
}
