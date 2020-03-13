using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Data.Migrations
{
    public partial class RateStoreTypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Rate",
                table: "GamesRates",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "AvgRating",
                table: "Games",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "GamesRates",
                type: "float",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<double>(
                name: "AvgRating",
                table: "Games",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
