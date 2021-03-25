using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class PromoDistrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistritoId",
                table: "PromoNetFixa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PromoNetFixa_DistritoId",
                table: "PromoNetFixa",
                column: "DistritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PromoNetFixa_Distrito",
                table: "PromoNetFixa",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "DistritoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromoNetFixa_Distrito",
                table: "PromoNetFixa");

            migrationBuilder.DropIndex(
                name: "IX_PromoNetFixa_DistritoId",
                table: "PromoNetFixa");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "PromoNetFixa");
        }
    }
}
