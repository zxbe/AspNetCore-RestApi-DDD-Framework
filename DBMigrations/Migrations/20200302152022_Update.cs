using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBMigrations.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Code",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    DateExpiration = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    ReasonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Code", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Code_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Code_Code",
                table: "Code",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Code_UserId",
                table: "Code",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Token_Users_UserId",
                table: "Token",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_Users_UserId",
                table: "Token");

            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
