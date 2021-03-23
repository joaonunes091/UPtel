using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class PrecoTotalContratos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecoContrato",
                table: "Users",
                newName: "PrecoContratos");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoContratos",
                table: "ClientesViewModel",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoContratos",
                table: "ClientesViewModel");

            migrationBuilder.RenameColumn(
                name: "PrecoContratos",
                table: "Users",
                newName: "PrecoContrato");
        }
    }
}
