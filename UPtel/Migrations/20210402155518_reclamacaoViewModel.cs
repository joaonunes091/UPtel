using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class reclamacaoViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriçao",
                table: "Reclamacao",
                newName: "Descricao");

            migrationBuilder.AddColumn<int>(
                name: "FeedbackId1",
                table: "Feedback",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReclamacaoViewModelId",
                table: "Feedback",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReclamacaoViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReclamacaoId = table.Column<int>(type: "int", nullable: false),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResolvidoOperador = table.Column<bool>(type: "bit", nullable: false),
                    ResolvidoCliente = table.Column<bool>(type: "bit", nullable: false),
                    DataReclamacao = table.Column<DateTime>(type: "date", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFeedback = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamacaoViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_FeedbackId1",
                table: "Feedback",
                column: "FeedbackId1");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ReclamacaoViewModelId",
                table: "Feedback",
                column: "ReclamacaoViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Feedback_FeedbackId1",
                table: "Feedback",
                column: "FeedbackId1",
                principalTable: "Feedback",
                principalColumn: "FeedbackId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_ReclamacaoViewModel_ReclamacaoViewModelId",
                table: "Feedback",
                column: "ReclamacaoViewModelId",
                principalTable: "ReclamacaoViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Feedback_FeedbackId1",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_ReclamacaoViewModel_ReclamacaoViewModelId",
                table: "Feedback");

            migrationBuilder.DropTable(
                name: "ReclamacaoViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_FeedbackId1",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_ReclamacaoViewModelId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "FeedbackId1",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ReclamacaoViewModelId",
                table: "Feedback");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Reclamacao",
                newName: "Descriçao");
        }
    }
}
