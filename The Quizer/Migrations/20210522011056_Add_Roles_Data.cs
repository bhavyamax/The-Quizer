using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Quizer.Migrations
{
    public partial class Add_Roles_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "926482c7-9c7f-415d-835d-2ac129486553", "d7f82ba5-a784-4376-8597-4a98c6717f28", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5859b341-cf87-4b1a-998f-68c14afa08a1", "344a46e9-d62e-4ac4-9847-28172d7f344a", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f6b0cf0-a552-4af1-87b4-5c46cab2492f", "1419df95-6381-47d6-b558-af7e139c1531", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f6b0cf0-a552-4af1-87b4-5c46cab2492f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5859b341-cf87-4b1a-998f-68c14afa08a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "926482c7-9c7f-415d-835d-2ac129486553");
        }
    }
}