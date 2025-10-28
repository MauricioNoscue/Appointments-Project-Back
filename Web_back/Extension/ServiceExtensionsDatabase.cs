using Entity_Back.Context;
using Web_back.Factory.Implements;

namespace Web_back.Extension
{
    public static class ServiceExtensionsDatabase
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            var dbProvider = configuration["DatabaseProvider"];
            var factory = DbContextFactorySelector.GetFactory(dbProvider);

            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                factory.Configure(options, configuration);
            });

            return services;
        }
    }
}
