using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamXTestAPI.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "TeacherStudents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_SubjectID",
                table: "TeacherStudents",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherStudents_Subjects_SubjectID",
                table: "TeacherStudents",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherStudents_Subjects_SubjectID",
                table: "TeacherStudents");

            migrationBuilder.DropIndex(
                name: "IX_TeacherStudents_SubjectID",
                table: "TeacherStudents");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "TeacherStudents");
        }
    }
}
