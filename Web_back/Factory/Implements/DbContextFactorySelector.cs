using Web_back.Factory.Implements.Database;
using Web_back.Factory.Interface;

namespace Web_back.Factory.Implements
{
    public class DbContextFactorySelector
    {
        public static IDbContextFactory GetFactory(string provider)
        {
            return provider switch
            {
                "SqlServer" => new SqlServerDbContextFactory(),
             
                _ => throw new NotSupportedException($"proveedor{provider} no soportado"),
            };
        }
    }
}
