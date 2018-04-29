using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameWeb.Data.Migrations
{
    public partial class AddedGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GalleryScreenshots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryScreenshots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScreenshotsTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    GalleryScreenshotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenshotsTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScreenshotsTags_GalleryScreenshots_GalleryScreenshotId",
                        column: x => x.GalleryScreenshotId,
                        principalTable: "GalleryScreenshots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScreenshotsTags_GalleryScreenshotId",
                table: "ScreenshotsTags",
                column: "GalleryScreenshotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScreenshotsTags");

            migrationBuilder.DropTable(
                name: "GalleryScreenshots");
        }
    }
}
