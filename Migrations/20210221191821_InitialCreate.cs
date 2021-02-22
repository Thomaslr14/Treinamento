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
                    SaltID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaltUser = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALTS", x => x.SaltID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    UsersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SaltID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.UsersID);
                    table.ForeignKey(
                        name: "FK_USERS_SALTS_SaltID_FK",
                        column: x => x.SaltID_FK,
                        principalTable: "SALTS",
                        principalColumn: "SaltID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USERS_SaltID_FK",
                table: "USERS",
                column: "SaltID_FK");
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
