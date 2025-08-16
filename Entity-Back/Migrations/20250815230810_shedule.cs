using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class shedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "BreakEndTime",
                schema: "Medical",
                table: "ScheduleHour",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BreakStartTime",
                schema: "Medical",
                table: "ScheduleHour",
                type: "time",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Medical",
                table: "ScheduleHour",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BreakEndTime", "BreakStartTime" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "Medical",
                table: "ScheduleHour",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BreakEndTime", "BreakStartTime" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "Medical",
                table: "ScheduleHour",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BreakEndTime", "BreakStartTime" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakEndTime",
                schema: "Medical",
                table: "ScheduleHour");

            migrationBuilder.DropColumn(
                name: "BreakStartTime",
                schema: "Medical",
                table: "ScheduleHour");
        }
    }
}
