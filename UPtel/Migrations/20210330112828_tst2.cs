using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class tst2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reclamacao_FuncionarioId",
                table: "Reclamacao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_FuncionarioId",
                table: "Feedback",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Users_FuncionarioId",
                table: "Feedback",
                column: "FuncionarioId",
                principalTable: "Users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacao_Users_FuncionarioId",
                table: "Reclamacao",
                column: "FuncionarioId",
                principalTable: "Users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Users_FuncionarioId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacao_Users_FuncionarioId",
                table: "Reclamacao");

            migrationBuilder.DropIndex(
                name: "IX_Reclamacao_FuncionarioId",
                table: "Reclamacao");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_FuncionarioId",
                table: "Feedback");
        }
    }
}
