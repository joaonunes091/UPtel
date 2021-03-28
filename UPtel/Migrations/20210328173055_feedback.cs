using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resolvido",
                table: "Reclamacao",
                newName: "ResolvidoOperador");

            migrationBuilder.AddColumn<bool>(
                name: "ResolvidoCliente",
                table: "Reclamacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "MoradaContrato",
                table: "Contratos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPostalExtCont",
                table: "Contratos",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPostalCont",
                table: "Contratos",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReclamacaoId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FeedbackCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespostaFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DataRegisto",
                table: "Users",
                column: "DataRegisto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_DataRegisto",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ResolvidoCliente",
                table: "Reclamacao");

            migrationBuilder.RenameColumn(
                name: "ResolvidoOperador",
                table: "Reclamacao",
                newName: "Resolvido");

            migrationBuilder.AlterColumn<string>(
                name: "MoradaContrato",
                table: "Contratos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPostalExtCont",
                table: "Contratos",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPostalCont",
                table: "Contratos",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true);
        }
    }
}
