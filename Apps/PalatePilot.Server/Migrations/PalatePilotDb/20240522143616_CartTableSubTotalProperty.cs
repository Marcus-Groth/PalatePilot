using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PalatePilot.Server.Migrations.PalatePilotDb
{
    /// <inheritdoc />
    public partial class CartTableSubTotalProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubTotal",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Carts");
        }
    }
}
