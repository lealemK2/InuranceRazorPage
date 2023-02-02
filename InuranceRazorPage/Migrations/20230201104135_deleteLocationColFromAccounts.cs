using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InuranceRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class deleteLocationColFromAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Locations_LocationId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_LocationId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Accounts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LocationId",
                table: "Accounts",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Locations_LocationId",
                table: "Accounts",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
