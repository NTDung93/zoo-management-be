using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ModifyFeedingSchedulesAndFeedingMenus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedingQuantity",
                table: "FeedingMenus");

            migrationBuilder.RenameColumn(
                name: "CurrentQuantity",
                table: "Cages",
                newName: "CurrentCapacity");

            migrationBuilder.AlterColumn<decimal>(
                name: "ImportQuantity",
                table: "ImportHistories",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "InventoryQuantity",
                table: "FoodInventories",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "FeedingAmount",
                table: "FeedingSchedules",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedingAmount",
                table: "FeedingSchedules");

            migrationBuilder.RenameColumn(
                name: "CurrentCapacity",
                table: "Cages",
                newName: "CurrentQuantity");

            migrationBuilder.AlterColumn<int>(
                name: "ImportQuantity",
                table: "ImportHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryQuantity",
                table: "FoodInventories",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AddColumn<int>(
                name: "FeedingQuantity",
                table: "FeedingMenus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
