﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InuranceRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class jan4007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Customers");
        }
    }
}
