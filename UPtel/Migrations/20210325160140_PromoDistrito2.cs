using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class PromoDistrito2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistritoId",
                table: "PromoTelevisao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DistritoNomes",
                table: "PromoTelevisao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistritoId",
                table: "PromoTelemovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DistritoNomes",
                table: "PromoTelemovel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistritoId",
                table: "PromoTelefone",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DistritoNomes",
                table: "PromoTelefone",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistritoId",
                table: "PromoNetMovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DistritoNomes",
                table: "PromoNetMovel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PromoTelevisao_DistritoId",
                table: "PromoTelevisao",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoTelemovel_DistritoId",
                table: "PromoTelemovel",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoTelefone_DistritoId",
                table: "PromoTelefone",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoNetMovel_DistritoId",
                table: "PromoNetMovel",
                column: "DistritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PromoNetMovel_Distrito",
                table: "PromoNetMovel",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "DistritoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PromoTelefone_Distrito",
                table: "PromoTelefone",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "DistritoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PromoTelemovel_Distrito",
                table: "PromoTelemovel",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "DistritoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PromoTelevisao_Distrito",
                table: "PromoTelevisao",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "DistritoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromoNetMovel_Distrito",
                table: "PromoNetMovel");

            migrationBuilder.DropForeignKey(
                name: "FK_PromoTelefone_Distrito",
                table: "PromoTelefone");

            migrationBuilder.DropForeignKey(
                name: "FK_PromoTelemovel_Distrito",
                table: "PromoTelemovel");

            migrationBuilder.DropForeignKey(
                name: "FK_PromoTelevisao_Distrito",
                table: "PromoTelevisao");

            migrationBuilder.DropIndex(
                name: "IX_PromoTelevisao_DistritoId",
                table: "PromoTelevisao");

            migrationBuilder.DropIndex(
                name: "IX_PromoTelemovel_DistritoId",
                table: "PromoTelemovel");

            migrationBuilder.DropIndex(
                name: "IX_PromoTelefone_DistritoId",
                table: "PromoTelefone");

            migrationBuilder.DropIndex(
                name: "IX_PromoNetMovel_DistritoId",
                table: "PromoNetMovel");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "PromoTelevisao");

            migrationBuilder.DropColumn(
                name: "DistritoNomes",
                table: "PromoTelevisao");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "PromoTelemovel");

            migrationBuilder.DropColumn(
                name: "DistritoNomes",
                table: "PromoTelemovel");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "PromoTelefone");

            migrationBuilder.DropColumn(
                name: "DistritoNomes",
                table: "PromoTelefone");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "PromoNetMovel");

            migrationBuilder.DropColumn(
                name: "DistritoNomes",
                table: "PromoNetMovel");
        }
    }
}
