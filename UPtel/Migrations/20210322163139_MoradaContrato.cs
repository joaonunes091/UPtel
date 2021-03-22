using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class MoradaContrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoPostalCont",
                table: "Contratos",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostalExtCont",
                table: "Contratos",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DistritoId",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MoradaContrato",
                table: "Contratos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_DistritoId",
                table: "Contratos",
                column: "DistritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Distrito",
                table: "Contratos",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "DistritoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Distrito",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_DistritoId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "CodigoPostalCont",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "CodigoPostalExtCont",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "MoradaContrato",
                table: "Contratos");
        }
    }
}
