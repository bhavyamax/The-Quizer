using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Quizer.Migrations
{
    public partial class AddCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "UserExams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Coursess",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coursess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    User_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Course_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => new { x.Course_id, x.User_id });
                    table.ForeignKey(
                        name: "FK_UserCourses_AspNetUsers_User_id",
                        column: x => x.User_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourses_Coursess_Course_id",
                        column: x => x.Course_id,
                        principalTable: "Coursess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExams_CourseId",
                table: "UserExams",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_User_id",
                table: "UserCourses",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Coursess_CourseId",
                table: "UserExams",
                column: "CourseId",
                principalTable: "Coursess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Coursess_CourseId",
                table: "UserExams");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "Coursess");

            migrationBuilder.DropIndex(
                name: "IX_UserExams_CourseId",
                table: "UserExams");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "UserExams");
        }
    }
}
