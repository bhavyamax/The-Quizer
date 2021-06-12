using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Quizer.Migrations
{
    public partial class AddCoursesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Coursess_Course_id",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Coursess_CourseId",
                table: "UserExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coursess",
                table: "Coursess");

            migrationBuilder.RenameTable(
                name: "Coursess",
                newName: "Courses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Courses_Course_id",
                table: "UserCourses",
                column: "Course_id",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Courses_CourseId",
                table: "UserExams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Courses_Course_id",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Courses_CourseId",
                table: "UserExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Coursess");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coursess",
                table: "Coursess",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Coursess_Course_id",
                table: "UserCourses",
                column: "Course_id",
                principalTable: "Coursess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Coursess_CourseId",
                table: "UserExams",
                column: "CourseId",
                principalTable: "Coursess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
