using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Quizer.Migrations
{
    public partial class prep_Change_ID_Types_to_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Exams_Exam_id",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_ExamQuestions_Ques_ID",
                table: "QuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_AspNetUsers_User_id",
                table: "UserExams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Exams_Exam_id",
                table: "UserExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "Exam_id",
                table: "UserExams");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ExamQuestions");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "UserExams",
                newName: "aUser_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserExams_User_id",
                table: "UserExams",
                newName: "IX_UserExams_aUser_id");

            migrationBuilder.AddColumn<string>(
                name: "asUser_id",
                table: "UserExams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "aExam_id",
                table: "UserExams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ques_ID",
                table: "QuestionAnswers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "aID",
                table: "QuestionAnswers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "aId",
                table: "Exams",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Exam_id",
                table: "ExamQuestions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "aID",
                table: "ExamQuestions",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams",
                column: "asUser_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers",
                column: "aID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "aId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions",
                column: "aID");

            migrationBuilder.CreateIndex(
                name: "IX_UserExams_aExam_id",
                table: "UserExams",
                column: "aExam_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Exams_Exam_id",
                table: "ExamQuestions",
                column: "Exam_id",
                principalTable: "Exams",
                principalColumn: "aId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_ExamQuestions_Ques_ID",
                table: "QuestionAnswers",
                column: "Ques_ID",
                principalTable: "ExamQuestions",
                principalColumn: "aID",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Exams_Exam_id",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_ExamQuestions_Ques_ID",
                table: "QuestionAnswers");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "asUser_id",
                table: "UserExams");

            migrationBuilder.DropColumn(
                name: "aExam_id",
                table: "UserExams");

            migrationBuilder.DropColumn(
                name: "aID",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "aId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "aID",
                table: "ExamQuestions");

            migrationBuilder.RenameColumn(
                name: "aUser_id",
                table: "UserExams",
                newName: "User_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserExams_aUser_id",
                table: "UserExams",
                newName: "IX_UserExams_User_id");

            migrationBuilder.AddColumn<int>(
                name: "Exam_id",
                table: "UserExams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Ques_ID",
                table: "QuestionAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "QuestionAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Exam_id",
                table: "ExamQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ExamQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams",
                columns: new[] { "Exam_id", "User_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Exams_Exam_id",
                table: "ExamQuestions",
                column: "Exam_id",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_ExamQuestions_Ques_ID",
                table: "QuestionAnswers",
                column: "Ques_ID",
                principalTable: "ExamQuestions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
    }
}