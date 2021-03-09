using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class ErrPromoTelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PromTelefoneId",
                table: "PromoTelefone",
                newName: "PromoTelefoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PromoTelefoneId",
                table: "PromoTelefone",
                newName: "PromTelefoneId");
        }
    }
}
