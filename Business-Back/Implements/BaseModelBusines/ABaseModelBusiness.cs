using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Models;

namespace Business_Back.Implements.BaseModelBusiness
{
    public abstract class ABaseModelBusiness<T, Dc, De, Dl> : IBaseModelBusiness<Dc, De, Dl> where T : BaseModel where Dc : class where De : class where Dl : class
    {
        public abstract Task<bool> Delete(int id);
        public abstract Task<bool> DeleteLogical(int id);
        public abstract Task<IEnumerable<Dl>> GetAll();

        public abstract  Task<IEnumerable<Dl>> GetAllUser(int userId);
     
        public abstract Task<Dl?> GetById(int id);
        public abstract Task<Dl> Save(Dc Dto);
        public abstract Task<bool> Update(De dto);

        public  abstract Task ValidateAsync(T entity);
    }
}
