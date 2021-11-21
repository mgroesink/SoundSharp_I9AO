using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoundSharp_I9AO.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OWNER",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    middlename = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    postalcode = table.Column<string>(type: "char(6)", unicode: false, fixedLength: true, maxLength: 6, nullable: false),
                    street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    housenumber = table.Column<short>(type: "smallint", nullable: false),
                    housenumber_add = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWNER", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TRACK",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    artist = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    albumsource = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    style = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    length = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRACK", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AUDIODEVICE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    price_ex_btw = table.Column<decimal>(type: "numeric(6,2)", nullable: true),
                    btw = table.Column<decimal>(type: "numeric(3,1)", nullable: true),
                    OWNER_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDIODEVICE", x => x.id);
                    table.ForeignKey(
                        name: "AUDIODEVICE_OWNER_FK",
                        column: x => x.OWNER_id,
                        principalTable: "OWNER",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CDDISCMAN",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    mbsize = table.Column<int>(type: "int", nullable: false),
                    displaywidth = table.Column<int>(type: "int", nullable: false),
                    displayheight = table.Column<int>(type: "int", nullable: false),
                    is_ejected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDDISCMAN", x => x.id);
                    table.ForeignKey(
                        name: "CDDISCMAN_AUDIODEVICE_FK",
                        column: x => x.id,
                        principalTable: "AUDIODEVICE",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEMORECORDER",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    max_cartridge_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEMORECORDER", x => x.id);
                    table.ForeignKey(
                        name: "MEMORECORDER_AUDIODEVICE_FK",
                        column: x => x.id,
                        principalTable: "AUDIODEVICE",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MP3PLAYER",
                columns: table => new
                {
                    serialid = table.Column<int>(type: "int", nullable: false),
                    mbsize = table.Column<int>(type: "int", nullable: true),
                    displaywidth = table.Column<int>(type: "int", nullable: false),
                    displayheight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MP3PLAYER_PK", x => x.serialid);
                    table.ForeignKey(
                        name: "MP3PLAYER_AUDIODEVICE_FK",
                        column: x => x.serialid,
                        principalTable: "AUDIODEVICE",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLAYLIST",
                columns: table => new
                {
                    PLAYLIST_ID = table.Column<decimal>(type: "numeric(28,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<short>(type: "smallint", nullable: false),
                    MP3PLAYER_serialid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAYLIST", x => x.PLAYLIST_ID);
                    table.ForeignKey(
                        name: "PLAYLIST_MP3PLAYER_FK",
                        column: x => x.MP3PLAYER_serialid,
                        principalTable: "MP3PLAYER",
                        principalColumn: "serialid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relation_2",
                columns: table => new
                {
                    TRACK_id = table.Column<int>(type: "int", nullable: false),
                    PLAYLIST_PLAYLIST_ID = table.Column<decimal>(type: "numeric(28,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Relation_2_PK", x => new { x.TRACK_id, x.PLAYLIST_PLAYLIST_ID });
                    table.ForeignKey(
                        name: "Relation_2_PLAYLIST_FK",
                        column: x => x.PLAYLIST_PLAYLIST_ID,
                        principalTable: "PLAYLIST",
                        principalColumn: "PLAYLIST_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Relation_2_TRACK_FK",
                        column: x => x.TRACK_id,
                        principalTable: "TRACK",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUDIODEVICE_OWNER_id",
                table: "AUDIODEVICE",
                column: "OWNER_id");

            migrationBuilder.CreateIndex(
                name: "IX_PLAYLIST_MP3PLAYER_serialid",
                table: "PLAYLIST",
                column: "MP3PLAYER_serialid");

            migrationBuilder.CreateIndex(
                name: "IX_Relation_2_PLAYLIST_PLAYLIST_ID",
                table: "Relation_2",
                column: "PLAYLIST_PLAYLIST_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CDDISCMAN");

            migrationBuilder.DropTable(
                name: "MEMORECORDER");

            migrationBuilder.DropTable(
                name: "Relation_2");

            migrationBuilder.DropTable(
                name: "PLAYLIST");

            migrationBuilder.DropTable(
                name: "TRACK");

            migrationBuilder.DropTable(
                name: "MP3PLAYER");

            migrationBuilder.DropTable(
                name: "AUDIODEVICE");

            migrationBuilder.DropTable(
                name: "OWNER");
        }
    }
}
