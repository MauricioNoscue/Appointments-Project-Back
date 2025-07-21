using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Business_Back.Services
{
    public class JWTService
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// Constructor del servicio JWT.
        /// </summary>
        /// <param name="config">Configuración de la aplicación (accede a JwtSettings)</param>
        public JWTService(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Genera un token JWT para un usuario autenticado.
        /// </summary>
        /// <param name="userId">ID único del usuario (generalmente el ID de la base de datos)</param>
        /// <param name="username">Correo electrónico o nombre de usuario del usuario</param>
        /// <param name="roles">Lista de roles que posee el usuario</param>
        /// <returns>Token JWT en formato string</returns>
        /// 
        //public string GenerateToken(string userId, string username, List<string> roles, List<string> permission)

        public string GenerateToken(string userId, string username)
        {
            // Obtiene la sección JwtSettings del archivo appsettings.json
            var settings = _config.GetSection("JwtSettings");

            // Crea la clave simétrica usando la clave secreta configurada
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings["key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Crea los claims básicos: ID de usuario, email y un identificador único del token (JTI)
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId), // Identificador del sujeto (usuario)
                new Claim(JwtRegisteredClaimNames.Email, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Identificador único del token
            };

            // Agrega los roles como claims individuales
           // roles.ForEach(rol => claims.Add(new Claim(ClaimTypes.Role, rol)));
           // permission.ForEach(permiso => claims.Add(new Claim("permission", permiso)));
            //permission.ForEach(permiso => claims.Add(new Claim(ClaimTypes.Permissioin, permission)));
            // Crea el token especificando emisor, audiencia, claims, tiempo de expiración y credenciales
            var token = new JwtSecurityToken(
                issuer: settings["Issuer"],
                audience: settings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(settings["ExpiresInMinutes"])),
                signingCredentials: creds
            );

            // Convierte el objeto JWT a string para ser enviado al cliente
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
