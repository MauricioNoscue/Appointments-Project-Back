using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity_Back.Migrations
{
    /// <inheritdoc />
    public partial class reviewdoctorscitationsfeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ModelInfrastructure");

            migrationBuilder.EnsureSchema(
                name: "Medical");

            migrationBuilder.EnsureSchema(
                name: "Hospital");

            migrationBuilder.EnsureSchema(
                name: "ModelSecurity");

            migrationBuilder.CreateTable(
                name: "Departament",
                schema: "ModelInfrastructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departament", x => x.Id);
                });

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
                name: "Module",
                schema: "ModelSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "ModelSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "ModelSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                schema: "Hospital",
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
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeCitation",
                schema: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCitation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "ModelInfrastructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Departament_DepartamentId",
                        column: x => x.DepartamentId,
                        principalSchema: "ModelInfrastructure",
                        principalTable: "Departament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "ModelSecurity",
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
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    HealthRegime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpsId = table.Column<int>(type: "int", nullable: false),
                    FailedAppointments = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.CheckConstraint("CK_Person_Gender", "[Gender] IN ('Masculino', 'Femenino')");
                    table.CheckConstraint("CK_Person_HealthRegime", "[HealthRegime] IN ('Contributivo', 'Subsidiado', 'Excepcion')");
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
                name: "Form",
                schema: "ModelSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Form_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "ModelSecurity",
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Institution",
                schema: "ModelInfrastructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institution_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "ModelInfrastructure",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                schema: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    EmailDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "ModelSecurity",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalSchema: "Hospital",
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedPerson_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalSchema: "Hospital",
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelatedPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "ModelSecurity",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "ModelSecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    CodePassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestrictionPoint = table.Column<int>(type: "int", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rescheduling = table.Column<bool>(type: "bit", nullable: false),
                    PasswordResetTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "ModelSecurity",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolFormPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolFormPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolFormPermission_Form_FormId",
                        column: x => x.FormId,
                        principalSchema: "ModelSecurity",
                        principalTable: "Form",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolFormPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "ModelSecurity",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolFormPermission_Rol_RolId",
                        column: x => x.RolId,
                        principalSchema: "ModelSecurity",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                schema: "ModelInfrastructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalSchema: "ModelInfrastructure",
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModificationRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeRequest = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatustypesId = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModificationRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModificationRequest_StatusTypes_StatustypesId",
                        column: x => x.StatustypesId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModificationRequest_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "ModelSecurity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevokedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "ModelSecurity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUser",
                schema: "ModelSecurity",
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
                        principalSchema: "ModelSecurity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultingRoom",
                schema: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultingRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultingRoom_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "ModelInfrastructure",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shedule",
                schema: "Medical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCitationId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ConsultingRoomId = table.Column<int>(type: "int", nullable: false),
                    NumberCitation = table.Column<int>(type: "int", nullable: false),
                    SheduleId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shedule_ConsultingRoom_ConsultingRoomId",
                        column: x => x.ConsultingRoomId,
                        principalSchema: "Hospital",
                        principalTable: "ConsultingRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shedule_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "Hospital",
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shedule_TypeCitation_TypeCitationId",
                        column: x => x.TypeCitationId,
                        principalSchema: "Hospital",
                        principalTable: "TypeCitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleHour",
                schema: "Medical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ProgramateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SheduleId = table.Column<int>(type: "int", nullable: false),
                    BreakStartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    BreakEndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleHour_Shedule_SheduleId",
                        column: x => x.SheduleId,
                        principalSchema: "Medical",
                        principalTable: "Shedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citation",
                schema: "Medical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeBlock = table.Column<TimeSpan>(type: "time", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleHourId = table.Column<int>(type: "int", nullable: false),
                    ReltedPersonId = table.Column<int>(type: "int", nullable: true),
                    StatustypesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citation_ScheduleHour_ScheduleHourId",
                        column: x => x.ScheduleHourId,
                        principalSchema: "Medical",
                        principalTable: "ScheduleHour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citation_StatusTypes_StatustypesId",
                        column: x => x.StatustypesId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citation_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "ModelSecurity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitationId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorReview_Citation_CitationId",
                        column: x => x.CitationId,
                        principalSchema: "Medical",
                        principalTable: "Citation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorReview_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "Hospital",
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorReview_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "ModelSecurity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatustypesId = table.Column<int>(type: "int", nullable: false),
                    TypeNotification = table.Column<int>(type: "int", nullable: false),
                    citationId = table.Column<int>(type: "int", nullable: true),
                    RedirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Citation_citationId",
                        column: x => x.citationId,
                        principalSchema: "Medical",
                        principalTable: "Citation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notification_StatusTypes_StatustypesId",
                        column: x => x.StatustypesId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "ModelSecurity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "ModelInfrastructure",
                table: "Departament",
                columns: new[] { "Id", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[] { 1, false, "Huila", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
                table: "Module",
                columns: new[] { "Id", "Description", "Icon", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "Módulo de panel principal", "home", false, "Inicio", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Módulo de seguridad (roles/usuarios/permisos)", "security", false, "Seguridad", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Módulo de citas (consultorios/horarios/tipos)", "calendar_month", false, "Citas", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Catálogos y parámetros del sistema", "tune", false, "Parámetros", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Catálogos y parámetros del sistema", "tune", false, "Paciente", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Catálogos y parámetros del sistema", "tune", false, "Doctor", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "ModelSecurity",
                table: "Permission",
                columns: new[] { "Id", "Description", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "Permite ver un registro normal", false, "View", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Permite ver todos los registros (solo Admin)", false, "ViewAll", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Permite crear registros", false, "Create", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Permite editar registros", false, "Edit", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Permite eliminar registros", false, "Delete", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "ModelSecurity",
                table: "Rol",
                columns: new[] { "Id", "Description", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "Rol de administrador con todos los permisos", false, "SuperAdmin", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Rol estándar", false, "Usuario", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Rol estándar de los doctores", false, "Doctor", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Rol de administrador ", false, "Admin", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Specialty",
                columns: new[] { "Id", "Description", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "Atención médica general y preventiva", false, "Medicina General", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Especialidad médica para adultos", false, "Medicina Interna", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Especialidad médica para niños", false, "Pediatría", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Especialidad en salud de la mujer y embarazo", false, "Ginecología y Obstetricia", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Especialidad en enfermedades del corazón", false, "Cardiología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Especialidad en enfermedades de la piel", false, "Dermatología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Especialidad en enfermedades de los ojos", false, "Oftalmología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Especialidad en oído, nariz y garganta", false, "Otorrinolaringología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Especialidad en salud mental", false, "Psiquiatría", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Especialidad en procedimientos quirúrgicos", false, "Cirugía General", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Especialidad en lesiones óseas y musculares", false, "Traumatología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Especialidad en enfermedades del sistema nervioso", false, "Neurología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Especialidad en sistema urinario", false, "Urología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Especialidad en glándulas y hormonas", false, "Endocrinología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Especialidad en riñones", false, "Nefrología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Especialidad en sangre", false, "Hematología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Especialidad en cáncer", false, "Oncología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Especialidad en imágenes médicas", false, "Radiología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Especialidad en anestesia", false, "Anestesiología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Atención médica familiar integral", false, "Medicina Familiar", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StatusTypes",
                columns: new[] { "Id", "CategoryStatus", "Description", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, 2, "Scheduled citation", false, "Programada", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Canceled citation", false, "Cancelada", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "Missed citation", false, "No Asistida", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "completed citation", false, "Atendida", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 0, "Notification sent", false, "Enviada", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 0, "Notification read", false, "Leída", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, "Request pending", false, "Pendiente", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, "Request approved", false, "Aprobada", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, "Request canceled", false, "Cancelada", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "TypeCitation",
                columns: new[] { "Id", "Description", "Icon", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "Evaluación médica básica con revisión general del paciente.", "general.png", false, "Consulta General", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Atención en salud bucal, limpieza, diagnósticos y tratamientos.", "odontologia.png", false, "Odontología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Citas para toma de muestras y análisis clínicos.", "pediatria.png", false, "Pediatría", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Citas para toma de muestras y análisis clínicos.", "CExterna.png", false, "Consulta Externa", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "ModelInfrastructure",
                table: "City",
                columns: new[] { "Id", "DepartamentId", "IsDeleted", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, 1, false, "Acevedo", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, false, "Aipe", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, false, "Algeciras", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, false, "Altamira", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, false, "Baraya", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, false, "Campoalegre", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, false, "Colombia", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, false, "Elías", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, false, "Garzón", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, false, "Gigante", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, false, "Guadalupe", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, false, "Hobo", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, false, "Íquira", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, false, "Isnos", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, false, "La Argentina", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, false, "La Plata", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, false, "Nátaga", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, false, "Neiva", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, false, "Oporapa", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 1, false, "Paicol", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, false, "Palermo", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 1, false, "Palestina", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 1, false, "Pital", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 1, false, "Pitalito", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 1, false, "Rivera", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 1, false, "Saladoblanco", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 1, false, "San Agustín", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 1, false, "Santa María", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 1, false, "Suaza", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 1, false, "Tarqui", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 1, false, "Tello", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 1, false, "Teruel", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 1, false, "Tesalia", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 1, false, "Timaná", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 1, false, "Villavieja", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 1, false, "Yaguará", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "ModelSecurity",
                table: "Form",
                columns: new[] { "Id", "Description", "Icon", "IsDeleted", "ModuleId", "Name", "RegistrationDate", "Url" },
                values: new object[,]
                {
                    { 1, "Panel principal", "dashboard", false, 1, "Dashboard", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/dashboard" },
                    { 2, "Gestión de doctores", "medical_services", false, 3, "Doctor", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/doctor" },
                    { 3, "Gestión de formularios", "topic", false, 2, "Formulario", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/security/form" },
                    { 4, "Gestión de roles", "admin_panel_settings", false, 2, "Rol", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/security/rol" },
                    { 5, "Gestión de usuarios", "person", false, 2, "Usuario", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/security/user" },
                    { 6, "Gestión de permisos", "vpn_key", false, 2, "Permisos", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/security/permission" },
                    { 7, "Gestión de módulos", "view_module", false, 2, "Módulos", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/security/module" },
                    { 8, "Gestión de usuarios y roles", "supervisor_account", false, 2, "Gestión de usuarios y roles", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/security/gestion" },
                    { 9, "Gestión de permisos en formularios", "rule", false, 2, "Gestión de formularios", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/security/gestionFormularios" },
                    { 10, "Gestión de consultorios", "local_hospital", false, 3, "Consultorio", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/consultorio" },
                    { 11, "Gestión de sucursales", "store", false, 4, "Sucursal", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/branch" },
                    { 12, "Gestión de ciudades", "location_city", false, 4, "Ciudad", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/city" },
                    { 13, "Gestión de departamentos", "domain", false, 4, "Departamento", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/departament" },
                    { 14, "Gestión de instituciones", "account_balance", false, 4, "Instituciones", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/institusions" },
                    { 15, "Gestión de tipos de cita", "event_note", false, 3, "Tipo de cita", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/typecitation" },
                    { 16, "Visualización de citas disponibles", "event_available", false, 3, "Citas disponibles", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/CitationAviable" },
                    { 17, "Gestión de horarios", "schedule", false, 3, "Horarios", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/admin/horarios" },
                    { 18, "Gestión de ciudades", "location_city", false, 5, "Inicio paciente", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/paciente/dashboard" },
                    { 19, "Gestión de departamentos", "domain", false, 5, "Mis personas", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/paciente/relacion" },
                    { 20, "Gestión de instituciones", "account_balance", false, 5, "Perfil", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/paciente/perfil" },
                    { 21, "Gestión de ciudades", "location_city", false, 6, "Inicio Doctor", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/doctor/dashboard" },
                    { 22, "Gestión de departamentos", "domain", false, 6, "Perfil..", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/doctor/perfil" },
                    { 23, "Gestión de instituciones", "account_balance", false, 6, "Historial", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/doctor/historial" },
                    { 24, "Gestión de departamentos", "domain", false, 6, "Citas", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/doctor/pendientes" },
                    { 25, "Gestión de departamentos", "domain", false, 5, "Agendar", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/paciente/agendar" }
                });

            migrationBuilder.InsertData(
                schema: "ModelSecurity",
                table: "Person",
                columns: new[] { "Id", "Active", "Address", "DateBorn", "Document", "DocumentTypeId", "EpsId", "FailedAppointments", "FullLastName", "FullName", "Gender", "HealthRegime", "IsDeleted", "PhoneNumber", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, false, null, new DateTime(2006, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "1084922863", 1, 1, 0, "Noscue", "Mauricio", "Masculino", "Contributivo", false, "3133156032", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, false, null, new DateTime(2006, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "1084922863", 1, 1, 0, "Noscue", "María isabel", "Femenino", "Contributivo", false, "3133156032", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, false, null, new DateTime(2006, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "1084922813", 1, 1, 0, "Noscue", "Doctor ", "Femenino", "Contributivo", false, "3133156022", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, false, null, new DateTime(2006, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "1084922213", 1, 1, 0, "Cerqera", "Patricio ", "Femenino", "Contributivo", false, "3153156022", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Doctor",
                columns: new[] { "Id", "Active", "EmailDoctor", "Image", "IsDeleted", "PersonId", "RegistrationDate", "SpecialtyId" },
                values: new object[] { 1, true, "doctor@gmail.com", "doctor1.jpg", false, 3, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                schema: "ModelInfrastructure",
                table: "Institution",
                columns: new[] { "Id", "CityId", "Email", "IsDeleted", "Name", "Nit", "RegistrationDate" },
                values: new object[,]
                {
                    { 10, 1, "info@saludhuila.com", false, "Salud Huila IPS", "900123456-7", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 2, "contacto@pitalitomedico.com", false, "Centro Médico Pitalito", "900987654-3", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RolFormPermission",
                columns: new[] { "Id", "FormId", "IsDeleted", "PermissionId", "RegistrationDate", "RolId" },
                values: new object[,]
                {
                    { 1, 1, false, 1, null, 4 },
                    { 2, 1, false, 3, null, 4 },
                    { 3, 1, false, 4, null, 4 },
                    { 4, 1, false, 5, null, 4 },
                    { 5, 2, false, 1, null, 4 },
                    { 6, 2, false, 3, null, 4 },
                    { 7, 2, false, 4, null, 4 },
                    { 8, 2, false, 5, null, 4 },
                    { 9, 3, false, 1, null, 4 },
                    { 10, 3, false, 3, null, 4 },
                    { 11, 3, false, 4, null, 4 },
                    { 12, 3, false, 5, null, 4 },
                    { 13, 4, false, 1, null, 4 },
                    { 14, 4, false, 3, null, 4 },
                    { 15, 4, false, 4, null, 4 },
                    { 16, 4, false, 5, null, 4 },
                    { 17, 5, false, 1, null, 4 },
                    { 18, 5, false, 3, null, 4 },
                    { 19, 5, false, 4, null, 4 },
                    { 20, 5, false, 5, null, 4 },
                    { 21, 6, false, 1, null, 4 },
                    { 22, 6, false, 3, null, 4 },
                    { 23, 6, false, 4, null, 4 },
                    { 24, 6, false, 5, null, 4 },
                    { 25, 7, false, 1, null, 4 },
                    { 26, 7, false, 3, null, 4 },
                    { 27, 7, false, 4, null, 4 },
                    { 28, 7, false, 5, null, 4 },
                    { 29, 8, false, 1, null, 4 },
                    { 30, 8, false, 3, null, 4 },
                    { 31, 8, false, 4, null, 4 },
                    { 32, 8, false, 5, null, 4 },
                    { 33, 9, false, 1, null, 4 },
                    { 34, 9, false, 3, null, 4 },
                    { 35, 9, false, 4, null, 4 },
                    { 36, 9, false, 5, null, 4 },
                    { 37, 10, false, 1, null, 4 },
                    { 38, 10, false, 3, null, 4 },
                    { 39, 10, false, 4, null, 4 },
                    { 40, 10, false, 5, null, 4 },
                    { 41, 11, false, 1, null, 4 },
                    { 42, 11, false, 3, null, 4 },
                    { 43, 11, false, 4, null, 4 },
                    { 44, 11, false, 5, null, 4 },
                    { 45, 12, false, 1, null, 4 },
                    { 46, 12, false, 3, null, 4 },
                    { 47, 12, false, 4, null, 4 },
                    { 48, 12, false, 5, null, 4 },
                    { 49, 13, false, 1, null, 4 },
                    { 50, 13, false, 3, null, 4 },
                    { 51, 13, false, 4, null, 4 },
                    { 52, 13, false, 5, null, 4 },
                    { 53, 14, false, 1, null, 4 },
                    { 54, 14, false, 3, null, 4 },
                    { 55, 14, false, 4, null, 4 },
                    { 56, 14, false, 5, null, 4 },
                    { 57, 15, false, 1, null, 4 },
                    { 58, 15, false, 3, null, 4 },
                    { 59, 15, false, 4, null, 4 },
                    { 60, 15, false, 5, null, 4 },
                    { 61, 16, false, 1, null, 4 },
                    { 62, 16, false, 3, null, 4 },
                    { 63, 16, false, 4, null, 4 },
                    { 64, 16, false, 5, null, 4 },
                    { 65, 17, false, 1, null, 4 },
                    { 66, 17, false, 3, null, 4 },
                    { 67, 17, false, 4, null, 4 },
                    { 68, 17, false, 5, null, 4 },
                    { 69, 18, false, 1, null, 2 },
                    { 70, 18, false, 3, null, 2 },
                    { 71, 18, false, 4, null, 2 },
                    { 72, 18, false, 5, null, 2 },
                    { 73, 19, false, 1, null, 2 },
                    { 74, 19, false, 3, null, 2 },
                    { 75, 19, false, 4, null, 2 },
                    { 76, 19, false, 5, null, 2 },
                    { 77, 20, false, 1, null, 2 },
                    { 78, 20, false, 3, null, 2 },
                    { 79, 20, false, 4, null, 2 },
                    { 80, 20, false, 5, null, 2 },
                    { 81, 25, false, 1, null, 2 },
                    { 82, 25, false, 3, null, 2 },
                    { 83, 25, false, 4, null, 2 },
                    { 84, 25, false, 5, null, 2 },
                    { 85, 21, false, 1, null, 3 },
                    { 86, 21, false, 3, null, 3 },
                    { 87, 21, false, 4, null, 3 },
                    { 88, 21, false, 5, null, 3 },
                    { 89, 22, false, 1, null, 3 },
                    { 90, 22, false, 3, null, 3 },
                    { 91, 22, false, 4, null, 3 },
                    { 92, 22, false, 5, null, 3 },
                    { 93, 23, false, 1, null, 3 },
                    { 94, 23, false, 3, null, 3 },
                    { 95, 23, false, 4, null, 3 },
                    { 96, 23, false, 5, null, 3 },
                    { 97, 24, false, 1, null, 3 },
                    { 98, 24, false, 3, null, 3 },
                    { 99, 24, false, 4, null, 3 },
                    { 100, 24, false, 5, null, 3 }
                });

            migrationBuilder.InsertData(
                schema: "ModelSecurity",
                table: "User",
                columns: new[] { "Id", "Active", "CodePassword", "Email", "IsDeleted", "Password", "PasswordResetToken", "PasswordResetTokenExpiration", "PersonId", "RegistrationDate", "Rescheduling", "RestrictionPoint" },
                values: new object[,]
                {
                    { 1, false, "no hay", "mauronoscue@gmail.com", false, "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG", null, null, 1, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 },
                    { 2, false, "no hay", "andresmauricionoscue@gmail.com", false, "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG", null, null, 2, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 },
                    { 3, false, "no hay", "doctor@gmail.com", false, "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG", null, null, 3, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 },
                    { 4, false, "no hay", "User@gmail.com", false, "$2a$12$W.YmEOuHGqnmvgh3OsrDveXloBt4awWOGca7sK76gM0H2BuDeyRGG", null, null, 4, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 }
                });

            migrationBuilder.InsertData(
                schema: "ModelInfrastructure",
                table: "Branch",
                columns: new[] { "Id", "Address", "Email", "InstitutionId", "IsDeleted", "Name", "PhoneNumber", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "Cra 7 #12-34", "neiva@ips.com", 10, false, "Sucursal Neiva", "3211112233", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Av Circunvalar #45", "pitalito@ips.com", 10, false, "Sucursal Pitalito", "3224445566", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "ModelSecurity",
                table: "RolUser",
                columns: new[] { "Id", "IsDeleted", "RegistrationDate", "RolId", "UserId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 2, false, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, false, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, false, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "ConsultingRoom",
                columns: new[] { "Id", "BranchId", "Floor", "Image", "IsActive", "IsDeleted", "Name", "RegistrationDate", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, false, "Consultorio General", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 101 },
                    { 2, 1, 2, null, null, false, "Pediatría", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 202 },
                    { 3, 2, 3, null, null, false, "Dermatología", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 303 }
                });

            migrationBuilder.InsertData(
                schema: "Medical",
                table: "Shedule",
                columns: new[] { "Id", "ConsultingRoomId", "DoctorId", "IsDeleted", "NumberCitation", "RegistrationDate", "SheduleId", "TypeCitationId" },
                values: new object[] { 4, 3, 1, false, 24, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4 });

            migrationBuilder.InsertData(
                schema: "Medical",
                table: "ScheduleHour",
                columns: new[] { "Id", "BreakEndTime", "BreakStartTime", "EndTime", "IsDeleted", "ProgramateDate", "RegistrationDate", "SheduleId", "StartTime" },
                values: new object[] { 1, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 23, 0, 0, 0), false, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 8, 0, 0, 0) });

            migrationBuilder.InsertData(
                schema: "Medical",
                table: "Citation",
                columns: new[] { "Id", "AppointmentDate", "IsDeleted", "Note", "RegistrationDate", "ReltedPersonId", "ScheduleHourId", "StatustypesId", "TimeBlock", "UserId" },
                values: new object[] { 2, new DateTime(2025, 8, 23, 17, 34, 12, 220, DateTimeKind.Unspecified), false, "string", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, new TimeSpan(0, 8, 45, 0, 0), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_InstitutionId",
                schema: "ModelInfrastructure",
                table: "Branch",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_Name",
                schema: "ModelInfrastructure",
                table: "Branch",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citation_ScheduleHourId",
                schema: "Medical",
                table: "Citation",
                column: "ScheduleHourId");

            migrationBuilder.CreateIndex(
                name: "IX_Citation_StatustypesId",
                schema: "Medical",
                table: "Citation",
                column: "StatustypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Citation_UserId",
                schema: "Medical",
                table: "Citation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_City_DepartamentId",
                schema: "ModelInfrastructure",
                table: "City",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_City_Name",
                schema: "ModelInfrastructure",
                table: "City",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultingRoom_BranchId",
                schema: "Hospital",
                table: "ConsultingRoom",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Departament_Name",
                schema: "ModelInfrastructure",
                table: "Departament",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_PersonId",
                schema: "Hospital",
                table: "Doctor",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_SpecialtyId",
                schema: "Hospital",
                table: "Doctor",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReview_CitationId",
                table: "DoctorReview",
                column: "CitationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReview_DoctorId",
                table: "DoctorReview",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReview_UserId",
                table: "DoctorReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Form_ModuleId",
                schema: "ModelSecurity",
                table: "Form",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Form_Name",
                schema: "ModelSecurity",
                table: "Form",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institution_CityId",
                schema: "ModelInfrastructure",
                table: "Institution",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Institution_Name",
                schema: "ModelInfrastructure",
                table: "Institution",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModificationRequest_StatustypesId",
                table: "ModificationRequest",
                column: "StatustypesId");

            migrationBuilder.CreateIndex(
                name: "IX_ModificationRequest_UserId",
                table: "ModificationRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_Name",
                schema: "ModelSecurity",
                table: "Module",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_citationId",
                table: "Notification",
                column: "citationId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_StatustypesId",
                table: "Notification",
                column: "StatustypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Name",
                schema: "ModelSecurity",
                table: "Permission",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_DocumentTypeId",
                schema: "ModelSecurity",
                table: "Person",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_EpsId",
                schema: "ModelSecurity",
                table: "Person",
                column: "EpsId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPerson_DocumentTypeId",
                table: "RelatedPerson",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPerson_PersonId",
                table: "RelatedPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Name",
                schema: "ModelSecurity",
                table: "Rol",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolFormPermission_FormId",
                table: "RolFormPermission",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_RolFormPermission_PermissionId",
                table: "RolFormPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolFormPermission_RolId",
                table: "RolFormPermission",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_RolId",
                schema: "ModelSecurity",
                table: "RolUser",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_UserId",
                schema: "ModelSecurity",
                table: "RolUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleHour_SheduleId",
                schema: "Medical",
                table: "ScheduleHour",
                column: "SheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Shedule_ConsultingRoomId",
                schema: "Medical",
                table: "Shedule",
                column: "ConsultingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Shedule_DoctorId",
                schema: "Medical",
                table: "Shedule",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Shedule_TypeCitationId",
                schema: "Medical",
                table: "Shedule",
                column: "TypeCitationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                schema: "ModelSecurity",
                table: "User",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorReview");

            migrationBuilder.DropTable(
                name: "ModificationRequest");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "RelatedPerson");

            migrationBuilder.DropTable(
                name: "RolFormPermission");

            migrationBuilder.DropTable(
                name: "RolUser",
                schema: "ModelSecurity");

            migrationBuilder.DropTable(
                name: "Citation",
                schema: "Medical");

            migrationBuilder.DropTable(
                name: "Form",
                schema: "ModelSecurity");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "ModelSecurity");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "ModelSecurity");

            migrationBuilder.DropTable(
                name: "ScheduleHour",
                schema: "Medical");

            migrationBuilder.DropTable(
                name: "StatusTypes");

            migrationBuilder.DropTable(
                name: "User",
                schema: "ModelSecurity");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "ModelSecurity");

            migrationBuilder.DropTable(
                name: "Shedule",
                schema: "Medical");

            migrationBuilder.DropTable(
                name: "ConsultingRoom",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Doctor",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "TypeCitation",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Branch",
                schema: "ModelInfrastructure");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "ModelSecurity");

            migrationBuilder.DropTable(
                name: "Specialty",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Institution",
                schema: "ModelInfrastructure");

            migrationBuilder.DropTable(
                name: "DocumentType",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Eps",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "City",
                schema: "ModelInfrastructure");

            migrationBuilder.DropTable(
                name: "Departament",
                schema: "ModelInfrastructure");
        }
    }
}
