using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnsForFeedingMenusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedingSchedules_FeedingMenus_ScheduleNo",
                table: "FeedingSchedules");

            migrationBuilder.RenameColumn(
                name: "ScheduleNo",
                table: "FeedingSchedules",
                newName: "MenuNo");

            migrationBuilder.RenameIndex(
                name: "IX_FeedingSchedules_ScheduleNo",
                table: "FeedingSchedules",
                newName: "IX_FeedingSchedules_MenuNo");

            migrationBuilder.RenameColumn(
                name: "ScheduleName",
                table: "FeedingMenus",
                newName: "MenuName");

            migrationBuilder.RenameColumn(
                name: "ScheduleNo",
                table: "FeedingMenus",
                newName: "MenuNo");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedingSchedules_FeedingMenus_MenuNo",
                table: "FeedingSchedules",
                column: "MenuNo",
                principalTable: "FeedingMenus",
                principalColumn: "MenuNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedingSchedules_FeedingMenus_MenuNo",
                table: "FeedingSchedules");

            migrationBuilder.RenameColumn(
                name: "MenuNo",
                table: "FeedingSchedules",
                newName: "ScheduleNo");

            migrationBuilder.RenameIndex(
                name: "IX_FeedingSchedules_MenuNo",
                table: "FeedingSchedules",
                newName: "IX_FeedingSchedules_ScheduleNo");

            migrationBuilder.RenameColumn(
                name: "MenuName",
                table: "FeedingMenus",
                newName: "ScheduleName");

            migrationBuilder.RenameColumn(
                name: "MenuNo",
                table: "FeedingMenus",
                newName: "ScheduleNo");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedingSchedules_FeedingMenus_ScheduleNo",
                table: "FeedingSchedules",
                column: "ScheduleNo",
                principalTable: "FeedingMenus",
                principalColumn: "ScheduleNo");
        }
    }
}
