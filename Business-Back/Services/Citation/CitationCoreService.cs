using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.IBusinessModel;
using Entity_Back;
using Entity_Back.Dto.HospitalDto.Citation;
using Mapster;

namespace Business_Back.Services.Citation
{
    public class CitationCoreService : ICitationCoreService
    {
        private readonly IScheduleHourBusiness _scheduleHourBusiness;
        private readonly ISheduleBusiness _sheduleBusiness;
        private readonly ICitationsBusiness _citationBusiness;
        public CitationCoreService(IScheduleHourBusiness scheduleHourBusiness, ISheduleBusiness sheduleBusiness, ICitationsBusiness citationBusiness)
        {
            _scheduleHourBusiness = scheduleHourBusiness;
            _sheduleBusiness = sheduleBusiness;
            _citationBusiness = citationBusiness;
        }


        public async Task<List<TimeBlockEstado>> GetAvailableTimeBlocksByTypeCitationIdAsync(int typeCitationId, DateTime fecha, bool incluirOcupados = false)
        {
            try
            {
                // Paso 1: Obtener el Shedule por tipo de cita
                var shedule = await _sheduleBusiness.GetByIdTypeCitation(typeCitationId);
                if (shedule == null)
                    throw new Exception("No se encontró un horario (Shedule) para el tipo de cita.");

                // Paso 2: Obtener el ScheduleHour asociado al Shedule
                var scheduleHour = await _scheduleHourBusiness.GetByDateAndSheduleAsync(shedule.Id);
                if (scheduleHour == null)
                    throw new Exception("No se encontró configuración horaria para el tipo de cita.");

                // Paso 3: Mapear a entidad y unir el Shedule
                var scheduleHourEntity = scheduleHour.Adapt<ScheduleHour>();
                scheduleHourEntity.Shedule = shedule.Adapt<Shedule>();

                // Paso 4: Generar los bloques posibles
                var todosLosBloques = CalcularBloquesHorarios(scheduleHourEntity);

                // Paso 5: Consultar citas ya agendadas en esa fecha
                var bloquesOcupados = await _citationBusiness
                    .GetUsedTimeBlocksByScheduleHourIdAndDateAsync(scheduleHourEntity.Id, fecha.Date);

                // Paso 6: Filtrar/etiquetar los bloques según el parámetro
                var resultado = FiltrarBloquesDisponibles(todosLosBloques, bloquesOcupados, incluirOcupados);

                resultado = FiltrarBloquesPorFechaActual(resultado, fecha);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener bloques horarios disponibles: {ex.Message}", ex);
            }
        }


        public List<TimeSpan> CalcularBloquesHorarios(ScheduleHour scheduleHour)
        {
            var bloques = new List<TimeSpan>();

            if (scheduleHour == null || scheduleHour.Shedule == null || scheduleHour.Shedule.NumberCitation <= 0)
                return bloques;

            int cantidadCitas = scheduleHour.Shedule.NumberCitation;
            TimeSpan horaInicio = scheduleHour.StartTime;
            TimeSpan horaFin = scheduleHour.EndTime;

            TimeSpan? pausaInicio = scheduleHour.BreakStartTime;
            TimeSpan? pausaFin = scheduleHour.BreakEndTime;

            TimeSpan duracionDisponible = pausaInicio.HasValue && pausaFin.HasValue
                ? (pausaInicio.Value - horaInicio) + (horaFin - pausaFin.Value)
                : horaFin - horaInicio;

            TimeSpan duracionCita = TimeSpan.FromMinutes(duracionDisponible.TotalMinutes / cantidadCitas);
            TimeSpan actual = horaInicio;

            for (int i = 0; i < cantidadCitas; i++)
            {
                if (pausaInicio.HasValue && pausaFin.HasValue &&
                    actual >= pausaInicio.Value && actual < pausaFin.Value)
                {
                    actual = pausaFin.Value;
                }

                if (actual + duracionCita <= horaFin)
                {
                    bloques.Add(actual);
                    actual = actual.Add(duracionCita);
                }
                else
                {
                    break;
                }
            }

            return bloques;
        }

        public List<TimeBlockEstado> FiltrarBloquesDisponibles(List<TimeSpan> todosLosBloques, List<TimeSpan> bloquesOcupados, bool incluirOcupados = false)
        {

            if (!incluirOcupados)
            {
                // Solo disponibles
                return todosLosBloques
                    .Where(b => !bloquesOcupados.Contains(b))
                    .Select(b => new TimeBlockEstado { Hora = b, EstaDisponible = true })
                    .ToList();
            }

            // Todos, pero con flag
            return todosLosBloques
                .Select(b => new TimeBlockEstado
                {
                    Hora = b,
                    EstaDisponible = !bloquesOcupados.Contains(b)
                }).ToList();
        }

        /// <summary>
        /// Filtra los bloques horarios tomando en cuenta la hora actual
        /// solo si la fecha consultada es hoy.
        /// </summary>
        /// <param name="bloques">Lista de bloques ya filtrados/preparados.</param>
        /// <param name="fecha">Fecha de la cita solicitada.</param>
        /// <returns>Bloques filtrados según si la fecha es hoy.</returns>
        public List<TimeBlockEstado> FiltrarBloquesPorFechaActual(
            List<TimeBlockEstado> bloques,
            DateTime fecha)
        {
            try
            {
                // Si NO es hoy, retorna todos los bloques
                if (fecha.Date != DateTime.Now.Date)
                    return bloques;

                // Hora actual (solo hora-minutos)
                var horaActual = DateTime.Now.TimeOfDay;

                // Filtrar solo bloques >= hora actual
                return bloques
                    .Where(b => b.Hora >= horaActual)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al filtrar bloques por fecha actual: {ex.Message}", ex);
            }
        }


    }
}
