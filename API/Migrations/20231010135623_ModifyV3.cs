using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ModifyV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalSpecies_Cages_CageId",
                table: "AnimalSpecies");

            migrationBuilder.DropIndex(
                name: "IX_AnimalSpecies_CageId",
                table: "AnimalSpecies");

            migrationBuilder.DropColumn(
                name: "CageId",
                table: "AnimalSpecies");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "TransactionHistories",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                table: "Tickets",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "TransactionHistories",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CageId",
                table: "AnimalSpecies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSpecies_CageId",
                table: "AnimalSpecies",
                column: "CageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalSpecies_Cages_CageId",
                table: "AnimalSpecies",
                column: "CageId",
                principalTable: "Cages",
                principalColumn: "CageId");
        }
    }
}
