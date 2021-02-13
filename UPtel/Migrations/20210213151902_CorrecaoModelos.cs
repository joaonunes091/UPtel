using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class CorrecaoModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacotes_Telefone",
                table: "Pacotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacotes_Telemovel",
                table: "Pacotes");

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_TelefoneId",
                table: "Pacotes",
                column: "TelefoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacotes_Telefone",
                table: "Pacotes",
                column: "TelemovelId",
                principalTable: "Telemovel",
                principalColumn: "TelemovelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacotes_Telemovel",
                table: "Pacotes",
                column: "TelefoneId",
                principalTable: "Telefone",
                principalColumn: "TelefoneId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacotes_Telefone",
                table: "Pacotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacotes_Telemovel",
                table: "Pacotes");

            migrationBuilder.DropIndex(
                name: "IX_Pacotes_TelefoneId",
                table: "Pacotes");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacotes_Telefone",
                table: "Pacotes",
                column: "TelemovelId",
                principalTable: "Telefone",
                principalColumn: "TelefoneId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacotes_Telemovel",
                table: "Pacotes",
                column: "TelemovelId",
                principalTable: "Telemovel",
                principalColumn: "TelemovelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
