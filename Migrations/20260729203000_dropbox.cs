using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class dropbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YoutubeId",
                table: "Videos",
                newName: "VideoUrl");

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Caption", "DateUploaded", "Name", "VideoUrl" },
                values: new object[] { "Girls Got Rhythm At Mrs Olsons!", new DateOnly(2026, 7, 19), "Girls Got Rhythm At Mrs Olsons", "https://www.dropbox.com/scl/fi/on30us31lel4t0gdiki4z/Video-Jul-20-2026-11-43-39-PM.mp4?rlkey=mznodpq2plhkdcuoqdkxwr0rq&st=xs9zskw3&raw=1" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Caption", "DateUploaded", "Name", "VideoUrl" },
                values: new object[] { "There's Only One Way to Rock!", new DateOnly(2026, 7, 19), "One Way to rock", "https://www.dropbox.com/scl/fi/zq9ieuxymrsj5hah8n6x7/Video-Jul-19-2026-2-23-11-PM.mp4?rlkey=k2ecapfc1txigldxvis9qs1yz&st=of67g5ba&raw=1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Videos",
                newName: "YoutubeId");

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Caption", "DateUploaded", "Name", "YoutubeId" },
                values: new object[] { "Don plays some jazzy acoustic!", new DateOnly(2016, 7, 24), "Don plays Black Beauty", "o-Vw1tbGLtw" });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Caption", "DateUploaded", "Name", "YoutubeId" },
                values: new object[] { "Look at our cool band!", new DateOnly(2016, 7, 24), "Psychedelic RoadShow sizzle", "VWN9nuJODs0" });
        }
    }
}
