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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;
using Utilities_Back.Message.Email;

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


                var asunto = "¡Bienvenido a nuestro sistema!";
                var cuerpo = $@"
                            <div style=""font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;"">
                                <div style=""max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 10px; padding: 30px; box-shadow: 0 0 10px rgba(0,0,0,0.1);"">
                                    <h2 style=""color: #4CAF50;"">¡Bienvenido, {userCreado.Email}!</h2>
                                    <p style=""font-size: 16px; color: #333;"">
                                        Tu cuenta ha sido creada exitosamente. Gracias por registrarte en nuestro sistema.
                                    </p>
                                    <p style=""font-size: 14px; color: #666;"">
                                        Ahora puedes iniciar sesión y comenzar a disfrutar de nuestros servicios. Si tienes alguna pregunta, no dudes en contactarnos.
                                    </p>
                                    <div style=""margin-top: 30px; text-align: center;"">
                                        <a href=""http://localhost:4200/"" style=""background-color: #4CAF50; color: white; padding: 12px 24px; text-decoration: none; border-radius: 5px; display: inline-block;"">Iniciar sesión</a>
                                    </div>
                                    <hr style=""margin-top: 40px; border: none; border-top: 1px solid #eee;"" />
                                    <p style=""font-size: 12px; color: #aaa; text-align: center;"">
                                        Este mensaje fue enviado automáticamente. Por favor, no respondas a este correo.
                                    </p>
                                </div>
                            </div>
            ";


                await CorreoMensaje.EnviarAsync(_configuration, userCreado.Email, asunto, cuerpo);

                return userCreado.Adapt<UserListDto>();
            }
            catch (DbUpdateException dbEx)
            {
                // Capturamos errores de la base de datos y tratamos errores de restricción única
                var mensaje = ParseUniqueConstraintError(dbEx);
                throw new ValidationException(mensaje);
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
