using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Core.Migrations
{
    public partial class addProviderConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Host",
                table: "CosProvider",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadPrefix",
                table: "CosProvider",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Host",
                table: "CosProvider");

            migrationBuilder.DropColumn(
                name: "UploadPrefix",
                table: "CosProvider");
        }
    }
}
