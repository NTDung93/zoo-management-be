using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationshipBetweenSpeciesAndMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpeciesId",
                table: "FeedingMenus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FeedingMenus_SpeciesId",
                table: "FeedingMenus",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedingMenus_AnimalSpecies_SpeciesId",
                table: "FeedingMenus",
                column: "SpeciesId",
                principalTable: "AnimalSpecies",
                principalColumn: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedingMenus_AnimalSpecies_SpeciesId",
                table: "FeedingMenus");

            migrationBuilder.DropIndex(
                name: "IX_FeedingMenus_SpeciesId",
                table: "FeedingMenus");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "FeedingMenus");
        }
    }
}
