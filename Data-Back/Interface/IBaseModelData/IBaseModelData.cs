using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Interface.ICrud;
using Entity_Back.Models;

namespace Data_Back.Interface.IBaseModelData
{

    /// <summary>
    /// Define una interfaz genérica que agrupa las operaciones CRUD básicas (Crear, Leer, Actualizar, Eliminar)
    /// para cualquier entidad de tipo clase.
    /// 
    /// Hereda de interfaces específicas: ISave, IGetAll, IUpdate, y IDeleted, lo cual permite una mejor
    /// organización y separación de responsabilidades dentro del repositorio.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad (clase) sobre la que se realizarán las operaciones.</typeparam>
    public interface  IBaseModelData <T> : ISave<T>,IGetAll<T>,IUpdate<T>,IDelete<T>,IDeleteLogic<T> where T : BaseModel
    {
    }
}
