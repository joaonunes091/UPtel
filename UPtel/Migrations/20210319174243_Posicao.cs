using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class Posicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeCliente",
                table: "OperadorViewModel",
                newName: "NomeOperador");

            migrationBuilder.AddColumn<int>(
                name: "Posicao",
                table: "Contratos",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Posicao",
                table: "Contratos");

            migrationBuilder.RenameColumn(
                name: "NomeOperador",
                table: "OperadorViewModel",
                newName: "NomeCliente");
        }
    }
}
