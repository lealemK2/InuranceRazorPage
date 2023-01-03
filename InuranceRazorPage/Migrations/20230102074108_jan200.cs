using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InuranceRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class jan200 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nthMember",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "NthTracker",
                table: "Cbhis",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NthTracker",
                table: "Cbhis");

            migrationBuilder.AddColumn<int>(
                name: "nthMember",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
