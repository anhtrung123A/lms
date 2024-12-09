using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class maybefinal11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21a74ca7-0d5f-4484-a1ff-5a494171c385");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "454c3e3d-1a08-4062-a000-51f5f3ab686c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79edec56-446d-44f4-ba0c-61c7271d0d9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fad38a1b-be8a-49fd-8a00-8702456f1cd1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ad82c24-9fb2-46ed-a42c-97344b8bcae6", null, "User", "USER" },
                    { "80e3e6f1-47fa-4e36-bc52-c42cbd7d5ca7", null, "Teacher", "TEACHER" },
                    { "a371c379-6e0f-41ee-b645-f8e7c8651c1a", null, "Admin", "ADMIN" },
                    { "d10cf699-bf7d-4788-b17f-b85203486fc1", null, "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ad82c24-9fb2-46ed-a42c-97344b8bcae6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80e3e6f1-47fa-4e36-bc52-c42cbd7d5ca7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a371c379-6e0f-41ee-b645-f8e7c8651c1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d10cf699-bf7d-4788-b17f-b85203486fc1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21a74ca7-0d5f-4484-a1ff-5a494171c385", null, "Teacher", "TEACHER" },
                    { "454c3e3d-1a08-4062-a000-51f5f3ab686c", null, "Student", "STUDENT" },
                    { "79edec56-446d-44f4-ba0c-61c7271d0d9e", null, "User", "USER" },
                    { "fad38a1b-be8a-49fd-8a00-8702456f1cd1", null, "Admin", "ADMIN" }
                });
        }
    }
}
