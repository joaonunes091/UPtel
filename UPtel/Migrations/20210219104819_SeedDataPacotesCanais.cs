using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class SeedDataPacotesCanais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CanalCanaisId",
                table: "PacoteCanais",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TelevisaoId1",
                table: "PacoteCanais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PacoteCanais_CanalCanaisId",
                table: "PacoteCanais",
                column: "CanalCanaisId");

            migrationBuilder.CreateIndex(
                name: "IX_PacoteCanais_TelevisaoId1",
                table: "PacoteCanais",
                column: "TelevisaoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PacoteCanais_Canais_CanalCanaisId",
                table: "PacoteCanais",
                column: "CanalCanaisId",
                principalTable: "Canais",
                principalColumn: "CanaisId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PacoteCanais_Televisao_TelevisaoId1",
                table: "PacoteCanais",
                column: "TelevisaoId1",
                principalTable: "Televisao",
                principalColumn: "TelevisaoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacoteCanais_Canais_CanalCanaisId",
                table: "PacoteCanais");

            migrationBuilder.DropForeignKey(
                name: "FK_PacoteCanais_Televisao_TelevisaoId1",
                table: "PacoteCanais");

            migrationBuilder.DropIndex(
                name: "IX_PacoteCanais_CanalCanaisId",
                table: "PacoteCanais");

            migrationBuilder.DropIndex(
                name: "IX_PacoteCanais_TelevisaoId1",
                table: "PacoteCanais");

            migrationBuilder.DropColumn(
                name: "CanalCanaisId",
                table: "PacoteCanais");

            migrationBuilder.DropColumn(
                name: "TelevisaoId1",
                table: "PacoteCanais");
        }
    }
}
