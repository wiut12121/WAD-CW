using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagnumStore.Migrations
{
    public partial class SpellingMistakeCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBrith",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBrith",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBrith",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBrith",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
