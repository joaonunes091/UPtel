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

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacao_Users_UsersId",
                table: "Reclamacao");

            migrationBuilder.DropIndex(
                name: "IX_Reclamacao_ReclamacaoId1",
                table: "Reclamacao");

            migrationBuilder.DropIndex(
                name: "IX_Reclamacao_UsersId",
                table: "Reclamacao");

            migrationBuilder.DropColumn(
                name: "ReclamacaoId1",
                table: "Reclamacao");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Reclamacao",
                newName: "FuncionarioId");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Reclamacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacao_ContartoId",
                table: "Reclamacao",
                column: "ContartoId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ReclamacaoId",
                table: "Feedback",
                column: "ReclamacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Reclamacao_ReclamacaoId",
                table: "Feedback",
                column: "ReclamacaoId",
                principalTable: "Reclamacao",
                principalColumn: "ReclamacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacao_Contratos_ContartoId",
                table: "Reclamacao",
                column: "ContartoId",
                principalTable: "Contratos",
                principalColumn: "ContratoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Reclamacao_ReclamacaoId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacao_Contratos_ContartoId",
                table: "Reclamacao");

            migrationBuilder.DropIndex(
                name: "IX_Reclamacao_ContartoId",
                table: "Reclamacao");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_ReclamacaoId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Reclamacao");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "Reclamacao",
                newName: "UsersId");

            migrationBuilder.AddColumn<int>(
                name: "ReclamacaoId1",
                table: "Reclamacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacao_ReclamacaoId1",
                table: "Reclamacao",
                column: "ReclamacaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacao_UsersId",
                table: "Reclamacao",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacao_Reclamacao_ReclamacaoId1",
                table: "Reclamacao",
                column: "ReclamacaoId1",
                principalTable: "Reclamacao",
                principalColumn: "ReclamacaoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacao_Users_UsersId",
                table: "Reclamacao",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
