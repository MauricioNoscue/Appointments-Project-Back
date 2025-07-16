using Microsoft.EntityFrameworkCore;

namespace Web_back.Factory.Interface
{
    public interface IDbContextFactory
    {
        void Configure(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration);
    }
}
