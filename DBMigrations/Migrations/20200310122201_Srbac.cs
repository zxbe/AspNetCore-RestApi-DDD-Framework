using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBMigrations.Migrations
{
    public partial class Srbac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SrbacRolePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    Permission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrbacRolePermission", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SrbacRolePermission_Role_Permission",
                table: "SrbacRolePermission",
                columns: new[] { "Role", "Permission" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SrbacRolePermission");
        }
    }
}
