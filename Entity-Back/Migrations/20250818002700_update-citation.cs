using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class updatecitation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "Medical",
                table: "Citation",
                newName: "AppointmentDate");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeBlock",
                schema: "Medical",
                table: "Citation",
                type: "time",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Medical",
                table: "Citation",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeBlock",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Medical",
                table: "Citation",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeBlock",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeBlock",
                schema: "Medical",
                table: "Citation");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                schema: "Medical",
                table: "Citation",
                newName: "CreationDate");
        }
    }
}
