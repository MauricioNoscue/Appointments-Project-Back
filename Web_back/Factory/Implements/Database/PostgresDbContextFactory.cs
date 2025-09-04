using Microsoft.EntityFrameworkCore;
using Web_back.Factory.Interface;

namespace Web_back.Factory.Implements.Database
{
    public class PostgresDbContextFactory : IDbContextFactory
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Postgres");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
