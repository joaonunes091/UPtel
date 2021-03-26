using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "FeedbackData",
                table: "Reclamacao",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FeedbackDescricao",
                table: "Reclamacao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReclamacaoReclamacao",
                columns: table => new
                {
                    FeedbackClienteReclamacaoId = table.Column<int>(type: "int", nullable: false),
                    ReclamacoesClienteReclamacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamacaoReclamacao", x => new { x.FeedbackClienteReclamacaoId, x.ReclamacoesClienteReclamacaoId });
                    table.ForeignKey(
                        name: "FK_ReclamacaoReclamacao_Reclamacao_FeedbackClienteReclamacaoId",
                        column: x => x.FeedbackClienteReclamacaoId,
                        principalTable: "Reclamacao",
                        principalColumn: "ReclamacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReclamacaoReclamacao_Reclamacao_ReclamacoesClienteReclamacaoId",
                        column: x => x.ReclamacoesClienteReclamacaoId,
                        principalTable: "Reclamacao",
                        principalColumn: "ReclamacaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReclamacaoReclamacao_ReclamacoesClienteReclamacaoId",
                table: "ReclamacaoReclamacao",
                column: "ReclamacoesClienteReclamacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReclamacaoReclamacao");

            migrationBuilder.DropColumn(
                name: "FeedbackData",
                table: "Reclamacao");

            migrationBuilder.DropColumn(
                name: "FeedbackDescricao",
                table: "Reclamacao");

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
    }
}
