using Microsoft.EntityFrameworkCore;
using Web_back.Factory.Interface;

namespace Web_back.Factory.Implements.Database
{
    public class SqlServerDbContextFactory : IDbContextFactory
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
