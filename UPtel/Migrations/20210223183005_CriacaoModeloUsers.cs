using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class CriacaoModeloUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Clientes",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Funcionarios",
                table: "Contratos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "TipoClientes");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoClientes", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    CartaoCidadao = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Contribuinte = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Telemovel = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    CodigoPostalExt = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValueSql: "(N'')"),
                    IBAN = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fotografia = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UsersId);
                    table.ForeignKey(
                        name: "FK_Users_UserType",
                        column: x => x.TipoId,
                        principalTable: "UserType",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCidadaoClientes",
                table: "Users",
                column: "CartaoCidadao",
                unique: true,
                filter: "[CartaoCidadao] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoClienteId",
                table: "Users",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContribuinteClientes",
                table: "Users",
                column: "Contribuinte",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Users",
                table: "Contratos",
                column: "ClienteId",
                principalTable: "Users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Users",
                table: "Contratos",
                column: "FuncionarioId",
                principalTable: "Users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Users",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Users",
                table: "Contratos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoClientes",
                columns: table => new
                {
                    TipoClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designacao = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoClientes", x => x.TipoClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    CartaoCidadao = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CodigoPostalExt = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Contribuinte = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstadoFuncionario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Fotografia = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Telemovel = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Cargos",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartaoCidadao = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CodigoPostalExt = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Contribuinte = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NomeCliente = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Telemovel = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    TipoClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_TipoClientes",
                        column: x => x.TipoClienteId,
                        principalTable: "TipoClientes",
                        principalColumn: "TipoClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCidadaoClientes",
                table: "Clientes",
                column: "CartaoCidadao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoClienteId",
                table: "Clientes",
                column: "TipoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContribuinteClientes",
                table: "Clientes",
                column: "Contribuinte",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCidadaoFuncionarios",
                table: "Funcionarios",
                column: "CartaoCidadao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContribuinteFuncionarios",
                table: "Funcionarios",
                column: "Contribuinte",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailFuncionarios",
                table: "Funcionarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargoId",
                table: "Funcionarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_TelemovelFuncionarios",
                table: "Funcionarios",
                column: "Telemovel",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Clientes",
                table: "Contratos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Funcionarios",
                table: "Contratos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
