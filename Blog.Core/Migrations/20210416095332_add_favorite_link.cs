using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Core.Migrations
{
    public partial class add_favorite_link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Value = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NeedAuthorized = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuthorizeCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteLink_Content_Id",
                        column: x => x.Id,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteLink");

            migrationBuilder.DropTable(
                name: "Content");
        }
    }
}
