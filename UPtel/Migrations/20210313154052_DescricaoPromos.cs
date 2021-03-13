using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class DescricaoPromos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contratos_PromocaoId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "PromocaoId",
                table: "Contratos");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Televisao",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "PromoTelevisao",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "PromoTelemovel",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "PromoTelefone",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "PromoNetMovel",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "PromoNetFixa",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "PromoTelevisao");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "PromoTelemovel");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "PromoTelefone");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "PromoNetMovel");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "PromoNetFixa");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Televisao",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PromocaoId",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PromocaoId",
                table: "Contratos",
                column: "PromocaoId");
        }
    }
}
