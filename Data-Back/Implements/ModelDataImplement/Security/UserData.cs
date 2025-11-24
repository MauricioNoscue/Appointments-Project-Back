using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.BaseModelData;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Context;
using Entity_Back.Dto.SecurityDto.RolDto;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Helper;
using Utilities_Back.Message.Email;

namespace Data_Back.Implements.ModelDataImplement.Security
{
    /// <summary>
    /// Implementación de la lógica de acceso a datos para la entidad User.
    /// </summary>
    public class UserData : BaseModelData<User>, IUserData
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor de UserData.
        /// </summary>
        public UserData(ApplicationDbContext context, ILogger<UserData> logger, IConfiguration configuration) : base(context, logger)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Guarda un nuevo usuario en la base de datos.
        /// </summary>
        public override async Task<User> Save(User entity)
        {
            try
            {
                await _context.Set<User>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear el registro para la entidad: {typeof(User).Name}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene el detalle de un usuario por su ID.
        /// </summary>
        public async Task<User> GetUserDetailAsync(int id)
        {
            try
            {
                return await _context.User
                    .Where(u => !u.IsDeleted)
                    .Include(u => u.Person)
                        .ThenInclude(p => p.DocumentType)
                    .Include(u => u.RolUser.Where(ru => !ru.IsDeleted))
                        .ThenInclude(ru => ru.Rol)
                    .FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el detalle del usuario con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Valida las credenciales de un usuario.
        /// </summary>
        public async Task<User?> validarCredenciales(string email, string password)
        {
            try
            {
                var user = await _context.Set<User>()
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                    return null;

                bool isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);

                return isValid ? user : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al validar credenciales para el email: {email}");
                throw;
            }
        }

        /// <summary>
        /// Guarda una nueva persona en la base de datos.
        /// </summary>
        public async Task<Person> SavePerson(Person person)
        {
            try
            {
                await _context.Set<Person>().AddAsync(person);
                await _context.SaveChangesAsync();
                return person;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al guardar la persona.");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios no eliminados.
        /// </summary>
        public override async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                var ltsModel = await _context.Set<User>()
                    .Where(e => !e.IsDeleted)
                    .Include(u => u.Person)
                    .ToListAsync();

                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(User).Name}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        public override async Task<User?> GetById(int id)
        {
            try
            {
                return await _context.Set<User>()
                    .Include(u => u.Person)
                    .FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el registro {typeof(User).Name} con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Solicita el restablecimiento de contraseña para un usuario.
        /// </summary>
        public async Task<string?> RequestPasswordResetAsync(string email)
        {
            try
            {
                var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
                if (user == null) return null;

                var random = new Random();
                var code = random.Next(1000, 10000).ToString();

                user.PasswordResetToken = code;
                user.PasswordResetTokenExpiration = DateTime.UtcNow.AddMinutes(10);

                _context.Update(user);
                await _context.SaveChangesAsync();

                return code;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al solicitar restablecimiento de contraseña para el email: {email}");
                throw;
            }
        }

        /// <summary>
        /// Restablece la contraseña de un usuario usando un token.
        /// </summary>
        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            try
            {
                var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
                if (user == null) return false;

                if (user.PasswordResetToken != token || user.PasswordResetTokenExpiration < DateTime.UtcNow)
                    return false;

                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword, workFactor: 12);
                user.PasswordResetToken = null;
                user.PasswordResetTokenExpiration = null;

                _context.Update(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al restablecer la contraseña para el email: {email}");
                throw;
            }
        }


        /// <summary>
        /// Disminuye el punto de restricción de un usuario.
        /// </summary>
        /// <param name="userId">Identificador del usuario.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        public async Task<bool> DecreaseRestrictionPointAsync(int userId)
        {
            try
            {
                var user = await _context.User
                    .FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == userId);

                if (user == null) return false;

                user.RestrictionPoint = Math.Max((user.RestrictionPoint ?? 0) - 1, 0);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al disminuir el punto de restricción para el usuario con ID: {userId}");
                throw;
            }
        }
        /// <summary>
        /// Restaura el punto de restricción de un usuario.
        /// </summary>
        /// <param name="userId">Identificador del usuario.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        public async Task<bool> RestoreRestrictionPointAsync(int userId)
        {
            try
            {
                var user = await _context.User
                    .FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == userId);

                if (user == null) return false;

                user.RestrictionPoint = 3;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al restaurar el punto de restricción para el usuario con ID: {userId}");
                throw;
            }
        }



    }
}
