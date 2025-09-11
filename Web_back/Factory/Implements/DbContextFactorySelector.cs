using Web_back.Factory.Implements.Database;
using Web_back.Factory.Interface;

namespace Web_back.Factory.Implements
{
    public class DbContextFactorySelector
    {
        public static IDbContextFactory GetFactory(string provider)
        {
            return provider?.ToLower() switch
            {
                "sqlserver" => new SqlServerDbContextFactory(),
                "postgres" => new PostgresDbContextFactory(),
                "mysql" => new MySqlDbContextFactory(),

                _ => throw new NotSupportedException($"Proveedor '{provider}' no soportado"),
            };
        }
    }
}
