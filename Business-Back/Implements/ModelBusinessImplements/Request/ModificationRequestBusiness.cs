using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.IBusinessModel;
using Business_Back.Interface.IBusinessModel.Request;
using Data_Back.Interface.IDataModels.Request;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.RequestDto;
using Entity_Back.Dto.SecurityDto.PermissionDto;
using Entity_Back.Enum;
using Entity_Back.Models.Request;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;

namespace Business_Back.Implements.ModelBusinessImplements.Request
{
    public class ModificationRequestBusiness : BaseModelBusinessIm<   ModificationRequest,ModificationRequestCreateDto, ModificationRequestEditDto, ModificationRequestListDto>, IModificationRequestBusiness
    {
        private readonly IModificationRequestData _data;
        private readonly IModificationRequestHandler _doctorAbsenceHandler;

        public ModificationRequestBusiness(IConfiguration configuration, IModificationRequestData data, ILogger<ModificationRequestBusiness> logger, IModificationRequestHandler doctorAbsenceHandler)
       : base(configuration, data, logger)
        {
            _data = data;
            _doctorAbsenceHandler = doctorAbsenceHandler;
        }

        public override async Task<bool> UpdateStatusTypesAsync(int id, int statusTypeId)
        {
            try
            {
                // 1. Actualizar el estado usando tu método ya existente
                var updated = await _data.UpdateStatusTypesAsync(id, statusTypeId);
                if (!updated) return false;

                // 2. Solo ejecutar acciones si el request fue APROBADO
                if (statusTypeId != 8) // 8 = Approved
                    return true;

                // 3. Obtener la solicitud completa
                var request = await _data.GetById(id);
                if (request == null)
                    throw new BusinessException("ModificationRequest not found.");

                // 4. Ejecutar acción del tipo de solicitud
                await ExecuteActionAsync(request);

                return true;
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ModificationRequest status");
                throw;
            }
        }


        private async Task ExecuteActionAsync(ModificationRequest request)
        {
            switch (request.TypeRequest)
            {
                case TypeRequest.Absence: // Falta del doctor
                    await _doctorAbsenceHandler.HandleAsync(request);
                    break;

                default:
                    // No hacer nada por ahora
                    break;
            }
        }


    }
}
