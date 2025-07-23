using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Entity_Back.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration;

            string localPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json");

            //buscar en Web_back
            string fallbackPath = Path.Combine(Directory.GetCurrentDirectory(), "../Web_back/appsettings.Development.json");

            string configPath = File.Exists(localPath) ? localPath :
                                File.Exists(fallbackPath) ? fallbackPath :
                                throw new FileNotFoundException("No se encontró appsettings.Development.json en rutas conocidas.");

            configuration = new ConfigurationBuilder()
                .AddJsonFile(configPath)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ApplicationDbContext(optionsBuilder.Options, configuration);
        }
    }
}
