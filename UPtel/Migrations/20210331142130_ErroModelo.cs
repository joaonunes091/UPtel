using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class ErroModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacao_Contratos_ContartoId",
                table: "Reclamacao");

            migrationBuilder.RenameColumn(
                name: "ContartoId",
                table: "Reclamacao",
                newName: "ContratoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reclamacao_ContartoId",
                table: "Reclamacao",
                newName: "IX_Reclamacao_ContratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacao_Contratos_ContratoId",
                table: "Reclamacao",
                column: "ContratoId",
                principalTable: "Contratos",
                principalColumn: "ContratoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacao_Contratos_ContratoId",
                table: "Reclamacao");

            migrationBuilder.RenameColumn(
                name: "ContratoId",
                table: "Reclamacao",
                newName: "ContartoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reclamacao_ContratoId",
                table: "Reclamacao",
                newName: "IX_Reclamacao_ContartoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacao_Contratos_ContartoId",
                table: "Reclamacao",
                column: "ContartoId",
                principalTable: "Contratos",
                principalColumn: "ContratoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
