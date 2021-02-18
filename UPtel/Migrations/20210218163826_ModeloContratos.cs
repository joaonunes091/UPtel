using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class ModeloContratos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canais",
                columns: table => new
                {
                    CanaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCanal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PrecoCanais = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canais", x => x.CanaisId);
                });

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
                name: "NetFixa",
                columns: table => new
                {
                    NetFixaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Limite = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Velocidade = table.Column<int>(type: "int", nullable: false),
                    TipoConexao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PrecoNetFixa = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetFixa", x => x.NetFixaId);
                });

            migrationBuilder.CreateTable(
                name: "NetMovel",
                columns: table => new
                {
                    NetMovelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Limite = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PrecoNetMovel = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetMovel", x => x.NetMovelId);
                });

            migrationBuilder.CreateTable(
                name: "Promocoes",
                columns: table => new
                {
                    PromocaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePromocao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PromoCanais = table.Column<int>(type: "int", nullable: false),
                    Desconto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocoes", x => x.PromocaoId);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    TelefoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Limite = table.Column<int>(type: "int", nullable: false),
                    PrecoMinutoNacional = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    PrecoMinutoInternacional = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    PrecoPacoteTelefone = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.TelefoneId);
                });

            migrationBuilder.CreateTable(
                name: "Telemovel",
                columns: table => new
                {
                    TelemovelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    LimiteMinutos = table.Column<int>(type: "int", nullable: false),
                    LimiteSMS = table.Column<int>(type: "int", nullable: false),
                    PrecoMinutoNacional = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    PrecoMinutoInternacional = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    PrecoSMS = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    PrecoMMS = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    PrecoPacoteTelemovel = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telemovel", x => x.TelemovelId);
                });

            migrationBuilder.CreateTable(
                name: "Televisao",
                columns: table => new
                {
                    TelevisaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PrecoPacoteTelevisao = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Televisao", x => x.TelevisaoId);
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
                    NomeFuncionario = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    NomeCargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Contribuinte = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telemovel = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    CartaoCidadao = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    EstadoFuncionario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CodigoPostalExt = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Fotografia = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
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
                name: "PacoteCanais",
                columns: table => new
                {
                    PacoteCanalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelevisaoId = table.Column<int>(type: "int", nullable: false),
                    CanaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacoteCanais", x => x.PacoteCanalId);
                    table.ForeignKey(
                        name: "FK_PacoteCanais_Canais",
                        column: x => x.CanaisId,
                        principalTable: "Canais",
                        principalColumn: "CanaisId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacoteCanais_Televisao",
                        column: x => x.TelevisaoId,
                        principalTable: "Televisao",
                        principalColumn: "TelevisaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    PacoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePacote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrecoTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    TelevisaoId = table.Column<int>(type: "int", nullable: true),
                    TelemovelId = table.Column<int>(type: "int", nullable: true),
                    NetIFixaId = table.Column<int>(type: "int", nullable: true),
                    TelefoneId = table.Column<int>(type: "int", nullable: true),
                    NetMovelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.PacoteId);
                    table.ForeignKey(
                        name: "FK_Pacotes_NetFixa1",
                        column: x => x.NetIFixaId,
                        principalTable: "NetFixa",
                        principalColumn: "NetFixaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacotes_NetMovel",
                        column: x => x.NetMovelId,
                        principalTable: "NetMovel",
                        principalColumn: "NetMovelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacotes_Telefone",
                        column: x => x.TelemovelId,
                        principalTable: "Telemovel",
                        principalColumn: "TelemovelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacotes_Telemovel",
                        column: x => x.TelefoneId,
                        principalTable: "Telefone",
                        principalColumn: "TelefoneId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacotes_Televisao1",
                        column: x => x.TelevisaoId,
                        principalTable: "Televisao",
                        principalColumn: "TelevisaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    CartaoCidadao = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Contribuinte = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Telemovel = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    TipoClienteId = table.Column<int>(type: "int", nullable: false),
                    CodigoPostalExt = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    ContratoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    PromocaoId = table.Column<int>(type: "int", nullable: false),
                    PacoteId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    Fidelizacao = table.Column<int>(type: "int", nullable: true),
                    TempoPromocao = table.Column<int>(type: "int", nullable: true),
                    PrecoContrato = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ContratoId);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Funcionarios",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Pacotes",
                        column: x => x.PacoteId,
                        principalTable: "Pacotes",
                        principalColumn: "PacoteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Promocoes",
                        column: x => x.PromocaoId,
                        principalTable: "Promocoes",
                        principalColumn: "PromocaoId",
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
                name: "IX_Contratos_ClienteId",
                table: "Contratos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_FuncionarioId",
                table: "Contratos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PacoteId",
                table: "Contratos",
                column: "PacoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PromocaoId",
                table: "Contratos",
                column: "PromocaoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_PacoteCanais_CanaisId",
                table: "PacoteCanais",
                column: "CanaisId");

            migrationBuilder.CreateIndex(
                name: "IX_PacoteCanais_TelevisaoId",
                table: "PacoteCanais",
                column: "TelevisaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_NetIFixaId",
                table: "Pacotes",
                column: "NetIFixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_NetMovelId",
                table: "Pacotes",
                column: "NetMovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_TelefoneId",
                table: "Pacotes",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_TelemovelId",
                table: "Pacotes",
                column: "TelemovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_TelevisaoId",
                table: "Pacotes",
                column: "TelevisaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "PacoteCanais");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Promocoes");

            migrationBuilder.DropTable(
                name: "Canais");

            migrationBuilder.DropTable(
                name: "TipoClientes");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "NetFixa");

            migrationBuilder.DropTable(
                name: "NetMovel");

            migrationBuilder.DropTable(
                name: "Telemovel");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Televisao");
        }
    }
}
