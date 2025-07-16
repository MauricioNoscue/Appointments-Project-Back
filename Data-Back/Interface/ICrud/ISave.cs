using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;

namespace Data_Back.Interface.ICrud
{

    /// <summary>
    /// Define el contrato para la operación de creación (alta) de una entidad en el repositorio.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad sobre la que se realiza la operación.</typeparam>
    public interface ISave<T> where T : BaseModel
    {

        /// <summary>
        /// Agrega una nueva entidad de tipo <typeparamref name="T"/> al repositorio.
        /// </summary>
        /// <param name="entity">Entidad que se desea agregar.</param>
        /// <returns>La entidad agregada con sus posibles valores generados (por ejemplo, ID).</returns>
        Task<T> Save(T entity);
    }
}
