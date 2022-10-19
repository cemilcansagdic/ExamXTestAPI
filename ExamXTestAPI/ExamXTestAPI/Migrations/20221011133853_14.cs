using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamXTestAPI.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicID",
                table: "Questions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubjectID",
                table: "Questions",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TopicID",
                table: "Questions",
                column: "TopicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_SubjectID",
                table: "Questions",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Topics_TopicID",
                table: "Questions",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_SubjectID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Topics_TopicID",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SubjectID",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TopicID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TopicID",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
