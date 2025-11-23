using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class updateInitReporgamda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StatusTypes",
                columns: new[] { "Id", "CategoryStatus", "Description", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[] { 10, 2, "Reprogramada citation", false, "Reprogamada", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatusTypes",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
