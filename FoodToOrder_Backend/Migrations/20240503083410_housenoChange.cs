using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToOrder_Backend.Migrations
{
    /// <inheritdoc />
    public partial class housenoChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "houseNo",
                table: "Addresses",
                newName: "houseno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "houseno",
                table: "Addresses",
                newName: "houseNo");
        }
    }
}
