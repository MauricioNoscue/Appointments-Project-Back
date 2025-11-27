using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Dto.SecurityDto.RolUserDto;
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
    /// <summary>
    /// Clase de negocio para la gestión de usuarios.
    /// Proporciona métodos para crear, validar, obtener detalles, restablecer contraseñas y actualizar puntos de restricción de usuarios.
    /// </summary>
    public class UserBusiness : BaseModelBusinessIm<User, UserCreatedDto, UserEditDto, UserListDto>, IUserBusiness
    {
        private readonly IUserData _data;
        private readonly IPersonBusiness _dataPerson;
        private readonly IRolUserBusiness _dataRolUser;

        /// <summary>
        /// Constructor de la clase UserBusiness.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <param name="data">Interfaz de acceso a datos de usuario.</param>
        /// <param name="logger">Logger para registrar eventos y errores.</param>
        /// <param name="dataPerson">Interfaz de negocio para personas.</param>
        /// <param name="dataRolUser">Interfaz de negocio para roles de usuario.</param>
        public UserBusiness(IConfiguration configuration, IUserData data, ILogger<UserBusiness> logger, IPersonBusiness dataPerson, IRolUserBusiness dataRolUser)
            : base(configuration, data, logger)
        {
            _data = data;
            _dataPerson = dataPerson;
            _dataRolUser = dataRolUser;
        }

        /// <summary>
        /// Obtiene el detalle de un usuario por su identificador.
        /// </summary>
        /// <param name="id">Identificador del usuario.</param>
        /// <returns>Detalle del usuario.</returns>
        public async Task<UserDetailDto> GetUserDetailAsync(int id)
        {
            try
            {
                var user = await _data.GetUserDetailAsync(id);
                if (user == null) return null;

                return new UserDetailDto
                {
                    FullName = user.Person.FullName,
                    FullLastName = user.Person.FullLastName,
                    Document = $"{user.Person.DocumentType.Name} {user.Person.Document}",
                    PhoneNumber = user.Person.PhoneNumber,
                    Email = user.Email,
                    DateBorn = user.Person.DateBorn,
                    RegisterDate = (DateTime)user.RegistrationDate,
                    Gender = user.Person.Gender.ToString(),
                    HealthRegime = user.Person.HealthRegime.ToString(),
                    Roles = user.RolUser.Select(r => r.Rol.Name).ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el detalle del usuario con Id {Id}", id);
                throw new BusinessException("Ocurrió un error al obtener el detalle del usuario.", ex);
            }
        }

        /// <summary>
        /// Guarda un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="Dto">DTO con los datos del usuario a crear.</param>
        /// <returns>DTO con los datos del usuario creado.</returns>
        public override async Task<UserListDto> Save(UserCreatedDto Dto)
        {
            if (Dto == null)
                throw new ValidationException(nameof(Dto), "Los datos enviados son nulos o inválidos.");

            if (string.IsNullOrWhiteSpace(Dto.Password))
                throw new ValidationException(nameof(Dto.Password), "La contraseña es obligatoria.");

            try
            {
                var entidad = Dto.Adapt<User>();
                entidad.RestrictionPoint = 3;

                // 🔹 Guardar la contraseña original antes de hashear
                string plainPassword = Dto.Password; // ← ESTA SE ENVÍA AL CORREO

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(Dto.Password, workFactor: 12);
                entidad.Password = passwordHash;

                await ValidateAsync(entidad);

                var entiry = await _data.Save(entidad);

                PersonListDto? person = await _dataPerson.GetById(Dto.PersonId);

                RolUserCreatedDto Paciente = new RolUserCreatedDto
                {
                    RolId = 2,
                    UserId = entiry.Id,
                };

                var userRol = await _dataRolUser.Save(Paciente);

                var asunto = "¡Bienvenido a nuestro sistema!";

                // 🔥 Correo con email + contraseña
                var cuerpo = $@"
        <div style=""font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;"">
            <div style=""max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 10px; padding: 30px; box-shadow: 0 0 10px rgba(0,0,0,0.1);"">
                
                <h2 style=""color: #4CAF50;"">¡Bienvenido, {person?.FullName}!</h2>

                <p style=""font-size: 16px; color: #333;"">
                    Tu cuenta ha sido creada exitosamente. Aquí tienes tus credenciales:
                </p>

                <div style=""background: #eef8ee; padding: 15px; border-radius: 8px; margin: 25px 0;"">
                    <p><strong>Email:</strong> {entiry.Email}</p>
                    <p><strong>Contraseña:</strong> {plainPassword}</p>
                </div>

                <p style=""font-size: 14px; color: #444;"">
                    Ahora puedes iniciar sesión y comenzar a usar nuestros servicios.
                </p>

                <div style=""margin-top: 30px; text-align: center;"">
                    <a href=""http://localhost:4200/"" style=""background-color: #4CAF50; color: white; padding: 12px 24px; border-radius: 6px; text-decoration: none;"">
                        Iniciar sesión
                    </a>
                </div>

                <hr style=""margin-top: 40px; border: none; border-top: 1px solid #eee;"" />
                <p style=""font-size: 12px; color: #aaa; text-align: center;"">
                    Este mensaje fue enviado automáticamente. No respondas a este correo.
                </p>
            </div>
        </div>";

                await CorreoMensaje.EnviarAsync(_configuration, entiry.Email, asunto, cuerpo);

                return entiry.Adapt<UserListDto>();
            }
            catch (ValidationException vex)
            {
                _logger.LogWarning(vex, "Validación fallida en {Entity}", typeof(User).Name);
                throw;
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error al crear entidad {Entity}", typeof(User).Name);
                throw new BusinessException("Error al intentar crear el registro.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al crear usuario.");
                throw new BusinessException("Ocurrió un error inesperado al crear el usuario.", ex);
            }
        }


        /// <summary>
        /// Valida si un usuario cumple con las reglas de negocio antes de ser guardado.
        /// </summary>
        /// <param name="entity">Entidad usuario a validar.</param>
        public override async Task ValidateAsync(User entity)
        {
            try
            {
                if (await _data.ExistsByAsync(x => x.Email, entity.Email))
                    throw new ValidationException(nameof(User.Email), "El email ya está registrado.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al validar el usuario.");
                throw new BusinessException("Ocurrió un error al validar el usuario.", ex);
            }
        }

        /// <summary>
        /// Solicita el restablecimiento de contraseña para un usuario.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <returns>Token de restablecimiento de contraseña.</returns>
        public async Task<string?> RequestPasswordResetAsync(string email)
        {
            try
            {
                var token = await _data.RequestPasswordResetAsync(email);

                var baseUrl = _configuration["Frontend:BaseUrl"] ?? "http://localhost:8081";

                var resetLink = $"{baseUrl}/auth/reset-password" +
                                $"?token={Uri.EscapeDataString(token)}" +
                                $"&email={Uri.EscapeDataString(email)}";

                var subject = "🔒 Recuperación de contraseña";

                var body = $@"
                    <div style=""font-family: Arial, sans-serif; background-color: #f9f9f9; padding: 30px;"">
                      <div style=""max-width: 600px; margin: auto; background: #ffffff; border-radius: 10px; box-shadow: 0 2px 6px rgba(0,0,0,0.1); padding: 20px;"">
        
                        <h2 style=""color: #2c3e50; text-align: center;"">Recuperación de contraseña</h2>
        
                        <p style=""font-size: 15px; color: #333;"">
                          Hola <b>{email}</b>,
                        </p>
        
                        <p style=""font-size: 15px; color: #333;"">
                          Hemos recibido una solicitud para restablecer tu contraseña.  
                          Para continuar, haz clic en el siguiente botón:
                        </p>

                        <div style=""text-align: center; margin: 30px 0;"">
                          <a href='{resetLink}' style=""background-color: #007bff; color: #ffffff; padding: 12px 25px; text-decoration: none; border-radius: 6px; font-size: 16px;"">
                            🔑 Restablecer Contraseña
                          </a>
                        </div>

                        <p style=""font-size: 14px; color: #555;"">
                          ⚠️ Este enlace será válido solo por <b>1 hora</b>.  
                          Si no solicitaste este cambio, puedes ignorar este mensaje y tu cuenta seguirá segura.
                        </p>

                        <hr style=""margin: 25px 0; border: none; border-top: 1px solid #eee;"">

                        <p style=""font-size: 13px; color: #999; text-align: center;"">
                          © {DateTime.UtcNow.Year} Tu Sistema de Carnetización Digital.  
                          Este correo fue enviado automáticamente, por favor no respondas.
                        </p>

                      </div>
                    </div>";

                await CorreoMensaje.EnviarAsync(_configuration, email, subject, body);

                if (token == null)
                {
                    _logger.LogWarning("Password reset requested for non-existing email: {Email}", email);
                    return null;
                }

                return token;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error requesting password reset for {Email}", email);
                throw new BusinessException("An error occurred while requesting password reset.", ex);
            }
        }

        /// <summary>
        /// Restablece la contraseña de un usuario usando un token.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="token">Token de restablecimiento.</param>
        /// <param name="newPassword">Nueva contraseña.</param>
        /// <returns>True si el restablecimiento fue exitoso, false en caso contrario.</returns>
        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            try
            {
                var result = await _data.ResetPasswordAsync(email, token, newPassword);

                if (!result)
                {
                    _logger.LogWarning("Invalid reset attempt for {Email} with token {Token}", email, token);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error resetting password for {Email}", email);
                throw new BusinessException("An error occurred while resetting the password.", ex);
            }
        }

        /// <summary>
        /// Actualiza los puntos de restricción de un usuario.
        /// </summary>
        /// <param name="userId">Identificador del usuario.</param>
        /// <param name="restore">Indica si se deben restaurar los puntos.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public async Task<bool> UpdateRestrictionPointsAsync(int userId, bool restore = false)
        {
            try
            {
                if (restore)
                    return await _data.RestoreRestrictionPointAsync(userId);

                return await _data.DecreaseRestrictionPointAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar los puntos de restricción para el usuario {UserId}", userId);
                throw new BusinessException("Ocurrió un error al actualizar los puntos de restricción.", ex);
            }
        }

        public async  Task<int?> GetByUserc(int userId)
        {   
            try
            {
                var user = await _data.GetByUserc(userId);
                return user.Person.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el usuario por Userc {UserId}", userId);
                throw new BusinessException("Ocurrió un error al obtener el usuario por Userc.", ex);
            }
        }



        public async Task<bool> ToggleReschedulingAsync(int userId)
        {
            try
            {
                // Llamar a Data donde realmente se invierte la propiedad
                return await _data.ToggleReschedulingAsync(userId);
            }
            catch (BusinessException)
            {
                throw;
            }
        }

    }
}
