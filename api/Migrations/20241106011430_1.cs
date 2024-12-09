using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "361e6830-c8c2-40c4-9d58-7cecd61dd909");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d045b80-089a-4458-a8f1-78aaaf16b62b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57c94298-c2c6-4b8b-b5fe-dd7f317d96c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "679507e3-56fa-443c-ae96-b167f5179a43");

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassName = table.Column<string>(type: "text", nullable: false),
                    TeacherId = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classrooms_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classrooms");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "361e6830-c8c2-40c4-9d58-7cecd61dd909", null, "Student", "STUDENT" },
                    { "3d045b80-089a-4458-a8f1-78aaaf16b62b", null, "Admin", "ADMIN" },
                    { "57c94298-c2c6-4b8b-b5fe-dd7f317d96c6", null, "Teacher", "TEACHER" },
                    { "679507e3-56fa-443c-ae96-b167f5179a43", null, "User", "USER" }
                });
        }
    }
}
