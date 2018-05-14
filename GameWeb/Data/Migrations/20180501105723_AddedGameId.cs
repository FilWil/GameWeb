using Microsoft.EntityFrameworkCore.Migrations;

namespace GameWeb.Data.Migrations
{
    public partial class AddedGameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "GameId",
                "GalleryScreenshots",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "GameId",
                "GalleryScreenshots");
        }
    }
}