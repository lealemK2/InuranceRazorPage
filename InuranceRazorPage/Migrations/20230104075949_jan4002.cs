using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InuranceRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class jan4002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalFeePerMember",
                table: "Payments",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalMembers",
                table: "Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LimitOfMembersPerPackage",
                table: "Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PackageFee",
                table: "Payments",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PackageName",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PayableMembers",
                table: "Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalFeePerMember",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "AdditionalMembers",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "LimitOfMembersPerPackage",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PackageFee",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PackageName",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PayableMembers",
                table: "Payments");
        }
    }
}
