using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class maybefinal1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f744343-c9d4-423b-b142-717d56d10cd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96d8a93c-5ee8-4908-94b0-791cbeb502de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba7a34c2-5a5d-4768-b8bc-5ef0e426bc86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc0d75d6-aaea-4d6c-a3de-237e44c8c00a");

            migrationBuilder.AddColumn<float>(
                name: "Mark",
                table: "Attempts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Attempts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f744343-c9d4-423b-b142-717d56d10cd3", null, "Admin", "ADMIN" },
                    { "96d8a93c-5ee8-4908-94b0-791cbeb502de", null, "Student", "STUDENT" },
                    { "ba7a34c2-5a5d-4768-b8bc-5ef0e426bc86", null, "User", "USER" },
                    { "fc0d75d6-aaea-4d6c-a3de-237e44c8c00a", null, "Teacher", "TEACHER" }
                });
        }
    }
}
