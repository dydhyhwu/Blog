using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.EFCore.Migrations.Migrations
{
    public partial class codesnippet_title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CodeSnippet",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "CodeSnippet");
        }
    }
}
