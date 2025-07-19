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
            if (dto.Person == null)
                throw new ValidationException("La persona es obligatoria para crear un usuario.");

            try
            {
                

                // Crear el User manualmente para evitar problemas de mapeo
                var entidad = new User
                {
                    Email = dto.Email,
                    Password = dto.Password,
                    Active = dto.Active,
                    Person = new Person
                    {
                        FullName = dto.Person.FullName,
                        FullLastName = dto.Person.FullLastName,
                        DocumentTypeId = dto.Person.DocumentTypeId,
                        Document = dto.Person.Document,
                        DateBorn = dto.Person.DateBorn,
                        PhoneNumber = dto.Person.PhoneNumber,
                        EpsId = dto.Person.EpsId,
                        Gender = ParseGender(dto.Person.Gender),
                        HealthRegime = ParseHealthRegime(dto.Person.HealthRegime),
                        Active = true,
                        IsDeleted = false
                    }
                };

               
            

                var entityGuardado = await _data.Save(entidad);


                var resultado = entityGuardado.Adapt<UserListDto>();
                return resultado;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario - Detalles: {Message}", ex.Message);
                throw new BusinessException("Error al intentar crear el usuario.", ex);
            }
        }



        private Gender ParseGender(string gender)
        {
            _logger.LogInformation($"Parseando Gender: {gender}");
            return gender?.ToLower() switch
            {
                "masculino" or "male" or "m" => Gender.Masculino,
                "femenino" or "female" or "f" => Gender.Femenino,
                _ => Gender.Masculino // Valor por defecto
            };
        }

        private HealthRegime ParseHealthRegime(string regime)
        {
            _logger.LogInformation($"Parseando HealthRegime: {regime}");
            return regime?.ToLower() switch
            {
                "contributivo" => HealthRegime.Contributivo,
                "subsidiado" => HealthRegime.Subsidiado,
                "especial" => HealthRegime.Excepcion,
                _ => HealthRegime.Contributivo // Valor por defecto
            };
        }



    }
}
