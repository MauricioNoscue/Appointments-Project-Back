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
           .OnDelete(DeleteBehavior.Cascade); // o Restrict según tu lógica

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

        public DbSet<Rol> Rol { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }

        public DbSet<Eps> Eps { get; set; }




    }
}
