using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Treinamento.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SALTS",
                columns: table => new
                {
                    SaltId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaltUser = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALTS", x => x.SaltId);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.UsersId);
                    table.ForeignKey(
                        name: "FK_USERS_SALTS_Salt_FK",
                        column: x => x.Salt_FK,
                        principalTable: "SALTS",
                        principalColumn: "SaltId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Salt_FK",
                table: "USERS",
                column: "Salt_FK",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "SALTS");
        }
    }
}
