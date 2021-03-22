using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class Faturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "PromoTelevisao",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "PromoTelemovel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "PromoTelefone",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "PromoNetMovel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "PromoNetFixa",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "PromoTelevisao");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "PromoTelemovel");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "PromoTelefone");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "PromoNetMovel");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "PromoNetFixa");
        }
    }
}
