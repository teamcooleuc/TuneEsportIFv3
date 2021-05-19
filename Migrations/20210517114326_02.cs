using Microsoft.EntityFrameworkCore.Migrations;

namespace TuneEsportIFv2.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TuneEsportIfv2UserId",
                table: "ScoreBoard",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoard_TuneEsportIfv2UserId",
                table: "ScoreBoard",
                column: "TuneEsportIfv2UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreBoard_AspNetUsers_TuneEsportIfv2UserId",
                table: "ScoreBoard",
                column: "TuneEsportIfv2UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreBoard_AspNetUsers_TuneEsportIfv2UserId",
                table: "ScoreBoard");

            migrationBuilder.DropIndex(
                name: "IX_ScoreBoard_TuneEsportIfv2UserId",
                table: "ScoreBoard");

            migrationBuilder.DropColumn(
                name: "TuneEsportIfv2UserId",
                table: "ScoreBoard");
        }
    }
}
