using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class _0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Classrooms_ClassroomId",
                table: "Classrooms");

            migrationBuilder.DropIndex(
                name: "IX_Classrooms_ClassroomId",
                table: "Classrooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fe12acc-484d-4c55-bda2-4908b422a34d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "488f6f41-6b6b-4238-853b-22cb8459568c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49062231-e9fc-4344-be3d-d8e89f00f53e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9d1a3a1-ad29-43ca-9012-09be4802b837");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "Classrooms");

            migrationBuilder.AddColumn<string>(
                name: "TeacherIdId",
                table: "Classrooms",
                type: "text",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_TeacherIdId",
                table: "Classrooms",
                column: "TeacherIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_AspNetUsers_TeacherIdId",
                table: "Classrooms",
                column: "TeacherIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_AspNetUsers_TeacherIdId",
                table: "Classrooms");

            migrationBuilder.DropIndex(
                name: "IX_Classrooms_TeacherIdId",
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

            migrationBuilder.DropColumn(
                name: "TeacherIdId",
                table: "Classrooms");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassroomId",
                table: "Classrooms",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fe12acc-484d-4c55-bda2-4908b422a34d", null, "Admin", "ADMIN" },
                    { "488f6f41-6b6b-4238-853b-22cb8459568c", null, "Teacher", "TEACHER" },
                    { "49062231-e9fc-4344-be3d-d8e89f00f53e", null, "User", "USER" },
                    { "b9d1a3a1-ad29-43ca-9012-09be4802b837", null, "Student", "STUDENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_ClassroomId",
                table: "Classrooms",
                column: "ClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Classrooms_ClassroomId",
                table: "Classrooms",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id");
        }
    }
}
