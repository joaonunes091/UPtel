using Microsoft.EntityFrameworkCore.Migrations;

namespace UPtel.Migrations
{
    public partial class listaMensagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Feedback_FeedbackId1",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_FeedbackId1",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "FeedbackId1",
                table: "Feedback");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeedbackId1",
                table: "Feedback",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_FeedbackId1",
                table: "Feedback",
                column: "FeedbackId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Feedback_FeedbackId1",
                table: "Feedback",
                column: "FeedbackId1",
                principalTable: "Feedback",
                principalColumn: "FeedbackId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
