using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class intergration_campo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReltedPersonId",
                schema: "Medical",
                table: "Citation",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Medical",
                table: "Citation",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReltedPersonId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReltedPersonId",
                schema: "Medical",
                table: "Citation");
        }
    }
}
