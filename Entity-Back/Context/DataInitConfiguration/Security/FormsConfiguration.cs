using System;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_Back.Context.DataInitConfiguration.Security
{
    public class FormsConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            // Comentario (ES): Índice único para evitar duplicados en el nombre
            builder.HasIndex(f => f.Name).IsUnique();
            builder.HasData(
                // ===== Inicio =====
                new Form { Id = 1, Name = "Dashboard", Description = "Panel principal", Url = "/admin/dashboard", ModuleId = 1, Icon = "dashboard", RegistrationDate = new DateTime(2024, 7, 16) },

                // ===== Seguridad =====
                new Form { Id = 3, Name = "Formulario", Description = "Gestión de formularios", Url = "/admin/security/form", ModuleId = 2, Icon = "topic", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 4, Name = "Rol", Description = "Gestión de roles", Url = "/admin/security/rol", ModuleId = 2, Icon = "admin_panel_settings", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 5, Name = "Usuario", Description = "Gestión de usuarios", Url = "/admin/security/user", ModuleId = 2, Icon = "person", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 6, Name = "Permisos", Description = "Gestión de permisos", Url = "/admin/security/permission", ModuleId = 2, Icon = "vpn_key", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 7, Name = "Módulos", Description = "Gestión de módulos", Url = "/admin/security/module", ModuleId = 2, Icon = "view_module", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 8, Name = "Gestión de usuarios y roles", Description = "Gestión de usuarios y roles", Url = "/admin/security/gestion", ModuleId = 2, Icon = "supervisor_account", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 9, Name = "Gestión de formularios", Description = "Gestión de permisos en formularios", Url = "/admin/security/gestionFormularios", ModuleId = 2, Icon = "rule", RegistrationDate = new DateTime(2024, 7, 16) },

                // ===== Citas =====
                new Form { Id = 2, Name = "Doctor", Description = "Gestión de doctores", Url = "/admin/doctor", ModuleId = 3, Icon = "medical_services", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 10, Name = "Consultorio", Description = "Gestión de consultorios", Url = "/admin/consultorio", ModuleId = 3, Icon = "local_hospital", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 15, Name = "Tipo de cita", Description = "Gestión de tipos de cita", Url = "/admin/typecitation", ModuleId = 3, Icon = "event_note", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 16, Name = "Citas disponibles", Description = "Visualización de citas disponibles", Url = "/admin/CitationAviable", ModuleId = 3, Icon = "event_available", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 17, Name = "Horarios", Description = "Gestión de horarios", Url = "/admin/horarios", ModuleId = 3, Icon = "schedule", RegistrationDate = new DateTime(2024, 7, 16) },

                // ===== Parámetros =====
                new Form { Id = 11, Name = "Sucursal", Description = "Gestión de sucursales", Url = "/admin/branch", ModuleId = 4, Icon = "store", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 12, Name = "Ciudad", Description = "Gestión de ciudades", Url = "/admin/city", ModuleId = 4, Icon = "location_city", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 13, Name = "Departamento", Description = "Gestión de departamentos", Url = "/admin/departament", ModuleId = 4, Icon = "domain", RegistrationDate = new DateTime(2024, 7, 16) },
                new Form { Id = 14, Name = "Instituciones", Description = "Gestión de instituciones", Url = "/admin/institusions", ModuleId = 4, Icon = "account_balance", RegistrationDate = new DateTime(2024, 7, 16) }
            );

            builder.ToTable("Form", schema: "ModelSecurity");
        }
    }
}
