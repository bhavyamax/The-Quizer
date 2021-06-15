using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Quizer.Migrations
{
    public partial class Change_ID_Types_to_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_AspNetUsers_aUser_id",
                table: "UserExams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Exams_aExam_id",
                table: "UserExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams");

            migrationBuilder.DropIndex(
                name: "IX_UserExams_aExam_id",
                table: "UserExams");

            migrationBuilder.DropColumn(
                name: "asUser_id",
                table: "UserExams");

            migrationBuilder.RenameColumn(
                name: "aUser_id",
                table: "UserExams",
                newName: "User_id");

            migrationBuilder.RenameColumn(
                name: "aExam_id",
                table: "UserExams",
                newName: "Exam_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserExams_aUser_id",
                table: "UserExams",
                newName: "IX_UserExams_User_id");

            migrationBuilder.RenameColumn(
                name: "aID",
                table: "QuestionAnswers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "aId",
                table: "Exams",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "aID",
                table: "ExamQuestions",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams",
                columns: new[] { "Exam_id", "User_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_AspNetUsers_User_id",
                table: "UserExams",
                column: "User_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Exams_Exam_id",
                table: "UserExams",
                column: "Exam_id",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_AspNetUsers_User_id",
                table: "UserExams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Exams_Exam_id",
                table: "UserExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "UserExams",
                newName: "aUser_id");

            migrationBuilder.RenameColumn(
                name: "Exam_id",
                table: "UserExams",
                newName: "aExam_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserExams_User_id",
                table: "UserExams",
                newName: "IX_UserExams_aUser_id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "QuestionAnswers",
                newName: "aID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Exams",
                newName: "aId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ExamQuestions",
                newName: "aID");

            migrationBuilder.AddColumn<string>(
                name: "asUser_id",
                table: "UserExams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams",
                column: "asUser_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserExams_aExam_id",
                table: "UserExams",
                column: "aExam_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_AspNetUsers_aUser_id",
                table: "UserExams",
                column: "aUser_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Exams_aExam_id",
                table: "UserExams",
                column: "aExam_id",
                principalTable: "Exams",
                principalColumn: "aId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}