using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;
using Entity_Back.Models.HospitalModel;
using Entity_Back.Models.Infrastructure;
using Entity_Back.Models.Notification;
using Entity_Back.Models.Request;
using Entity_Back.Models.Security;
using Entity_Back.Models.SecurityModels;
using Entity_Back.Models.Status;
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


            modelBuilder.Entity<Citation>()
         .HasOne(c => c.User)
         .WithMany(u => u.Citation)
         .HasForeignKey(c => c.UserId)
         .OnDelete(DeleteBehavior.Restrict); // o .NoAction

            modelBuilder.Entity<RelatedPerson>()
         .HasOne(rp => rp.Person)
         .WithMany(p => p.RelatedPerson)
         .HasForeignKey(rp => rp.PersonId)
         .OnDelete(DeleteBehavior.Restrict);  // o .NoAction()

            modelBuilder.Entity<RelatedPerson>()
         .HasOne(rp => rp.DocumentType)
         .WithMany()
         .HasForeignKey(rp => rp.DocumentTypeId)
         .OnDelete(DeleteBehavior.Restrict);  // o .NoAction()

            modelBuilder.Entity<Doctor>()
         .HasOne(d => d.Specialty)
         .WithMany(s => s.Doctors)
         .HasForeignKey(d => d.SpecialtyId)
         .OnDelete(DeleteBehavior.Restrict);
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
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolFormPermission> RolFormPermission { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }



        //hospital
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Eps> Eps { get; set; }
        public DbSet<Specialty> Specialty { get; set; }
        public DbSet<Citation> Citation { get; set; }
        public DbSet<ScheduleHour> ScheduleHours { get; set; }
        public DbSet<ConsultingRoom> ConsultingRooms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<TypeCitation> TypeCitations { get; set; }
        public DbSet<Shedule> Shedules { get; set; }
        public DbSet<RelatedPerson> RelatedPerson { get; set; }



        //Infrastructure

        public DbSet<Branch> Branch { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Departament> Departament { get; set; }
        public DbSet<Institution> Institution { get; set; }


        //Notification

        public DbSet<Notifications> Notification { get; set; }



        public DbSet<StatusTypes> StatusTypes { get; set; }
        public DbSet<ModificationRequest> ModificationRequest{ get; set;}
    }
}