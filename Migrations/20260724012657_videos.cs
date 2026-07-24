using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class videos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            

            

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    YoutubeId = table.Column<string>(type: "TEXT", nullable: false),
                    DateUploaded = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    BandId = table.Column<int>(type: "INTEGER", nullable: false),
                    Caption = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "BandId", "Caption", "DateUploaded", "Name", "YoutubeId" },
                values: new object[,]
                {
                    { 1, 2, "Don plays some jazzy acoustic!", new DateOnly(2016, 7, 23), "Don plays Black Beauty", "o-Vw1tbGLtw" },
                    { 2, 1, "Look at our cool band!", new DateOnly(2016, 7, 23), "Psychedelic RoadShow sizzle", "VWN9nuJODs0" }
                });

            
            migrationBuilder.CreateIndex(
                name: "IX_Videos_BandId",
                table: "Videos",
                column: "BandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "Videos");

        }
    }
}
