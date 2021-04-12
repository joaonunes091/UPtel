using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class alertaOperador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PorResoponder",
                table: "ReclamacaoViewModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PorResoponder",
                table: "Reclamacao",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorResoponder",
                table: "ReclamacaoViewModel");

            migrationBuilder.DropColumn(
                name: "PorResoponder",
                table: "Reclamacao");
        }
    }
}
