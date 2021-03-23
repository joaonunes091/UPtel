using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class Fatura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faturas",
                columns: table => new
                {
                    NrFaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacoteId = table.Column<int>(type: "int", nullable: false),
                    PrecoContrato = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturas", x => x.NrFaturaId);
                    table.ForeignKey(
                        name: "FK_Contratos_Fatura",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faturas_ContratoId",
                table: "Faturas",
                column: "ContratoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faturas");
        }
    }
}
