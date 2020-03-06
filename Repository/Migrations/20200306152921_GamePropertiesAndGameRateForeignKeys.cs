using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Data.Migrations
{
    public partial class GamePropertiesAndGameRateForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameId",
                table: "GamesRates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "GamesRates",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AvgRating",
                table: "Games",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Games",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Releaser",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamesRates_GameId",
                table: "GamesRates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesRates_UserId",
                table: "GamesRates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesRates_Games_GameId",
                table: "GamesRates",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GamesRates_AspNetUsers_UserId",
                table: "GamesRates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesRates_Games_GameId",
                table: "GamesRates");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesRates_AspNetUsers_UserId",
                table: "GamesRates");

            migrationBuilder.DropIndex(
                name: "IX_GamesRates_GameId",
                table: "GamesRates");

            migrationBuilder.DropIndex(
                name: "IX_GamesRates_UserId",
                table: "GamesRates");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GamesRates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GamesRates");

            migrationBuilder.DropColumn(
                name: "AvgRating",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Releaser",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Games");
        }
    }
}
