using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEmployeeCertificateAndFeedingSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeedingTime",
                table: "FeedingSchedules",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "FeedingSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "FeedingSchedules",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "FeedingSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CertificateImage",
                table: "EmployeeCertificates",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeedingSchedules_EmployeeId",
                table: "FeedingSchedules",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedingSchedules_Employees_EmployeeId",
                table: "FeedingSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedingSchedules_Employees_EmployeeId",
                table: "FeedingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_FeedingSchedules_EmployeeId",
                table: "FeedingSchedules");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "FeedingSchedules");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "FeedingSchedules");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "FeedingSchedules");

            migrationBuilder.DropColumn(
                name: "CertificateImage",
                table: "EmployeeCertificates");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "FeedingSchedules",
                newName: "FeedingTime");
        }
    }
}
