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
    public class UserData : BaseModelData<User>, IUserData
    {
        private readonly IConfiguration _configuration;

        public UserData(ApplicationDbContext context, ILogger<UserData> logger, IConfiguration configuration) : base(context, logger)
        {
            _configuration = configuration;
        }

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

        public async Task<User> GetUserDetailAsync(int id)
        {
            return await _context.User
                .Where(u => !u.IsDeleted) // Usuario no eliminado
                .Include(u => u.Person)
                    .ThenInclude(p => p.DocumentType)
                .Include(u => u.RolUser.Where(ru => !ru.IsDeleted)) // Relación no eliminada
                    .ThenInclude(ru => ru.Rol)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> validarCredenciales(string email, string password)
        {
            // Buscar solo por email
            var user = await _context.Set<User>()
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return null;

            // Verificar contraseña (password plano vs hash guardado)
            bool isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            return isValid ? user : null;
        }


        public async Task<Person> SavePerson(Person person)
        {
            await _context.Set<Person>().AddAsync(person);
            await _context.SaveChangesAsync();
            return person;
        }


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


        public async Task<string?> RequestPasswordResetAsync(string email)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            // Generar un código de 4 dígitos (ej: 1234)
            var random = new Random();
            var code = random.Next(1000, 10000).ToString(); // siempre entre 1000 y 9999

            user.PasswordResetToken = code; // puedes seguir usando esta columna
            user.PasswordResetTokenExpiration = DateTime.UtcNow.AddMinutes(10); // ejemplo: 10 min de validez


            _context.Update(user);
            await _context.SaveChangesAsync();

            return code; // para que la capa Business lo use (ej: enviar correo)
        }


        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return false;

            // Validar token
            if (user.PasswordResetToken != token || user.PasswordResetTokenExpiration < DateTime.UtcNow)
                return false;

            // Hashear nueva contraseña
            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword, workFactor: 12);

            // Limpiar token
            user.PasswordResetToken = null;
            user.PasswordResetTokenExpiration = null;

            _context.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }


      
    }
}
