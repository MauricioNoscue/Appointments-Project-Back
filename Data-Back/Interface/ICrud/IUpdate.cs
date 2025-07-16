using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Back.Interface.ICrud
{
    /// <summary>
    /// Define el contrato para las operaciones de actualización de entidades en el repositorio.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad sobre la que se realizan las operaciones.</typeparam>
    public interface IUpdate<T> where T : class
    {
        /// <summary>
        /// Actualiza los datos de una entidad existente en el repositorio.
        /// </summary>
        /// <param name="entity">Entidad con los datos actualizados.</param>
        /// <returns>Un valor booleano que indica si la operación de actualización fue exitosa.</returns>
        Task<bool> Update(T entity);
    }
}
