using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaderboardAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterRacerTable_TotalNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalOfStart",
                table: "racers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalOfStart",
                table: "racers");
        }
    }
}
