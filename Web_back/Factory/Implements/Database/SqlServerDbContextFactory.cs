using Microsoft.EntityFrameworkCore;
using Web_back.Factory.Interface;

namespace Web_back.Factory.Implements.Database
{
     public class SqlServerFactory : IDbContextFactory
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
