using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class LogoCanaisViewCanais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Canais",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Canais");
        }
    }
}
