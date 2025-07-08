using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowTime.Migrations
{
    /// <inheritdoc />
    public partial class AddingFestivalBands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FestivalBands",
                columns: table => new
                {
                    FestivalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalBands", x => new { x.FestivalId, x.BandId });
                    table.ForeignKey(
                        name: "FK_FestivalBands_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FestivalBands_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FestivalBands_BandId",
                table: "FestivalBands",
                column: "BandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FestivalBands");
        }
    }
}
