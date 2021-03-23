using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class Inicial : Migration
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
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canais", x => x.CanaisId);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    DistritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistritoNome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistritoNome", x => x.DistritoId);
                });

            migrationBuilder.CreateTable(
                name: "NetFixa",
                columns: table => new
                {
                    NetFixaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
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
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetMovel", x => x.NetMovelId);
                });

            migrationBuilder.CreateTable(
                name: "PromoNetFixa",
                columns: table => new
                {
                    PromoNetFixaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Limite = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Velocidade = table.Column<int>(type: "int", nullable: false),
                    DescontoPrecoTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoNetFixa", x => x.PromoNetFixaId);
                });

            migrationBuilder.CreateTable(
                name: "PromoNetMovel",
                columns: table => new
                {
                    PromoNetMovelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Limite = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DescontoPrecoTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoNetMovel", x => x.PromoNetMovelId);
                });

            migrationBuilder.CreateTable(
                name: "PromoTelefone",
                columns: table => new
                {
                    PromoTelefoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Limite = table.Column<int>(type: "int", nullable: false),
                    DescontoMinNacional = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    DescontoMinInternacional = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    DescontoPrecoTotal = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoTelefone", x => x.PromoTelefoneId);
                });

            migrationBuilder.CreateTable(
                name: "PromoTelemovel",
                columns: table => new
                {
                    PromoTelemovelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimiteMinutos = table.Column<int>(type: "int", nullable: false),
                    LimiteSMS = table.Column<int>(type: "int", nullable: false),
                    DecontoPrecoMinNacional = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    DecontoPrecoMinInternacional = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    DecontoPrecoSMS = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    DecontoPrecoMMS = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    DecontoPrecoTotal = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoTelemovel", x => x.PromoTelemovelId);
                });

            migrationBuilder.CreateTable(
                name: "PromoTelevisao",
                columns: table => new
                {
                    PromoTelevisaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanaisGratis = table.Column<int>(type: "int", nullable: false),
                    DescontoPrecoTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoTelevisao", x => x.PromoTelevisaoId);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    TelefoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
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
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
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
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PrecoPacoteTelevisao = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Televisao", x => x.TelevisaoId);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoClientes", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "ClientesViewModel",
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
                    Posicao = table.Column<int>(type: "int", nullable: true),
                    PrecoContratos = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telemovel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fotografia = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fidelizacao = table.Column<int>(type: "int", nullable: true),
                    TempoPromocao = table.Column<int>(type: "int", nullable: true),
                    PrecoContrato = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    NumerosAssociados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomePacote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetFixaPacote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetMovelPacote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelemovelPacote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DistritoNomeDistritoId = table.Column<int>(type: "int", nullable: true),
                    TelefonePacote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelevisaoPacote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoPacote = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    NomePromocao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoPromocao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromocaoCanais = table.Column<int>(type: "int", nullable: false),
                    Desconto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesViewModel_Distrito_DistritoNomeDistritoId",
                        column: x => x.DistritoNomeDistritoId,
                        principalTable: "Distrito",
                        principalColumn: "DistritoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperadorViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeOperador = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
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
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    DistritoId = table.Column<int>(type: "int", nullable: false),
                    PrecoContratos = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Posicao = table.Column<int>(type: "int", nullable: true),
                    DataRegisto = table.Column<DateTime>(type: "date", nullable: false),
                    CodigoPostalExt = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValueSql: "(N'')"),
                    IBAN = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fotografia = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UsersId);
                    table.ForeignKey(
                        name: "FK_Users_Distrito",
                        column: x => x.DistritoId,
                        principalTable: "Distrito",
                        principalColumn: "DistritoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserType",
                        column: x => x.TipoId,
                        principalTable: "UserType",
                        principalColumn: "TipoId",
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
                    PacoteId = table.Column<int>(type: "int", nullable: false),
                    Numeros = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    Fidelizacao = table.Column<int>(type: "int", nullable: true),
                    Posicao = table.Column<int>(type: "int", nullable: true),
                    EdicaoCliente = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PrecoContrato = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MoradaContrato = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CodigoPostalCont = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CodigoPostalExtCont = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DistritoId = table.Column<int>(type: "int", nullable: false),
                    ClientesViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ContratoId);
                    table.ForeignKey(
                        name: "FK_Cliente_Users",
                        column: x => x.ClienteId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_ClientesViewModel_ClientesViewModelId",
                        column: x => x.ClientesViewModelId,
                        principalTable: "ClientesViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Distrito",
                        column: x => x.DistritoId,
                        principalTable: "Distrito",
                        principalColumn: "DistritoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Pacotes",
                        column: x => x.PacoteId,
                        principalTable: "Pacotes",
                        principalColumn: "PacoteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Users",
                        column: x => x.FuncionarioId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reclamacao",
                columns: table => new
                {
                    ReclamacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    Assunto = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Descriçao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resolvido = table.Column<bool>(type: "bit", nullable: false),
                    ReclamacaoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamacao", x => x.ReclamacaoId);
                    table.ForeignKey(
                        name: "FK_Reclamacao_Reclamacao_ReclamacaoId1",
                        column: x => x.ReclamacaoId1,
                        principalTable: "Reclamacao",
                        principalColumn: "ReclamacaoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reclamacao_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "ContratoPromoTelevisao",
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
                    table.PrimaryKey("PK_ContratoPromoTelevisao", x => x.ContratoTelevisaoId);
                    table.ForeignKey(
                        name: "FK_ContratoPromoTelevisao_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoPromoTelevisao_PromoTelevisao_PromoTelevisaoId",
                        column: x => x.PromoTelevisaoId,
                        principalTable: "PromoTelevisao",
                        principalColumn: "PromoTelevisaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientesViewModel_DistritoNomeDistritoId",
                table: "ClientesViewModel",
                column: "DistritoNomeDistritoId");

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
                name: "IX_ContratoPromoTelevisao_ContratoId",
                table: "ContratoPromoTelevisao",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoPromoTelevisao_PromoTelevisaoId",
                table: "ContratoPromoTelevisao",
                column: "PromoTelevisaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ClienteId",
                table: "Contratos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ClientesViewModelId",
                table: "Contratos",
                column: "ClientesViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_DistritoId",
                table: "Contratos",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_FuncionarioId",
                table: "Contratos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PacoteId",
                table: "Contratos",
                column: "PacoteId");

            migrationBuilder.CreateIndex(
                name: "IX_OperadorViewModel_DistritoNomeDistritoId",
                table: "OperadorViewModel",
                column: "DistritoNomeDistritoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacao_ReclamacaoId1",
                table: "Reclamacao",
                column: "ReclamacaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacao_UsersId",
                table: "Reclamacao",
                column: "UsersId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Nome_Users",
                table: "Users",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DistritoId",
                table: "Users",
                column: "DistritoId");
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
                name: "ContratoPromoTelevisao");

            migrationBuilder.DropTable(
                name: "OperadorViewModel");

            migrationBuilder.DropTable(
                name: "PacoteCanais");

            migrationBuilder.DropTable(
                name: "Reclamacao");

            migrationBuilder.DropTable(
                name: "PromoNetFixa");

            migrationBuilder.DropTable(
                name: "PromoNetMovel");

            migrationBuilder.DropTable(
                name: "PromoTelefone");

            migrationBuilder.DropTable(
                name: "PromoTelemovel");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "PromoTelevisao");

            migrationBuilder.DropTable(
                name: "Canais");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ClientesViewModel");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "Distrito");

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
