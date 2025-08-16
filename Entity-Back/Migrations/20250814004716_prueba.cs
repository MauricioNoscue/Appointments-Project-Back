using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Hospital",
                table: "ConsultingRoom",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Hospital",
                table: "ConsultingRoom",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Hospital",
                table: "ConsultingRoom",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Image", "IsActive" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "Hospital",
                table: "ConsultingRoom",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "IsActive" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "Hospital",
                table: "ConsultingRoom",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Image", "IsActive" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Hospital",
                table: "ConsultingRoom");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Hospital",
                table: "ConsultingRoom");
        }
    }
}
