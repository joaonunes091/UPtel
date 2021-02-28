using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class alteracoesModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Telemovel");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "NetMovel");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Telemovel",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Telefone",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "NetMovel",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Telemovel");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "NetMovel");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Telemovel",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Telefone",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "NetMovel",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");
        }
    }
}
