using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class Reclamacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Reclamacao",
                newName: "UsersId");

            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "Reclamacao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacao_UsersId",
                table: "Reclamacao",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacao_Users_UsersId",
                table: "Reclamacao",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacao_Users_UsersId",
                table: "Reclamacao");

            migrationBuilder.DropIndex(
                name: "IX_Reclamacao_UsersId",
                table: "Reclamacao");

            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "Reclamacao");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Reclamacao",
                newName: "ClienteId");
        }
    }
}
