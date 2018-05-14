using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameWeb.Data.Migrations
{
    public partial class AddedGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "GalleryScreenshots",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_GalleryScreenshots", x => x.Id); });

            migrationBuilder.CreateTable(
                "ScreenshotsTags",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    GalleryScreenshotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenshotsTags", x => x.Id);
                    table.ForeignKey(
                        "FK_ScreenshotsTags_GalleryScreenshots_GalleryScreenshotId",
                        x => x.GalleryScreenshotId,
                        "GalleryScreenshots",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_ScreenshotsTags_GalleryScreenshotId",
                "ScreenshotsTags",
                "GalleryScreenshotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "ScreenshotsTags");

            migrationBuilder.DropTable(
                "GalleryScreenshots");
        }
    }
}