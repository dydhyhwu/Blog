using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Core.Migrations
{
    public partial class add_cloud_account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TencentCloudAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    AppId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SecretId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SecretKey = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TencentCloudAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CosProvider",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: true),
                    Region = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    BucketName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    AllowPrefix = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    AllowActions = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CosProvider_TencentCloudAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "TencentCloudAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CosProvider_AccountId",
                table: "CosProvider",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CosProvider");

            migrationBuilder.DropTable(
                name: "TencentCloudAccount");
        }
    }
}
