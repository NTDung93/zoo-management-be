using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationshipBetweenEmployeesAndAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Areas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_EmployeeId",
                table: "Areas",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Employees_EmployeeId",
                table: "Areas",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Employees_EmployeeId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_EmployeeId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Areas");
        }
    }
}
