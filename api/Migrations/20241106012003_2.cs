using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_AspNetUsers_AppUserId",
                table: "Classrooms");

            migrationBuilder.DropIndex(
                name: "IX_Classrooms_AppUserId",
                table: "Classrooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d0b4406-4b01-4eda-9f66-195de972c8b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5283d38a-d656-4574-b9ba-95463f166c1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d4abe44-2f89-4b5f-b034-0ce4aff16ce0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d097a58-3699-429f-9edd-5dd65c4f31a8");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "TeacherId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "AppUserId",
                table: "Classrooms",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Classrooms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d0b4406-4b01-4eda-9f66-195de972c8b9", null, "Teacher", "TEACHER" },
                    { "5283d38a-d656-4574-b9ba-95463f166c1b", null, "Admin", "ADMIN" },
                    { "6d4abe44-2f89-4b5f-b034-0ce4aff16ce0", null, "User", "USER" },
                    { "7d097a58-3699-429f-9edd-5dd65c4f31a8", null, "Student", "STUDENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_AppUserId",
                table: "Classrooms",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_AspNetUsers_AppUserId",
                table: "Classrooms",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
