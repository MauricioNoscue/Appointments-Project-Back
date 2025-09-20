using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Business_Back
{
    public class DoctorBusiness : BaseModelBusinessIm<Doctor, DoctorCreateDto, DoctorEditDto, DoctorListDto>, IDoctorBusiness
    {
        private readonly IDoctorData _data;

        public DoctorBusiness(IConfiguration configuration, IDoctorData data, ILogger<DoctorBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }

        public async Task<DoctorListDto?> GetDoctorWithPersonById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("El id debe ser mayor que cero.", nameof(id));
                }

                var doctor = await _data.GetDoctorWithPersonById(id);
                return doctor?.Adapt<DoctorListDto>();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception($"Error al obtener el doctor por PersonId {id}: {ex.Message}", ex);

            }
        }
        public async Task<IEnumerable<DoctorListDto>> GetAllDoctorWithPerson()
        {
            try
            {
                var doctors = await _data.GetAllDoctorWithPerson();
                return doctors.Adapt<IEnumerable<DoctorListDto>>();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception($"Error al obtener todos los doctores: {ex.Message}", ex);
            }
        }

        public override async Task<bool> Update(DoctorEditDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Los datos para actualización no pueden ser nulos.");

            try
            {
                // Obtener el doctor existente para preservar PersonId si no se proporciona
                var existingDoctor = await _data.GetById(dto.Id);
                if (existingDoctor == null)
                {
                    _logger.LogWarning("Doctor con ID {DoctorId} no encontrado para actualización.", dto.Id);
                    return false;
                }

                // Si PersonId no se proporciona o es 0, usar el del registro existente
                if (dto.PersonId == 0)
                {
                    dto.PersonId = existingDoctor.PersonId;
                }

                // Si Active no se proporciona correctamente, usar el del registro existente
                // Nota: Como Active es bool, no podemos verificar si es "no proporcionado"
                // Pero podemos asumir que si es false y el existente es true, mantener el existente
                // Esto es opcional y depende de la lógica de negocio

                // Proceder con la actualización normal
                return await base.Update(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el doctor con ID {DoctorId}", dto.Id);
                throw new Exception($"Error al actualizar el doctor: {ex.Message}", ex);
            }
        }
    }
}
