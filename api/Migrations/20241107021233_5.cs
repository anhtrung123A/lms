using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_AspNetUsers_TeacherId",
                table: "Classrooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a40a65d-3d05-474f-b670-8ffd1f859467");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c0f1205-ef0e-4030-b5b4-4fdbfa2af12c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfbf127f-c1c1-47f0-91c1-4c1ffa061615");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f05ff10f-b5e0-4eac-b6a2-e1aa6f4c48e5");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Classrooms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15b7ce7f-e454-42c6-ad10-be2ab99f6a7a", null, "Teacher", "TEACHER" },
                    { "301705c5-4a3c-46c9-a5b1-f4f7069f37b2", null, "User", "USER" },
                    { "a4fda3f1-3605-4699-86ed-51ff5430fa4f", null, "Admin", "ADMIN" },
                    { "ac4a65cf-5eb2-42a2-9085-0d82a0cee39b", null, "Student", "STUDENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_AspNetUsers_TeacherId",
                table: "Classrooms",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_AspNetUsers_TeacherId",
                table: "Classrooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15b7ce7f-e454-42c6-ad10-be2ab99f6a7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "301705c5-4a3c-46c9-a5b1-f4f7069f37b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4fda3f1-3605-4699-86ed-51ff5430fa4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac4a65cf-5eb2-42a2-9085-0d82a0cee39b");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Classrooms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a40a65d-3d05-474f-b670-8ffd1f859467", null, "User", "USER" },
                    { "4c0f1205-ef0e-4030-b5b4-4fdbfa2af12c", null, "Teacher", "TEACHER" },
                    { "cfbf127f-c1c1-47f0-91c1-4c1ffa061615", null, "Student", "STUDENT" },
                    { "f05ff10f-b5e0-4eac-b6a2-e1aa6f4c48e5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_AspNetUsers_TeacherId",
                table: "Classrooms",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
