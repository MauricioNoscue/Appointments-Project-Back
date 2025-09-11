using Microsoft.EntityFrameworkCore;
using Web_back.Factory.Interface;

namespace Web_back.Factory.Implements.Database
{
    public class MySqlDbContextFactory : IDbContextFactory
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MySql");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
