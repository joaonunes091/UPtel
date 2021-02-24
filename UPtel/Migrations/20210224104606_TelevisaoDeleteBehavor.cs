using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class TelevisaoDeleteBehavor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacoteCanais_Televisao",
                table: "PacoteCanais");

            migrationBuilder.AddForeignKey(
                name: "FK_PacoteCanais_Televisao",
                table: "PacoteCanais",
                column: "TelevisaoId",
                principalTable: "Televisao",
                principalColumn: "TelevisaoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacoteCanais_Televisao",
                table: "PacoteCanais");

            migrationBuilder.AddForeignKey(
                name: "FK_PacoteCanais_Televisao",
                table: "PacoteCanais",
                column: "TelevisaoId",
                principalTable: "Televisao",
                principalColumn: "TelevisaoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
