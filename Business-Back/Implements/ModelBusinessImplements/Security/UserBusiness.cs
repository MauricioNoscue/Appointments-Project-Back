using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.UserDto;
using Entity_Back.Enum;
using Entity_Back.Models.SecurityModels;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;

namespace Business_Back.Implements.ModelBusinessImplements.Security
{
    public class UserBusiness : BaseModelBusinessIm<User, UserCreatedDto, UserEditDto, UserListDto>, IUserBusiness
    {
        private readonly IUserData _data;

        public UserBusiness(IConfiguration configuration, IUserData data, ILogger<UserBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }




        public override async Task<UserListDto> Save(UserCreatedDto dto)
        {
            if (dto == null)
                throw new ValidationException(nameof(dto), "Los datos enviados son nulos o inválidos.");

            try
            {
                // Mapea manualmente person desde dto
                var person = dto.Person.Adapt<Person>();

                // Inserta primero la persona
                var personaCreada = await _data.SavePerson(person); // necesitas agregar esto en IUserData

                // Mapea user
                var user = dto.Adapt<User>();
                user.PersonId = personaCreada.Id;

                var userCreado = await _data.Save(user);

                // Cargar persona (por si no la trae el user directamente)
                userCreado.Person = personaCreada;

                return userCreado.Adapt<UserListDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario con persona.");
                throw new BusinessException("Error al intentar crear el usuario.", ex);
            }
        }


        public override async Task<bool> Update(UserEditDto dto)
        {
            if (dto == null)
                throw new ValidationException(nameof(dto), "Los datos enviados para actualización son inválidos.");

            try
            {
                var user = await _data.GetById(dto.Id);
                if (user == null) throw new BusinessException("Usuario no encontrado.");

                // Mapeamos datos del usuario
                dto.Adapt(user);

                // Mapeamos datos de la persona asociada
                dto.Person.Adapt(user.Person);

                await _data.Update(user); // solo necesitas uno si el contexto está trackeando

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar usuario con persona.");
                throw new BusinessException("Error al intentar actualizar el registro.", ex);
            }
        }


    }
}
