using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;

namespace Data_Back.Interface.ICrud
{
    /// <summary>
    /// Define el contrato para las operaciones de lectura de entidades desde el repositorio.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad sobre la que se realizan las operaciones.</typeparam>
    public interface IGetAll<T> where T : BaseModel
    {
        /// <summary>
        /// Obtiene todos los registros no eliminados lógicamente de la entidad T.
        /// </summary>
        /// <returns>Una lista de entidades activas.</returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Obtiene una entidad específica por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único de la entidad.</param>
        /// <returns>La entidad encontrada o null si no existe.</returns>
        Task<T?> GetById(int id);

        /// <summary>
        /// Obtiene todos los registros de la entidad T, incluidos los eliminados lógicamente.
        /// Solo para uso administrativo.
        /// </summary>
        /// <returns>Una lista completa de entidades, sin filtrar por estado lógico.</returns>
        Task<IEnumerable<T>> GetAllAdmin();
    }
}
