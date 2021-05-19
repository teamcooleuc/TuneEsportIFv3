using Microsoft.EntityFrameworkCore.Migrations;

namespace TuneEsportIFv2.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EconomyKnowledge",
                table: "ScoreBoard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Smokes",
                table: "ScoreBoard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tactics",
                table: "ScoreBoard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mapKnowledge",
                table: "ScoreBoard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nick",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilPicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Union",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EconomyKnowledge",
                table: "ScoreBoard");

            migrationBuilder.DropColumn(
                name: "Smokes",
                table: "ScoreBoard");

            migrationBuilder.DropColumn(
                name: "Tactics",
                table: "ScoreBoard");

            migrationBuilder.DropColumn(
                name: "mapKnowledge",
                table: "ScoreBoard");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nick",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilPicture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Union",
                table: "AspNetUsers");
        }
    }
}
