using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities_Back.Helper
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Genera un hash seguro a partir de una contraseña en texto plano.
        /// </summary>
        /// <param name="plainPassword">Contraseña sin encriptar.</param>
        /// <param name="workFactor">Nivel de complejidad del hash (por defecto 10).</param>
        /// <returns>Contraseña encriptada (hash).</returns>
        public static string HashPassword(string plainPassword, int workFactor = 10)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword, workFactor);
        }

        /// <summary>
        /// Verifica si la contraseña en texto plano coincide con el hash proporcionado.
        /// </summary>
        /// <param name="plainPassword">Contraseña ingresada por el usuario.</param>
        /// <param name="hashedPassword">Hash almacenado en la base de datos.</param>
        /// <returns>true si coinciden, false en caso contrario.</returns>
        public static bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}
