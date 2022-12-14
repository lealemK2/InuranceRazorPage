using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InuranceRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class makeSubcityUniqueILocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Locations_Subcity",
                table: "Locations",
                column: "Subcity",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Locations_Subcity",
                table: "Locations");
        }
    }
}
