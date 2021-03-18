using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class EdicaoClienteContrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EdicaoCliente",
                table: "Contratos",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EdicaoCliente",
                table: "Contratos");
        }
    }
}
