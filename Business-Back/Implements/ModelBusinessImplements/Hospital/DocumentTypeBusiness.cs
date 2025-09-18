using Business_Back.Implements.BaseModelBusiness;
using Data_Back;
using Entity_Back;
using Entity_Back.Models.HospitalModel;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;

namespace Business_Back
{
    public class DocumentTypeBusiness : BaseModelBusinessIm<DocumentType, DocumentTypeCreatedDto, DocumentTypeEditDto, DocumentTypeListDto>
    {
        private readonly IDocumentTypeData _data;

        public DocumentTypeBusiness(IConfiguration configuration, IDocumentTypeData data, ILogger<DocumentTypeBusiness> logger)
            : base(configuration, data, logger) => _data = data;

        public override async Task<bool> Update(DocumentTypeEditDto dto)
        {
            if (dto == null) throw new ValidationException(nameof(dto), "Datos inválidos");

            var entity = await _data.GetById(dto.Id);
            if (entity is null) throw new EntityNotFoundException($"DocumentType {dto.Id} no existe");

            dto.Adapt(entity);

            return await _data.Update(entity);
        }
    }
}