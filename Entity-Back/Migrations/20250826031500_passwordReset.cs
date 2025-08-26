using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class passwordReset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                schema: "ModelSecurity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordResetTokenExpiration",
                schema: "ModelSecurity",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordResetToken", "PasswordResetTokenExpiration" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordResetToken", "PasswordResetTokenExpiration" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                schema: "ModelSecurity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordResetTokenExpiration",
                schema: "ModelSecurity",
                table: "User");
        }
    }
}
