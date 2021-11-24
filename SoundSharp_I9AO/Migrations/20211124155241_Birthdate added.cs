using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoundSharp_I9AO.Migrations
{
    public partial class Birthdateadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "OWNER",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "OWNER");
        }
    }
}
