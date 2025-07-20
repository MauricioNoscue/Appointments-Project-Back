using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Hospital");

            migrationBuilder.EnsureSchema(
                name: "ModelSecurity");

            migrationBuilder.CreateTable(
                name: "DocumentType",
                schema: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eps",
                schema: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "ModelSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateBorn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    HealthRegime = table.Column<int>(type: "int", nullable: false),
                    EpsId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalSchema: "Hospital",
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_Eps_EpsId",
                        column: x => x.EpsId,
                        principalSchema: "Hospital",
                        principalTable: "Eps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolUser_Rol_RolId",
                        column: x => x.RolId,
                        principalSchema: "ModelSecurity",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "DocumentType",
                columns: new[] { "Id", "Acronym", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "CC", false, "Cédula Ciudadanía", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "TI", false, "Tarjeta Identidad", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "RC", false, "Registro Civil", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "TE", false, "Tarjeta de Extranjería", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "PP", false, "Pasaporte", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "PEP", false, "Permiso Especial de Permanencia", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Eps",
                columns: new[] { "Id", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, false, "Coosalud EPS‑S", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, false, "Nueva EPS", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, false, "Mutual SER", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, false, "Salud MÍA", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, false, "Aliansalud EPS", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, false, "Salud Total EPS S.A.", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, false, "EPS Sanitas", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, false, "EPS Sura", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, false, "Famisanar", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, false, "Servicio Occidental de Salud – SOS", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, false, "Comfenalco Valle", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, false, "Compensar EPS", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, false, "Empresas Públicas de Medellín – EPM", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, false, "Fondo de Pasivo Social de Ferrocarriles Nacionales de Colombia", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, false, "Cajacopi Atlántico", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, false, "Capresoca", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, false, "Comfachocó", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, false, "Comfaoriente", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, false, "EPS Familiar de Colombia", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, false, "Asmet Salud", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, false, "Emssanar E.S.S.", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, false, "Capital Salud EPS‑S", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, false, "Savia Salud EPS", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, false, "Dusakawi EPSI", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, false, "Asociación Indígena del Cauca EPSI", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, false, "Anas Wayuu EPSI", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, false, "Mallamas EPSI", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, false, "Pijaos Salud EPSI", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "ModelSecurity",
                table: "Rol",
                columns: new[] { "Id", "Description", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "Rol de administrador", false, "Admin", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Rol estándar", false, "Usuario", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_DocumentTypeId",
                table: "Person",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_EpsId",
                table: "Person",
                column: "EpsId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_RolId",
                table: "RolUser",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_UserId",
                table: "RolUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolUser");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "ModelSecurity");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "DocumentType",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Eps",
                schema: "Hospital");
        }
    }
}
