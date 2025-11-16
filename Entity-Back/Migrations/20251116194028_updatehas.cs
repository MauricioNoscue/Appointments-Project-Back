using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class updatehas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG");
            
            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$E2fN/upRzKvtoyhzn66Ro.LqzQWIUNNXI1EDrjaMC0O.9XpJFp756");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$E2fN/upRzKvtoyhzn66Ro.LqzQWIUNNXI1EDrjaMC0O.9XpJFp756");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$E2fN/upRzKvtoyhzn66Ro.LqzQWIUNNXI1EDrjaMC0O.9XpJFp756");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$12$E2fN/upRzKvtoyhzn66Ro.LqzQWIUNNXI1EDrjaMC0O.9XpJFp756");
        }
    }
}
