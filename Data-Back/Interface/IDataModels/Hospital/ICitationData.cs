using Data_Back.Interface.IBaseModelData;
using Entity_Back;

namespace Data_Back
{
    public interface ICitationsData : IBaseModelData<Citation>
    {
        // Se pueden agregar métodos específicos si en el futuro se requiere lógica propia para citas
    }
}


