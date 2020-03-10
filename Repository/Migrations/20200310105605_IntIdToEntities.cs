using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Data.Migrations
{
    public partial class IntIdToEntities : Migration
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
                name: "GameRateId",
                table: "GamesRates");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "GamesRates",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GamesRates",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Games",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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
                name: "Id",
                table: "GamesRates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "GameId",
                table: "GamesRates",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameRateId",
                table: "GamesRates",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GameId",
                table: "Games",
                type: "nvarchar(450)",
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
    }
}
