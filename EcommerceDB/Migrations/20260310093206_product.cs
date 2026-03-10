using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceDB.Migrations
{
    /// <inheritdoc />
    public partial class product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ISDeleted",
                schema: "Sales",
                table: "Product",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                schema: "Sales",
                table: "Product",
                type: "int",
                nullable: true,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISDeleted",
                schema: "Sales",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Stock",
                schema: "Sales",
                table: "Product");
        }
    }
}
