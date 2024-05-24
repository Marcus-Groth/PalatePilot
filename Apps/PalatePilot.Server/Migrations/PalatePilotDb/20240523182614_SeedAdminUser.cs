using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PalatePilot.Server.Migrations.PalatePilotDb
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ADMIN_ID", "ADMIN_ID", "Admin", "ADMIN" },
                    { "USER_ID", "USER_ID", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fa32a7b1-cee6-4e07-8df7-3e1a34ee0211", 0, "8c607685-e46e-4830-931a-2b52c1728b6d", "admin1234@example.com", true, false, null, "ADMIN1234@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEJTcj1xtwmGMsPRv6zjJXI0ShfBuIeDUnD7BeSvS3Gr2t5hahZcPWc1fN7D93pMTxg==", null, false, "904837ba-776d-4592-b1bd-0f763d76dd91", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ADMIN_ID", "fa32a7b1-cee6-4e07-8df7-3e1a34ee0211" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "USER_ID");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ADMIN_ID", "fa32a7b1-cee6-4e07-8df7-3e1a34ee0211" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ADMIN_ID");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa32a7b1-cee6-4e07-8df7-3e1a34ee0211");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "1", "User", "USER" },
                    { "2", "2", "Admin", "ADMIN" }
                });
        }
    }
}
