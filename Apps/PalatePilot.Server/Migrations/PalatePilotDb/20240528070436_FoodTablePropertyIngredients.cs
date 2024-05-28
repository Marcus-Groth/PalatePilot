using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PalatePilot.Server.Migrations.PalatePilotDb
{
    /// <inheritdoc />
    public partial class FoodTablePropertyIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ADMIN_ID", "fa32a7b1-cee6-4e07-8df7-3e1a34ee0211" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa32a7b1-cee6-4e07-8df7-3e1a34ee0211");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46f547e5-1b81-4464-96f1-5af492812676", 0, "aee8583c-972b-4951-b12b-0c34eca52bab", "admin1234@example.com", true, false, null, "ADMIN1234@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAED0fMwzuN4WcZSj1jif8b2nHYd66kwgJuYp31VXUNNoH/c40JtiS2nuPrZfqHQzS2g==", null, false, "ffcd5960-9393-410b-8b21-4a67a35f382f", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ingredients", "Name", "Price" },
                values: new object[] { "Dough, Tomato Sauce, Mozzarella, Ham", "Vesuvio Pizza", 11 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Ingredients", "Name", "Price" },
                values: new object[] { "Dough, Tomato Sauce, Mozzarella, Pepperoni", "Pepperoni Pizza", 12 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ingredients", "Name", "Price" },
                values: new object[] { "Dough, BBQ Sauce, Mozzarella, Grilled Chicken, Red Onion, Cilantro", "BBQ Chicken Pizza", 13 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Ingredients", "Name", "Price" },
                values: new object[] { "Dough, Tomato Sauce, Mozzarella, Ham, Pineapple", "Hawaiian Pizza", 12 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Ingredients", "Name", "Price" },
                values: new object[] { "Dough, Tomato Sauce, Mozzarella, Bell Peppers, Onions, Mushrooms, Olives", "Veggie Pizza", 13 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ADMIN_ID", "46f547e5-1b81-4464-96f1-5af492812676" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ADMIN_ID", "46f547e5-1b81-4464-96f1-5af492812676" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46f547e5-1b81-4464-96f1-5af492812676");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Foods");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fa32a7b1-cee6-4e07-8df7-3e1a34ee0211", 0, "8c607685-e46e-4830-931a-2b52c1728b6d", "admin1234@example.com", true, false, null, "ADMIN1234@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEJTcj1xtwmGMsPRv6zjJXI0ShfBuIeDUnD7BeSvS3Gr2t5hahZcPWc1fN7D93pMTxg==", null, false, "904837ba-776d-4592-b1bd-0f763d76dd91", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Andriy", 85 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Cheeseburger", 95 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Margherita Pizza", 110 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Caesar Salad", 70 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Spaghetti Bolognese", 90 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ADMIN_ID", "fa32a7b1-cee6-4e07-8df7-3e1a34ee0211" });
        }
    }
}
