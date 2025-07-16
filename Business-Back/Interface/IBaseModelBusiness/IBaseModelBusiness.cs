using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Back.Interface.BaseModelBusiness
{
    public interface IBaseModelBusiness<Dc, De, Dl> where Dc : class where De : class where Dl : class
    {
        Task<IEnumerable<Dl>> GetAll();
        Task<Dl?> GetById(int id);
        Task<Dl> Save(Dc Dto);
        Task<bool> Update(De dto);
        Task<bool> Delete(int id);
        Task<bool> DeleteLogical(int id);

    }
}
