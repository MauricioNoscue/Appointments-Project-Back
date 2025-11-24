using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Interface.IBaseModelData;
using Entity_Back.Models.SecurityModels;

namespace Data_Back.Interface.IDataModels.Security
{
    /// <summary>
    /// Define el contrato para las operaciones de acceso y gestión de datos de usuarios en el sistema.
    /// Hereda de <see cref="IBaseModelData{User}"/> para operaciones CRUD básicas.
    /// Incluye métodos específicos para la gestión de personas asociadas, validación de credenciales,
    /// recuperación y restablecimiento de contraseñas, y manejo de puntos de restricción.
    /// </summary>
    public interface IUserData : IBaseModelData<User>
    {
        /// <summary>
        /// Guarda una entidad <see cref="Person"/> en el repositorio.
        /// </summary>
        /// <param name="person">La persona a guardar.</param>
        /// <returns>La persona guardada.</returns>
        Task<Person> SavePerson(Person person);

        /// <summary>
        /// Valida las credenciales de un usuario por correo electrónico y contraseña.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>El usuario si las credenciales son válidas; de lo contrario, null.</returns>
        Task<User?> validarCredenciales(string email, string password);

        /// <summary>
        /// Obtiene el detalle de un usuario por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del usuario.</param>
        /// <returns>El usuario con detalles completos.</returns>
        Task<User> GetUserDetailAsync(int id);

        /// <summary>
        /// Solicita el restablecimiento de contraseña para un usuario dado su correo electrónico.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <returns>Token de restablecimiento de contraseña o null si el usuario no existe.</returns>
        Task<string?> RequestPasswordResetAsync(string email);

        /// <summary>
        /// Restablece la contraseña de un usuario usando un token de restablecimiento.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="token">Token de restablecimiento de contraseña.</param>
        /// <param name="newPassword">Nueva contraseña a establecer.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);

        /// <summary>
        /// Disminuye el punto de restricción de un usuario.
        /// </summary>
        /// <param name="userId">Identificador del usuario.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        Task<bool> DecreaseRestrictionPointAsync(int userId);

        /// <summary>
        /// Restaura el punto de restricción de un usuario.
        /// </summary>
        /// <param name="userId">Identificador del usuario.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        Task<bool> RestoreRestrictionPointAsync(int userId);

        Task SaveTwoFactorCodeAsync(int userId, string code, TimeSpan ttl);

        Task ClearTwoFactorCodeAsync(User user);
    }
}
