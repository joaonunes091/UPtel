using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class operador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegisto",
                table: "ClientesViewModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DistritoNomeDistritoId",
                table: "ClientesViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OperadorViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CartaoCidadao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroContribuinte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiogoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtensaoCodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telemovel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fotografia = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DistritoNomeDistritoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperadorViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperadorViewModel_Distrito_DistritoNomeDistritoId",
                        column: x => x.DistritoNomeDistritoId,
                        principalTable: "Distrito",
                        principalColumn: "DistritoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientesViewModel_DistritoNomeDistritoId",
                table: "ClientesViewModel",
                column: "DistritoNomeDistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_OperadorViewModel_DistritoNomeDistritoId",
                table: "OperadorViewModel",
                column: "DistritoNomeDistritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesViewModel_Distrito_DistritoNomeDistritoId",
                table: "ClientesViewModel",
                column: "DistritoNomeDistritoId",
                principalTable: "Distrito",
                principalColumn: "DistritoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesViewModel_Distrito_DistritoNomeDistritoId",
                table: "ClientesViewModel");

            migrationBuilder.DropTable(
                name: "OperadorViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ClientesViewModel_DistritoNomeDistritoId",
                table: "ClientesViewModel");

            migrationBuilder.DropColumn(
                name: "DataRegisto",
                table: "ClientesViewModel");

            migrationBuilder.DropColumn(
                name: "DistritoNomeDistritoId",
                table: "ClientesViewModel");
        }
    }
}
