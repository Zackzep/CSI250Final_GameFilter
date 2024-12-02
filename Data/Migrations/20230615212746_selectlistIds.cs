using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSI250Final_GameFilter.Data.Migrations
{
    public partial class selectlistIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelectedGenreId",
                table: "BoardGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelectedPublisherId",
                table: "BoardGames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedGenreId",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "SelectedPublisherId",
                table: "BoardGames");
        }
    }
}
