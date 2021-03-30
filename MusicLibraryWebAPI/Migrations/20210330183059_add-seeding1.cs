using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicLibraryWebAPI.Migrations
{
    public partial class addseeding1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "Artist", "ReleaseDate", "Title" },
                values: new object[] { 1, "The Rolling Stones Greatest Hits", "The Rolling Stones", new DateTime(1975, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paint it Black" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "Artist", "ReleaseDate", "Title" },
                values: new object[] { 2, "Back in Black", "AC/DC", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Back in Black" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
