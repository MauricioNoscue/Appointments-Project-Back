using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class _2faUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TwoFactorCode",
                schema: "ModelSecurity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TwoFactorExpiresAt",
                schema: "ModelSecurity",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TwoFactorCode", "TwoFactorExpiresAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TwoFactorCode", "TwoFactorExpiresAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TwoFactorCode", "TwoFactorExpiresAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TwoFactorCode", "TwoFactorExpiresAt" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwoFactorCode",
                schema: "ModelSecurity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TwoFactorExpiresAt",
                schema: "ModelSecurity",
                table: "User");
        }
    }
}
