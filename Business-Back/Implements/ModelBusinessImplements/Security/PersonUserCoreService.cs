using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.IBusinessModel.Security;
using Business_Back.Interface;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Dto.SecurityDto.UserDto;
using Entity_Back.Context;

namespace Business_Back.Implements.ModelBusinessImplements.Security
{
    public class PersonUserCoreService : IPersonUserCoreService
    {
        private readonly IPersonBusiness _personBusiness;
        private readonly IUserBusiness _userBusiness;
        private readonly ApplicationDbContext _context;

        public PersonUserCoreService(
            IPersonBusiness personBusiness,
            IUserBusiness userBusiness,
            ApplicationDbContext context)
        {
            _personBusiness = personBusiness;
            _userBusiness = userBusiness;
            _context = context;
        }


        public async Task<UserListDto> CreatePersonAndUserAsync(PersonUserCreateDto dto)
        {
            using var tx = await _context.Database.BeginTransactionAsync();

            try
            {
                // PERSON
                var personDto = new PersonCreatedDto
                {
                    FullName = dto.FullName,
                    FullLastName = dto.FullLastName,
                    DocumentTypeId = dto.DocumentTypeId,
                    Document = dto.Document,
                    DateBorn = dto.DateBorn,
                    PhoneNumber = dto.PhoneNumber,
                    Gender = dto.Gender.ToString(),
                    HealthRegime = dto.HealthRegime.ToString(),
                    EpsId = dto.EpsId,
                    Address = dto.Address
                };

                var newPerson = await _personBusiness.Save(personDto);

                // USER
                var userDto = new UserCreatedDto
                {
                    Email = dto.Email,
                    Password = dto.Password,
                    Active = true,
                    PersonId = newPerson.Id,
                    Rescheduling = dto.Rescheduling
                };

                var newUser = await _userBusiness.Save(userDto);

                await tx.CommitAsync();
                return newUser;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }
    }

}
