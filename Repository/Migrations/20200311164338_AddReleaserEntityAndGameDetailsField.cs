using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Data.Migrations
{
    public partial class AddReleaserEntityAndGameDetailsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Releaser",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReleaserId",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Releasers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releasers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_ReleaserId",
                table: "Games",
                column: "ReleaserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Releasers_ReleaserId",
                table: "Games",
                column: "ReleaserId",
                principalTable: "Releasers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Releasers_ReleaserId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Releasers");

            migrationBuilder.DropIndex(
                name: "IX_Games_ReleaserId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ReleaserId",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Releaser",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
