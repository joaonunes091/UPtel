using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class ModelosNovos : Migration
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
                name: "Preco",
                table: "Pacotes");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "NetMovel");

            migrationBuilder.AlterColumn<string>(
                name: "Designacao",
                table: "TipoClientes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoPacoteTelevisao",
                table: "Televisao",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoPacoteTelemovel",
                table: "Telemovel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoPacoteTelefone",
                table: "Telefone",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Desconto",
                table: "Promocoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PromoCanais",
                table: "Promocoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoTotal",
                table: "Pacotes",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoNetMovel",
                table: "NetMovel",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoNetFixa",
                table: "NetFixa",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoContrato",
                table: "Contratos",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPostalExt",
                table: "Clientes",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoCanais",
                table: "Canais",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoPacoteTelevisao",
                table: "Televisao");

            migrationBuilder.DropColumn(
                name: "PrecoPacoteTelemovel",
                table: "Telemovel");

            migrationBuilder.DropColumn(
                name: "PrecoPacoteTelefone",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "Desconto",
                table: "Promocoes");

            migrationBuilder.DropColumn(
                name: "PromoCanais",
                table: "Promocoes");

            migrationBuilder.DropColumn(
                name: "PrecoTotal",
                table: "Pacotes");

            migrationBuilder.DropColumn(
                name: "PrecoNetMovel",
                table: "NetMovel");

            migrationBuilder.DropColumn(
                name: "PrecoNetFixa",
                table: "NetFixa");

            migrationBuilder.DropColumn(
                name: "PrecoContrato",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "PrecoCanais",
                table: "Canais");

            migrationBuilder.AlterColumn<string>(
                name: "Designacao",
                table: "TipoClientes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

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

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Pacotes",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "NetMovel",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPostalExt",
                table: "Clientes",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);
        }
    }
}
