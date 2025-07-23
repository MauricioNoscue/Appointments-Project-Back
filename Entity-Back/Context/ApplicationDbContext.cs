using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;
using Entity_Back.Models.HospitalModel;
using Entity_Back.Models.Security;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module = Entity_Back.Models.SecurityModels.Module;

namespace Entity_Back.Context
{
    public class ApplicationDbContext : DbContext

    {
        protected readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Person>()
            .HasOne(p => p.User)
            .WithOne(u => u.Person)
            .HasForeignKey<User>(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        }


        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }


        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();


            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                if (entry.State == EntityState.Added && entry.Entity.RegistrationDate == null)
                {
                    entry.Entity.RegistrationDate = DateTime.Now;
                }
            }
        }



        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            EnsureAudit();

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        //security
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<RolUser> RolUser { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<FormModule> Formmodule { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolFormPermission> RolFormPermission { get; set; }




        //hospital
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Eps> Eps { get; set; }
        public DbSet<Citation> Citation { get; set; }
        public DbSet<ScheduleHour> ScheduleHours { get; set; }
        public DbSet<ConsultingRoom> ConsultingRooms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<TypeCitation> TypeCitations { get; set; }
        public DbSet<Shedule> Shedules { get; set; }




    }
}
