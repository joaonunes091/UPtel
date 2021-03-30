using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class AlteracaoModeloER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Reclamacao");

            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "Reclamacao");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Feedback");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Reclamacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "Reclamacao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
