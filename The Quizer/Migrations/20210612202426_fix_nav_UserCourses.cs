using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Quizer.Migrations
{
    public partial class fix_nav_UserCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Courses_CourseId",
                table: "UserExams");

            migrationBuilder.DropIndex(
                name: "IX_UserExams_CourseId",
                table: "UserExams");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "UserExams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "UserExams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserExams_CourseId",
                table: "UserExams",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Courses_CourseId",
                table: "UserExams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
