using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Hospital;
using Data_Back.Interface;
using Data_Back.Interface.IDataModels.Hospital;
using Entity_Back.Dto.HospitalDto.RelatedPerson;
using Entity_Back.Models.HospitalModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Back.Implements.ModelBusinessImplements.Hospital
{
    public class RelatedPersonBussiness : BaseModelBusinessIm<RelatedPerson, RelatedPersonCreatedDto, RelatedPersonEditDto, RelatedPersonListDto>, IRelatedPersonBusiness
    {
        private readonly IRelatedPersonData _data;

        public RelatedPersonBussiness(IConfiguration configuration, IRelatedPersonData data, ILogger<RelatedPersonBussiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }
        // LISTAR por titular (sin Query())
        public async Task<List<RelatedPersonListDto>> GetByPersonAsync(int personId)
        {
            var list = await _data.GetByPersonAsync(personId);
            return list.Select(x => new RelatedPersonListDto
            {
                Id = x.Id,
                PersonId = x.PersonId,
                FullName = x.FirstName + " " + x.LastName,
                Relation = x.Relation,
                DocumentTypeName = x.DocumentType.Name,
                Document = x.Document
            }).ToList();
        }

        // using Mapster; // si quieres devolver el ListDto adaptado
        public override async Task<bool> Update(RelatedPersonEditDto dto)
        {
            Console.WriteLine($"[RPB] Update dto => Id={dto.Id}, Relation={dto.Relation}");

            var current = await _data.GetByIdAsync(dto.Id)
                         ?? throw new Exception("No existe la persona relacionada.");

            current.FirstName = (dto.FirstName ?? "").Trim();
            current.LastName = (dto.LastName ?? "").Trim();
            current.Relation = (dto.Relation ?? "").Trim();
            current.DocumentTypeId = dto.DocumentTypeId;
            current.Document = (dto.Document ?? "").Trim();

            await ValidateAsync(current);
            var ok = await _data.Update(current);     // devuelve true/false
            Console.WriteLine($"[RPB] Update rows>0 => {ok}");
            return ok;
        }


        // Validación de dominio (tu base la invoca en Save)
        public override async Task ValidateAsync(RelatedPerson entity)
        {
            if (entity == null)
                throw new ValidationException(nameof(entity), "Entidad nula.");

            entity.FirstName = (entity.FirstName ?? "").Trim();
            entity.LastName = (entity.LastName ?? "").Trim();
            entity.Relation = (entity.Relation ?? "").Trim();
            entity.Document = (entity.Document ?? "").Trim();

            if (entity.PersonId <= 0)
                throw new ValidationException(nameof(entity.PersonId), "El titular es obligatorio.");
            if (entity.DocumentTypeId <= 0)
                throw new ValidationException(nameof(entity.DocumentTypeId), "El tipo de documento es obligatorio.");
            if (string.IsNullOrWhiteSpace(entity.FirstName))
                throw new ValidationException(nameof(entity.FirstName), "El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(entity.LastName))
                throw new ValidationException(nameof(entity.LastName), "El apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(entity.Relation))
                throw new ValidationException(nameof(entity.Relation), "La relación es obligatoria.");
            if (string.IsNullOrWhiteSpace(entity.Document))
                throw new ValidationException(nameof(entity.Document), "El número de documento es obligatorio.");

            var dup = await _data.ExistsDocumentAsync(entity.PersonId, entity.DocumentTypeId, entity.Document, entity.Id);
            if (dup)
                throw new ValidationException("Duplicado", "Ya existe una persona relacionada con ese documento para este titular.");
        }
    }
}