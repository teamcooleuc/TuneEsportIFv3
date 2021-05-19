using Microsoft.EntityFrameworkCore.Migrations;

namespace TuneEsportIFv2.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    gameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.gameID);
                });

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    infoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profilPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank = table.Column<int>(type: "int", nullable: false),
                    team = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    union = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nick = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.infoId);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    mapsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mapsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    infernoStats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gamesgameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.mapsId);
                    table.ForeignKey(
                        name: "FK_Maps_Games_gamesgameID",
                        column: x => x.gamesgameID,
                        principalTable: "Games",
                        principalColumn: "gameID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScoreBoard",
                columns: table => new
                {
                    ScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Records = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mapsId = table.Column<int>(type: "int", nullable: true),
                    gamesgameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreBoard", x => x.ScoreId);
                    table.ForeignKey(
                        name: "FK_ScoreBoard_Games_gamesgameID",
                        column: x => x.gamesgameID,
                        principalTable: "Games",
                        principalColumn: "gameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScoreBoard_Maps_mapsId",
                        column: x => x.mapsId,
                        principalTable: "Maps",
                        principalColumn: "mapsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maps_gamesgameID",
                table: "Maps",
                column: "gamesgameID");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoard_gamesgameID",
                table: "ScoreBoard",
                column: "gamesgameID");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreBoard_mapsId",
                table: "ScoreBoard",
                column: "mapsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "ScoreBoard");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
