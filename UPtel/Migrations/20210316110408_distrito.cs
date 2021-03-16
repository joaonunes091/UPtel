using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class distrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegisto",
                table: "Users",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DistritoId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    DistritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistritoNome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistritoNome", x => x.DistritoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DistritoId",
                table: "Users",
                column: "DistritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Distrito",
                table: "Users",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "DistritoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Distrito",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropIndex(
                name: "IX_Users_DistritoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DataRegisto",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "Users");
        }
    }
}
