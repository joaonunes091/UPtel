using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class ListaContratos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientesViewModelId",
                table: "Contratos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ClientesViewModelId",
                table: "Contratos",
                column: "ClientesViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_ClientesViewModel_ClientesViewModelId",
                table: "Contratos",
                column: "ClientesViewModelId",
                principalTable: "ClientesViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_ClientesViewModel_ClientesViewModelId",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_ClientesViewModelId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "ClientesViewModelId",
                table: "Contratos");
        }
    }
}
