using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Dto.HospitalDto.DoctorDto;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Business_Back
{
    /// <summary>
    /// Implementación de la lógica de negocio para la entidad Doctor.
    /// Proporciona métodos para operaciones CRUD y consultas especializadas relacionadas con doctores.
    /// </summary>
    public class DoctorBusiness : BaseModelBusinessIm<Doctor, DoctorCreateDto, DoctorEditDto, DoctorListDto>, IDoctorBusiness
    {
        private readonly IDoctorData _data;

        /// <summary>
        /// Constructor de la clase DoctorBusiness.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <param name="data">Interfaz de acceso a datos de Doctor.</param>
        /// <param name="logger">Logger para registrar información y errores.</param>
        public DoctorBusiness(IConfiguration configuration, IDoctorData data, ILogger<DoctorBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }

        /// <summary>
        /// Obtiene un doctor junto con la información de la persona asociada por su identificador.
        /// </summary>
        /// <param name="id">Identificador del doctor.</param>
        /// <returns>DTO con la información del doctor y la persona asociada, o null si no existe.</returns>
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

        /// <summary>
        /// Obtiene todos los doctores junto con la información de las personas asociadas.
        /// </summary>
        /// <returns>Lista de DTOs con la información de los doctores y las personas asociadas.</returns>
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

        /// <summary>
        /// Obtiene todas las citas asignadas a un doctor por su identificador.
        /// </summary>
        /// <param name="doctorId">Identificador del doctor.</param>
        /// <returns>Lista de DTOs de citas asociadas al doctor.</returns>
        public async Task<IEnumerable<CitationListDto>> GetCitationsByDoctorId(int doctorId)
        {
            try
            {
                if (doctorId <= 0)
                {
                    throw new ArgumentException("El doctorId debe ser mayor que cero.", nameof(doctorId));
                }

                return await _data.GetCitationsByDoctorId(doctorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las citas del doctor {doctorId}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza la información de un doctor.
        /// </summary>
        /// <param name="dto">DTO con los datos a actualizar.</param>
        /// <returns>True si la actualización fue exitosa, false en caso contrario.</returns>
        public override async Task<bool> Update(DoctorEditDto dto)
        {
            try
            {
                if (dto == null)
                    throw new ArgumentNullException(nameof(dto), "Los datos para actualización no pueden ser nulos.");

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

        /// <summary>
        /// Obtiene la información de un doctor junto con todas sus reseñas.
        /// </summary>
        /// <param name="doctorId">Identificador del doctor.</param>
        /// <returns>DTO con la información del doctor y sus reseñas, o null si no existe.</returns>
        public Task<DoctorReviewAll?> GetDoctorWithReviewsAsync(int doctorId)
        {
            try
            {
                var doctorReviews = _data.GetDoctorWithReviewsAsync(doctorId);
                return doctorReviews;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception($"Error al obtener las reseñas del doctor {doctorId}: {ex.Message}", ex);
            }
        }
    }
}
