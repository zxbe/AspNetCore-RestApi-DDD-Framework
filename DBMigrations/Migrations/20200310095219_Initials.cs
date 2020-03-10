using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBMigrations.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true, defaultValueSql: "true"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    CreatorId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    NameFirst = table.Column<string>(maxLength: 20, nullable: false),
                    NameSecond = table.Column<string>(maxLength: 20, nullable: false),
                    NamePatronymic = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "null"),
                    Phone = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "null"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    Roles = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Code",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    CreatorId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: true),
                    AppVersion = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true, defaultValueSql: "null"),
                    Token = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_Users_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Token_UserId",
                table: "Token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
