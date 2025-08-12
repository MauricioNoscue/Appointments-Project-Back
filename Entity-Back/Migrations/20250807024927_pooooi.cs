using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class pooooi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citation_User_UserId1",
                schema: "Medical",
                table: "Citation");

            migrationBuilder.DropIndex(
                name: "IX_Citation_UserId1",
                schema: "Medical",
                table: "Citation");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Medical",
                table: "Citation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                schema: "Medical",
                table: "Citation",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Medical",
                table: "Citation",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId1",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Medical",
                table: "Citation",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Citation_UserId1",
                schema: "Medical",
                table: "Citation",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Citation_User_UserId1",
                schema: "Medical",
                table: "Citation",
                column: "UserId1",
                principalSchema: "ModelSecurity",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
