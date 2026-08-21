using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    FavoriteColor = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FavoriteColor", "Name", "Password", "Role" },
                values: new object[] { 3522, "blue", "BentEnt", "oeHsJMHi9cmGeeV3Y+ED/w1uepLiuGULSAtsoH/eneI=", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "BandId", "Caption", "DateUploaded", "DisplayOrder", "Name", "VideoUrl" },
                values: new object[,]
                {
                    { 1, 2, "Girls Got Rhythm At Mrs Olsons!", new DateOnly(2026, 7, 19), 0, "Girls Got Rhythm At Mrs Olsons", "https://www.dropbox.com/scl/fi/on30us31lel4t0gdiki4z/Video-Jul-20-2026-11-43-39-PM.mp4?rlkey=mznodpq2plhkdcuoqdkxwr0rq&st=xs9zskw3&raw=1" },
                    { 2, 1, "There's Only One Way to Rock!", new DateOnly(2026, 7, 19), 0, "One Way to rock", "https://www.dropbox.com/scl/fi/zq9ieuxymrsj5hah8n6x7/Video-Jul-19-2026-2-23-11-PM.mp4?rlkey=k2ecapfc1txigldxvis9qs1yz&st=of67g5ba&raw=1" }
                });
        }
    }
}
