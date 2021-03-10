using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class PromocoesMPM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_PromoNetFixa_PromoNetFixaId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_PromoNetMovel_PromoNetMovelId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_PromoTelefone_PromoTelefoneId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_PromoTelemovel_PromoTelemovelId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_PromoTelevisao_PromoTelevisaoId",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_PromoNetFixaId",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_PromoNetMovelId",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_PromoTelefoneId",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_PromoTelemovelId",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_PromoTelevisaoId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "PromoNetFixaId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "PromoNetMovelId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "PromoTelefoneId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "PromoTelemovelId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "PromoTelevisaoId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "TempoPromocao",
                table: "Contratos");

            migrationBuilder.CreateTable(
                name: "ContratoPromoNetFixa",
                columns: table => new
                {
                    ContratoPromoNetFixaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    PromoNetFixaId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoPromoNetFixa", x => x.ContratoPromoNetFixaId);
                    table.ForeignKey(
                        name: "FK_ContratoPromoNetFixa_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoPromoNetFixa_PromoNetFixa_PromoNetFixaId",
                        column: x => x.PromoNetFixaId,
                        principalTable: "PromoNetFixa",
                        principalColumn: "PromoNetFixaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratoPromoNetMovel",
                columns: table => new
                {
                    ContratoPromoNetMovelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    PromoNetMovelId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoPromoNetMovel", x => x.ContratoPromoNetMovelId);
                    table.ForeignKey(
                        name: "FK_ContratoPromoNetMovel_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoPromoNetMovel_PromoNetMovel_PromoNetMovelId",
                        column: x => x.PromoNetMovelId,
                        principalTable: "PromoNetMovel",
                        principalColumn: "PromoNetMovelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratoPromoTelefone",
                columns: table => new
                {
                    ContratoPromoTelefoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    PromoTelefoneId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoPromoTelefone", x => x.ContratoPromoTelefoneId);
                    table.ForeignKey(
                        name: "FK_ContratoPromoTelefone_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoPromoTelefone_PromoTelefone_PromoTelefoneId",
                        column: x => x.PromoTelefoneId,
                        principalTable: "PromoTelefone",
                        principalColumn: "PromoTelefoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratoPromoTelemovel",
                columns: table => new
                {
                    ContratoPromoTelemovelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    PromoTelemovelId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoPromoTelemovel", x => x.ContratoPromoTelemovelId);
                    table.ForeignKey(
                        name: "FK_ContratoPromoTelemovel_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoPromoTelemovel_PromoTelemovel_PromoTelemovelId",
                        column: x => x.PromoTelemovelId,
                        principalTable: "PromoTelemovel",
                        principalColumn: "PromoTelemovelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratoPromotelevisao",
                columns: table => new
                {
                    ContratoTelevisaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    PromoTelevisaoId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoPromotelevisao", x => x.ContratoTelevisaoId);
                    table.ForeignKey(
                        name: "FK_ContratoPromotelevisao_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoPromotelevisao_PromoTelevisao_PromoTelevisaoId",
                        column: x => x.PromoTelevisaoId,
                        principalTable: "PromoTelevisao",
                        principalColumn: "PromoTelevisaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratoPromoNetFixa_ContratoId",
                table: "ContratoPromoNetFixa",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoPromoNetFixa_PromoNetFixaId",
                table: "ContratoPromoNetFixa",
                column: "PromoNetFixaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoPromoNetMovel_ContratoId",
                table: "ContratoPromoNetMovel",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoPromoNetMovel_PromoNetMovelId",
                table: "ContratoPromoNetMovel",
                column: "PromoNetMovelId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoPromoTelefone_ContratoId",
                table: "ContratoPromoTelefone",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoPromoTelefone_PromoTelefoneId",
                table: "ContratoPromoTelefone",
                column: "PromoTelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoPromoTelemovel_ContratoId",
                table: "ContratoPromoTelemovel",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoPromoTelemovel_PromoTelemovelId",
                table: "ContratoPromoTelemovel",
                column: "PromoTelemovelId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoPromotelevisao_ContratoId",
                table: "ContratoPromotelevisao",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoPromotelevisao_PromoTelevisaoId",
                table: "ContratoPromotelevisao",
                column: "PromoTelevisaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratoPromoNetFixa");

            migrationBuilder.DropTable(
                name: "ContratoPromoNetMovel");

            migrationBuilder.DropTable(
                name: "ContratoPromoTelefone");

            migrationBuilder.DropTable(
                name: "ContratoPromoTelemovel");

            migrationBuilder.DropTable(
                name: "ContratoPromotelevisao");

            migrationBuilder.AddColumn<int>(
                name: "PromoNetFixaId",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PromoNetMovelId",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PromoTelefoneId",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PromoTelemovelId",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PromoTelevisaoId",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempoPromocao",
                table: "Contratos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PromoNetFixaId",
                table: "Contratos",
                column: "PromoNetFixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PromoNetMovelId",
                table: "Contratos",
                column: "PromoNetMovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PromoTelefoneId",
                table: "Contratos",
                column: "PromoTelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PromoTelemovelId",
                table: "Contratos",
                column: "PromoTelemovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PromoTelevisaoId",
                table: "Contratos",
                column: "PromoTelevisaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_PromoNetFixa_PromoNetFixaId",
                table: "Contratos",
                column: "PromoNetFixaId",
                principalTable: "PromoNetFixa",
                principalColumn: "PromoNetFixaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_PromoNetMovel_PromoNetMovelId",
                table: "Contratos",
                column: "PromoNetMovelId",
                principalTable: "PromoNetMovel",
                principalColumn: "PromoNetMovelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_PromoTelefone_PromoTelefoneId",
                table: "Contratos",
                column: "PromoTelefoneId",
                principalTable: "PromoTelefone",
                principalColumn: "PromoTelefoneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_PromoTelemovel_PromoTelemovelId",
                table: "Contratos",
                column: "PromoTelemovelId",
                principalTable: "PromoTelemovel",
                principalColumn: "PromoTelemovelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_PromoTelevisao_PromoTelevisaoId",
                table: "Contratos",
                column: "PromoTelevisaoId",
                principalTable: "PromoTelevisao",
                principalColumn: "PromoTelevisaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
