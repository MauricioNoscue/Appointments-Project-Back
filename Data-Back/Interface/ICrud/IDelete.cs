using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;

namespace Data_Back.Interface.ICrud
{
    /// <summary>
    /// Define el contrato para la operacion de eliminación de entidades  permanentes en el repositorio.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad sobre la que se realiza la operación.</typeparam>
    public interface IDelete<T> where T : BaseModel
    {

        /// <summary>
        /// Elimina físicamente una entidad del repositorio según su identificador.
        /// </summary>
        /// <param name="id">Identificador de la entidad a eliminar.</param>
        /// <returns>True si la entidad fue eliminada correctamente; False si no se encontró.</returns>
        Task<bool> Delete(int id);
    }
}
