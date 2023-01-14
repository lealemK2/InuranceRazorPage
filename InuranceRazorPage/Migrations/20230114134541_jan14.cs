using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InuranceRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class jan14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subcity",
                table: "Locations");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SubcityId",
                table: "Locations",
                column: "SubcityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Subcities_SubcityId",
                table: "Locations",
                column: "SubcityId",
                principalTable: "Subcities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Subcities_SubcityId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_SubcityId",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "Subcity",
                table: "Locations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
