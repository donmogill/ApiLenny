using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class video_displayOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Videos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateUploaded", "DisplayOrder" },
                values: new object[] { new DateOnly(2016, 7, 24), 0 });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateUploaded", "DisplayOrder" },
                values: new object[] { new DateOnly(2016, 7, 24), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Videos");

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateUploaded",
                value: new DateOnly(2016, 7, 23));

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateUploaded",
                value: new DateOnly(2016, 7, 23));
        }
    }
}
