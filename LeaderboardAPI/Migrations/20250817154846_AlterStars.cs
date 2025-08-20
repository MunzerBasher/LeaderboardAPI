using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaderboardAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterStars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRad",
                table: "racersStart",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRad",
                table: "racersStart");
        }
    }
}
