using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class Promos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Promocoes",
                table: "Contratos");

            migrationBuilder.DropTable(
                name: "Promocoes");

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

            migrationBuilder.CreateTable(
                name: "PromoNetFixa",
                columns: table => new
                {
                    PromoNetFixaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Limite = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Velocidade = table.Column<int>(type: "int", nullable: false),
                    DescontoPrecoTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
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
                    DescontoPrecoTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoNetMovel", x => x.PromoNetMovelId);
                });

            migrationBuilder.CreateTable(
                name: "PromoTelefone",
                columns: table => new
                {
                    PromTelefoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Limite = table.Column<int>(type: "int", nullable: false),
                    DescontoMinNacional = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    DescontoMinInternacional = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    DescontoPrecoTotal = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoTelefone", x => x.PromTelefoneId);
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
                    DecontoPrecoTotal = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
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
                    DescontoPrecoTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoTelevisao", x => x.PromoTelevisaoId);
                });

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
                principalColumn: "PromTelefoneId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "PromoNetFixa");

            migrationBuilder.DropTable(
                name: "PromoNetMovel");

            migrationBuilder.DropTable(
                name: "PromoTelefone");

            migrationBuilder.DropTable(
                name: "PromoTelemovel");

            migrationBuilder.DropTable(
                name: "PromoTelevisao");

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

            migrationBuilder.CreateTable(
                name: "Promocoes",
                columns: table => new
                {
                    PromocaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desconto = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomePromocao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PromoCanais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocoes", x => x.PromocaoId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Promocoes",
                table: "Contratos",
                column: "PromocaoId",
                principalTable: "Promocoes",
                principalColumn: "PromocaoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
