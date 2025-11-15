using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Interface.IBaseModelData;
using Entity_Back.Models;

namespace Data_Back.Implements.BaseModelData
{
    /// <summary>
    /// Clase base abstracta que implementa la interfaz <see cref="IBaseModelData{T}"/>.
    /// Define operaciones genéricas asincrónicas para el acceso a datos de entidades que heredan de <see cref="BaseModel"/>.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad que debe heredar de <see cref="BaseModel"/>.</typeparam>
    public abstract class ABaseModelData<T> : IBaseModelData<T> where T : BaseModel
    {
        /// <summary>
        /// Elimina físicamente una entidad por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la entidad a eliminar.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        public abstract Task<bool> Delete(int id);

        /// <summary>
        /// Realiza una eliminación lógica de una entidad, marcándola como inactiva o eliminada sin quitarla de la base de datos.
        /// </summary>
        /// <param name="id">Identificador de la entidad a eliminar lógicamente.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        public abstract Task<bool> DeleteLogical(int id);

        /// <summary>
        /// Obtiene todas las entidades activas o visibles para el usuario final.
        /// </summary>
        /// <returns>Colección de entidades del tipo <typeparamref name="T"/>.</returns>
        public abstract Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Obtiene todas las entidades, incluidas aquellas que han sido eliminadas lógicamente o están desactivadas.
        /// Se usa comúnmente en paneles administrativos.
        /// </summary>
        /// <returns>Colección de entidades del tipo <typeparamref name="T"/>.</returns>
        public abstract Task<IEnumerable<T>> GetAllAdmin();

        /// <summary>
        /// Obtiene una entidad por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <returns>La entidad encontrada o null si no existe.</returns>
        public abstract Task<T?> GetById(int id);

        /// <summary>
        /// Guarda una nueva entidad en la base de datos.
        /// </summary>
        /// <param name="entity">Entidad a guardar.</param>
        public abstract Task<T> Save(T entity);

        /// <summary>
        /// Actualiza los datos de una entidad existente.
        /// </summary>
        /// <param name="entity">Entidad con los datos actualizados.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        public abstract Task<bool> Update(T entity);

        public abstract Task<bool> ExistsByAsync(
     Expression<Func<T, object>> fieldSelector,
     object? value);



        public abstract Task<IEnumerable<T>> GetAllUser(int userId);

    }
}
