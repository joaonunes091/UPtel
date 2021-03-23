using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class reclamacaoKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReclamacaoId1",
                table: "Reclamacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacao_ReclamacaoId1",
                table: "Reclamacao",
                column: "ReclamacaoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacao_Reclamacao_ReclamacaoId1",
                table: "Reclamacao",
                column: "ReclamacaoId1",
                principalTable: "Reclamacao",
                principalColumn: "ReclamacaoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacao_Reclamacao_ReclamacaoId1",
                table: "Reclamacao");

            migrationBuilder.DropIndex(
                name: "IX_Reclamacao_ReclamacaoId1",
                table: "Reclamacao");

            migrationBuilder.DropColumn(
                name: "ReclamacaoId1",
                table: "Reclamacao");
        }
    }
}
