using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToOrder_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AllowForeignKeyNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Restaurants_restaurant_id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_user_id",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_user_id",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "restaurant_id",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_user_id",
                table: "Addresses",
                column: "user_id",
                unique: true,
                filter: "[user_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Restaurants_restaurant_id",
                table: "Addresses",
                column: "restaurant_id",
                principalTable: "Restaurants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_user_id",
                table: "Addresses",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Restaurants_restaurant_id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_user_id",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_user_id",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "restaurant_id",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_user_id",
                table: "Addresses",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Restaurants_restaurant_id",
                table: "Addresses",
                column: "restaurant_id",
                principalTable: "Restaurants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_user_id",
                table: "Addresses",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
