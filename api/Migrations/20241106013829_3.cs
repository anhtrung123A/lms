using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_AspNetUsers_TeacherIdId",
                table: "Classrooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cb04fd6-12f4-4f70-bc68-58d071a9af49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f1d8dce-6215-4ba9-b1f3-63f90a66bb25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5ade02c-1735-4db0-b668-b2f6d0645eee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfdc3508-b713-40d9-b6ae-01b6ab44883d");

            migrationBuilder.RenameColumn(
                name: "TeacherIdId",
                table: "Classrooms",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Classrooms_TeacherIdId",
                table: "Classrooms",
                newName: "IX_Classrooms_TeacherId");

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TimeLimit = table.Column<int>(type: "integer", nullable: false),
                    ClassroomId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    TestId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0880a68f-3e4e-4742-8493-9da179d6347e", null, "User", "USER" },
                    { "388ca85d-5175-44cc-9b1f-a7ed95b6a7e5", null, "Teacher", "TEACHER" },
                    { "438aab65-9baa-4ae1-8d22-21781391cc37", null, "Admin", "ADMIN" },
                    { "bec764cd-8996-4641-a54c-e50eaaa6d91a", null, "Student", "STUDENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_ClassroomId",
                table: "Tests",
                column: "ClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_AspNetUsers_TeacherId",
                table: "Classrooms",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_AspNetUsers_TeacherId",
                table: "Classrooms");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0880a68f-3e4e-4742-8493-9da179d6347e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "388ca85d-5175-44cc-9b1f-a7ed95b6a7e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438aab65-9baa-4ae1-8d22-21781391cc37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bec764cd-8996-4641-a54c-e50eaaa6d91a");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Classrooms",
                newName: "TeacherIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Classrooms_TeacherId",
                table: "Classrooms",
                newName: "IX_Classrooms_TeacherIdId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8cb04fd6-12f4-4f70-bc68-58d071a9af49", null, "Admin", "ADMIN" },
                    { "8f1d8dce-6215-4ba9-b1f3-63f90a66bb25", null, "Teacher", "TEACHER" },
                    { "b5ade02c-1735-4db0-b668-b2f6d0645eee", null, "Student", "STUDENT" },
                    { "dfdc3508-b713-40d9-b6ae-01b6ab44883d", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_AspNetUsers_TeacherIdId",
                table: "Classrooms",
                column: "TeacherIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
