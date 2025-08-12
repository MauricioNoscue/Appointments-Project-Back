using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.BaseModelData;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Context;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities_Back.Helper;

namespace Data_Back.Implements.ModelDataImplement.Security
{
    public class UserData : BaseModelData<User>, IUserData
    {
        public UserData(ApplicationDbContext context, ILogger<UserData> logger) : base(context, logger)
        {

        }

       

        public async Task<User> GetUserDetailAsync(int id)
        {
            return await _context.User
    .Include(u => u.Person)
        .ThenInclude(p => p.DocumentType)
    .Include(u => u.RolUser)
        .ThenInclude(ru => ru.Rol)
    .FirstOrDefaultAsync(u => u.Id == id);

        }

        public async Task<User?> validarCredenciales(string email, string password)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

           // if (user == null || !PasswordHelper.VerifyPassword(password, user.Password))
               // return null;

            return user;
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

        

    }
}
