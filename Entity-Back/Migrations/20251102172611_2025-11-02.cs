using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class _20251102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Doctores");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 8,
                column: "Url",
                value: "/admin/security/gestionFormularios");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Consultorios");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Tipos de cita");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Solicitudes", "/admin/solicitudes" });

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Mi espacio");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Doctor");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Perfil profesional");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mostrar");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "VerTodo");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Crear");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Editar");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Eliminar");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$12$7r5efoSjg.sH1lG0aPAKyuOJSOmfbqy440K2iGW4c9mO8TXe5SM3S");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$12$7r5efoSjg.sH1lG0aPAKyuOJSOmfbqy440K2iGW4c9mO8TXe5SM3S");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$12$7r5efoSjg.sH1lG0aPAKyuOJSOmfbqy440K2iGW4c9mO8TXe5SM3S");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$12$7r5efoSjg.sH1lG0aPAKyuOJSOmfbqy440K2iGW4c9mO8TXe5SM3S");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Doctor");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 8,
                column: "Url",
                value: "/admin/security/gestion");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Consultorio");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Tipo de cita");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Citas disponibles", "/admin/CitationAviable" });

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Inicio paciente");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Inicio Doctor");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Form",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Perfil..");

            migrationBuilder.InsertData(
                schema: "ModelSecurity",
                table: "Form",
                columns: new[] { "Id", "Description", "Icon", "IsDeleted", "ModuleId", "Name", "RegistrationDate", "Url" },
                values: new object[] { 9, "Gestión de permisos en formularios", "rule", false, 2, "Gestión de formularios", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/security/gestionFormularios" });

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "View");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "ViewAll");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Create");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Edit");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Delete");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "M1d!Citas2025");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "M2d!Citas2025");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "M2d!Citas2025");

            migrationBuilder.UpdateData(
                schema: "ModelSecurity",
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "M2d!Citas2025");
        }
    }
}
