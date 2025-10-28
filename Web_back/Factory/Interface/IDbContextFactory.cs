using Microsoft.EntityFrameworkCore;

namespace Web_back.Factory.Interface
{
     public interface IDbContextFactory
    {
        /// <summary>
        /// Configura el contexto de base de datos utilizando la cadena de conexión.
        /// </summary>
        /// <param name="optionsBuilder">Constructor de opciones de Entity Framework.</param>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString);
    }
}
