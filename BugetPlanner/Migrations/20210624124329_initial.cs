using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugetPlanner.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InkomstUitgave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bedrag = table.Column<int>(type: "int", nullable: false),
                    Inkomst = table.Column<bool>(type: "bit", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InkomstUitgave", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InkomstUitgave");
        }
    }
}
