using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaderboardAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_RacerStar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_racersStatrs_racers_RacerId",
                table: "racersStatrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_racersStatrs",
                table: "racersStatrs");

            migrationBuilder.RenameTable(
                name: "racersStatrs",
                newName: "racersStart");

            migrationBuilder.RenameIndex(
                name: "IX_racersStatrs_RacerId",
                table: "racersStart",
                newName: "IX_racersStart_RacerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_racersStart",
                table: "racersStart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_racersStart_racers_RacerId",
                table: "racersStart",
                column: "RacerId",
                principalTable: "racers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_racersStart_racers_RacerId",
                table: "racersStart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_racersStart",
                table: "racersStart");

            migrationBuilder.RenameTable(
                name: "racersStart",
                newName: "racersStatrs");

            migrationBuilder.RenameIndex(
                name: "IX_racersStart_RacerId",
                table: "racersStatrs",
                newName: "IX_racersStatrs_RacerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_racersStatrs",
                table: "racersStatrs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_racersStatrs_racers_RacerId",
                table: "racersStatrs",
                column: "RacerId",
                principalTable: "racers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
