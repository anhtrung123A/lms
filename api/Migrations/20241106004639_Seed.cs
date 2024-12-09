using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ef3f150-7f80-4a4c-becf-6d135db0745c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e49feda7-7da1-46ca-b26b-77be552c4766");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ef3f150-7f80-4a4c-becf-6d135db0745c", null, "Admin", "ADMIN" },
                    { "e49feda7-7da1-46ca-b26b-77be552c4766", null, "User", "USER" }
                });
        }
    }
}
