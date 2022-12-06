using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InuranceRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class addNewColumnTo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "number1",
                table: "Accounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number1",
                table: "Accounts");
        }
    }
}
