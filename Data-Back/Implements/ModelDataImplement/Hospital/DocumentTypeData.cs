using Data_Back.Implements.BaseModelData;
using Entity_Back.Context;
using Entity_Back.Models.HospitalModel;
using Microsoft.Extensions.Logging;

namespace Data_Back
{
    public class DocumentTypeData : BaseModelData<DocumentType>, IDocumentTypeData
    {
        public DocumentTypeData(ApplicationDbContext context, ILogger<BaseModelData<DocumentType>> logger)
            : base(context, logger)
        {
        }
    }
}