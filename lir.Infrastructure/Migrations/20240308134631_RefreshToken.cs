using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lir.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefershTokenExpiration",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiration",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiration",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "RefershTokenExpiration",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
