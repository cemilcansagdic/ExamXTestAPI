using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamXTestAPI.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "QuizResults");

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "QuizResults",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_SubjectID",
                table: "QuizResults",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResults_Subjects_SubjectID",
                table: "QuizResults",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizResults_Subjects_SubjectID",
                table: "QuizResults");

            migrationBuilder.DropIndex(
                name: "IX_QuizResults_SubjectID",
                table: "QuizResults");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "QuizResults");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "QuizResults",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
