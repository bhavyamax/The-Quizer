using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Quizer.Migrations
{
    public partial class Add_ClusterUeserExamKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams");

            migrationBuilder.DropIndex(
                name: "IX_UserExams_Exam_id",
                table: "UserExams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "220a6b72-9967-45ad-8a81-11a7c4986ca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7428c62a-2f3c-4280-b8e9-684726f06905");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f714e77f-e493-4e8a-9e56-ced6d2585b63");

            migrationBuilder.DropColumn(
                name: "ExamAttemptId",
                table: "UserExams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams",
                columns: new[] { "Exam_id", "User_id" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f91bb23c-b4ce-4cc3-a50c-ff29710e0d34", "13ed5430-9637-4a05-ad67-1456ddf0b68c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe7d8385-812c-4f37-aa1a-0e95631458f3", "870a3b54-ebc2-4e08-85cf-ad0623727d1b", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "405feda2-7b09-4457-94ee-8048170fad34", "4794a3ef-5891-4501-bd89-5bfe1afa7f99", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "405feda2-7b09-4457-94ee-8048170fad34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f91bb23c-b4ce-4cc3-a50c-ff29710e0d34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe7d8385-812c-4f37-aa1a-0e95631458f3");

            migrationBuilder.AddColumn<int>(
                name: "ExamAttemptId",
                table: "UserExams",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams",
                column: "ExamAttemptId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7428c62a-2f3c-4280-b8e9-684726f06905", "fc952406-7b3b-4fc7-8b94-d9ac7f2c9b44", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f714e77f-e493-4e8a-9e56-ced6d2585b63", "28bbd944-3f3f-4381-be5e-250a8dd99a2b", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "220a6b72-9967-45ad-8a81-11a7c4986ca8", "6496ff5c-10ab-49e7-8a9e-4e6b11027d3a", "Student", "STUDENT" });

            migrationBuilder.CreateIndex(
                name: "IX_UserExams_Exam_id",
                table: "UserExams",
                column: "Exam_id");
        }
    }
}