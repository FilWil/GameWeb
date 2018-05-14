using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameWeb.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                "UserNameIndex",
                "AspNetUsers");

            migrationBuilder.DropIndex(
                "IX_AspNetUserRoles_UserId",
                "AspNetUserRoles");

            migrationBuilder.DropIndex(
                "RoleNameIndex",
                "AspNetRoles");

            migrationBuilder.CreateTable(
                "Games",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Genre = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    ReleaseYear = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Games", x => x.Id); });

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                "FK_AspNetUserTokens_AspNetUsers_UserId",
                "AspNetUserTokens",
                "UserId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_AspNetUserTokens_AspNetUsers_UserId",
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "Games");

            migrationBuilder.DropIndex(
                "UserNameIndex",
                "AspNetUsers");

            migrationBuilder.DropIndex(
                "RoleNameIndex",
                "AspNetRoles");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_UserId",
                "AspNetUserRoles",
                "UserId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName");
        }
    }
}