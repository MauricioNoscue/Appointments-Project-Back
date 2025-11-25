using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back
{
    /// <summary>
    /// Implementación de la lógica de negocio para la gestión de horarios (Shedule).
    /// </summary>
    public class SheduleBusiness : BaseModelBusinessIm<Shedule, SheduleCreateDto, SheduleEditDto, SheduleListDto>, ISheduleBusiness
    {
        private readonly ISheduleData _data;

        /// <summary>
        /// Constructor de la clase SheduleBusiness.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        /// <param name="data">Interfaz de acceso a datos de horarios.</param>
        /// <param name="logger">Logger para la clase.</param>
        public SheduleBusiness(IConfiguration configuration, ISheduleData data, ILogger<SheduleBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }

        /// <summary>
        /// Obtiene un horario por el identificador del tipo de cita.
        /// </summary>
        /// <param name="id">Identificador del tipo de cita.</param>
        /// <returns>DTO del horario correspondiente o null si no existe.</returns>
        public async Task<SheduleListDto?> GetByIdTypeCitation(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("El id debe ser mayor que cero.", nameof(id));
                }

                var shedule = await _data.GetByIdTypeCitation(id);
                return shedule.Adapt<SheduleListDto>();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception($"Error al obtener el horario por TypeCitationId {id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene un horario por doctor y fecha.
        /// </summary>
        /// <param name="doctorId">Identificador del doctor.</param>
        /// <param name="date">Fecha del horario.</param>
        /// <returns>Entidad Shedule correspondiente o null si no existe.</returns>
        public async Task<Shedule?> GetByDoctorAndDateAsync(int doctorId, DateTime date)
        {
            try
            {
                return await _data.GetByDoctorAndDateAsync(doctorId, date);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el horario por doctorId {doctorId} y fecha {date}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene todos los horarios asociados a un doctor.
        /// </summary>
        /// <param name="doctorId">Identificador del doctor.</param>
        /// <returns>Lista de DTOs de horarios.</returns>
        public async Task<IEnumerable<SheduleListDto>> GetSheduleByDoctor(int doctorId)
        {
            try
            {
                var schedules = await _data.GetSheduleByDoctor(doctorId);
                return schedules.Adapt<IEnumerable<SheduleListDto>>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los horarios del doctorId {doctorId}: {ex.Message}", ex);
            }
        }
    }
}
