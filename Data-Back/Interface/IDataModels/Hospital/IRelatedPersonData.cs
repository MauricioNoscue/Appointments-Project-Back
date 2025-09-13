using Data_Back.Interface.IBaseModelData;
using Entity_Back.Models.HospitalModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Back.Interface.IDataModels.Hospital
{
    public interface IRelatedPersonData : IBaseModelData<RelatedPerson>
    {
        Task<List<RelatedPerson>> GetByPersonAsync(int personId);

        Task<bool> ExistsDocumentAsync(int personId, int documentTypeId, string document, int? excludeId = null);
        Task<RelatedPerson> GetByIdAsync(int id);
    }

}
