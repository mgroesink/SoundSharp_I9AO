using Microsoft.EntityFrameworkCore.Migrations;

namespace SoundSharp_I9AO.Migrations
{
    public partial class Licenseplateadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LicensePlate",
                table: "OWNER",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlate",
                table: "OWNER");
        }
    }
}
