using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;

namespace Data_Back.Interface.ICrud
{

    /// <summary>
    /// Define el contrato para las operación de eliminación  lógica de entidades en el repositorio.
  
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad sobre la que se realiza la operación.</typeparam>
    public interface IDeleteLogic<T> where T : BaseModel
    {
        /// <summary>
        /// Marca lógicamente una entidad como eliminada (por ejemplo, estableciendo IsDeleted en true).
        /// </summary>
        /// <param name="id">Identificador de la entidad a marcar como eliminada.</param>
        /// <returns>True si la operación fue exitosa; False si no se encontró o no aplica.</returns>
        Task<bool> DeleteLogical(int id);
    }
}
