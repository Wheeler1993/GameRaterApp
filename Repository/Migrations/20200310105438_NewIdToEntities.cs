using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Data.Migrations
{
    public partial class NewIdToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesRates_Games_GameId",
                table: "GamesRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesRates",
                table: "GamesRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GamesRates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "GameRateId",
                table: "GamesRates",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "GamesRates",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "GameId",
                table: "Games",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesRates",
                table: "GamesRates",
                column: "GameRateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesRates_Games_GameId",
                table: "GamesRates",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesRates_Games_GameId",
                table: "GamesRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesRates",
                table: "GamesRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameRateId",
                table: "GamesRates");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "GamesRates");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "GamesRates",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesRates",
                table: "GamesRates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesRates_Games_GameId",
                table: "GamesRates",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
