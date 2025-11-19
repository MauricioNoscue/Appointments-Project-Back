using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class awsinital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Permite ver un registro normal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Permite ver un registro");
        }
    }
}
