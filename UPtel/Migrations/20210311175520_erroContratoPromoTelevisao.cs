using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class erroContratoPromoTelevisao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContratoPromotelevisao_Contratos_ContratoId",
                table: "ContratoPromotelevisao");

            migrationBuilder.DropForeignKey(
                name: "FK_ContratoPromotelevisao_PromoTelevisao_PromoTelevisaoId",
                table: "ContratoPromotelevisao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContratoPromotelevisao",
                table: "ContratoPromotelevisao");

            migrationBuilder.RenameTable(
                name: "ContratoPromotelevisao",
                newName: "ContratoPromoTelevisao");

            migrationBuilder.RenameIndex(
                name: "IX_ContratoPromotelevisao_PromoTelevisaoId",
                table: "ContratoPromoTelevisao",
                newName: "IX_ContratoPromoTelevisao_PromoTelevisaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ContratoPromotelevisao_ContratoId",
                table: "ContratoPromoTelevisao",
                newName: "IX_ContratoPromoTelevisao_ContratoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContratoPromoTelevisao",
                table: "ContratoPromoTelevisao",
                column: "ContratoTelevisaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContratoPromoTelevisao_Contratos_ContratoId",
                table: "ContratoPromoTelevisao",
                column: "ContratoId",
                principalTable: "Contratos",
                principalColumn: "ContratoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContratoPromoTelevisao_PromoTelevisao_PromoTelevisaoId",
                table: "ContratoPromoTelevisao",
                column: "PromoTelevisaoId",
                principalTable: "PromoTelevisao",
                principalColumn: "PromoTelevisaoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContratoPromoTelevisao_Contratos_ContratoId",
                table: "ContratoPromoTelevisao");

            migrationBuilder.DropForeignKey(
                name: "FK_ContratoPromoTelevisao_PromoTelevisao_PromoTelevisaoId",
                table: "ContratoPromoTelevisao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContratoPromoTelevisao",
                table: "ContratoPromoTelevisao");

            migrationBuilder.RenameTable(
                name: "ContratoPromoTelevisao",
                newName: "ContratoPromotelevisao");

            migrationBuilder.RenameIndex(
                name: "IX_ContratoPromoTelevisao_PromoTelevisaoId",
                table: "ContratoPromotelevisao",
                newName: "IX_ContratoPromotelevisao_PromoTelevisaoId");

            migrationBuilder.RenameIndex(
                name: "IX_ContratoPromoTelevisao_ContratoId",
                table: "ContratoPromotelevisao",
                newName: "IX_ContratoPromotelevisao_ContratoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContratoPromotelevisao",
                table: "ContratoPromotelevisao",
                column: "ContratoTelevisaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContratoPromotelevisao_Contratos_ContratoId",
                table: "ContratoPromotelevisao",
                column: "ContratoId",
                principalTable: "Contratos",
                principalColumn: "ContratoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContratoPromotelevisao_PromoTelevisao_PromoTelevisaoId",
                table: "ContratoPromotelevisao",
                column: "PromoTelevisaoId",
                principalTable: "PromoTelevisao",
                principalColumn: "PromoTelevisaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
